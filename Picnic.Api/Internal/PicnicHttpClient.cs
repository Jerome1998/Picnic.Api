using Picnic.Api.Configuration;
using Picnic.Api.Exceptions;
using Picnic.Api.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Picnic.Api.Internal;

internal sealed class PicnicHttpClient : IDisposable
{
    private const string AUTH_HEADER = "x-picnic-auth";
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;
    private readonly string _picnicAgent;
    private readonly string _picnicDid;

    public PicnicHttpClient(PicnicApiOptions options, HttpMessageHandler? httpMessageHandler = null)
    {
        string countryCode = options.CountryCode;
        _baseUrl = options.ResolveBaseUrl();
        _picnicAgent = options.PicnicAgent;
        _picnicDid = options.PicnicDid;
        this.AuthToken = options.AuthToken;

        _httpClient = httpMessageHandler is null ? new HttpClient() : new HttpClient(httpMessageHandler);
        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("okhttp/4.9.0");
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        string acceptLanguage = string.IsNullOrWhiteSpace(countryCode)
            ? PicnicApiOptions.DefaultCountryCode.ToLowerInvariant()
            : countryCode.Trim().ToLowerInvariant();
        _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", acceptLanguage);

        if (!string.IsNullOrWhiteSpace(this.AuthToken))
        {
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(AUTH_HEADER, this.AuthToken);
        }
    }

    public bool IsAuthenticated => !string.IsNullOrWhiteSpace(this.AuthToken);

    public string? AuthToken { get; private set; }

    public async Task<PicnicApiResponse> GetAsync(string path, bool includePicnicHeaders = false, CancellationToken cancellationToken = default)
    {
        using var request = this.CreateRequest(HttpMethod.Get, path, includePicnicHeaders);
        return await this.SendForJsonAsync(request, cancellationToken);
    }

    public async Task<PicnicApiResponse> PostAsync(string path, object? body = null, bool includePicnicHeaders = false, CancellationToken cancellationToken = default)
    {
        using var request = this.CreateRequest(HttpMethod.Post, path, includePicnicHeaders, body);
        return await this.SendForJsonAsync(request, cancellationToken);
    }

    public async Task<PicnicApiResponse> PutAsync(string path, object? body = null, bool includePicnicHeaders = false, CancellationToken cancellationToken = default)
    {
        using var request = this.CreateRequest(HttpMethod.Put, path, includePicnicHeaders, body);
        return await this.SendForJsonAsync(request, cancellationToken);
    }

    public async Task<byte[]> GetBytesAsync(string absoluteOrRelativePath, CancellationToken cancellationToken = default)
    {
        string uri = absoluteOrRelativePath.StartsWith("http", StringComparison.OrdinalIgnoreCase)
            ? absoluteOrRelativePath
            : this.BuildUrl(absoluteOrRelativePath);

        using var response = await _httpClient.GetAsync(uri, cancellationToken);
        this.UpdateAuthFromResponse(response);

        if (!response.IsSuccessStatusCode)
        {
            throw new PicnicApiException($"Request failed with {(int)response.StatusCode} {response.ReasonPhrase}", (int)response.StatusCode);
        }

        return await response.Content.ReadAsByteArrayAsync(cancellationToken);
    }

    public string BuildImageUrl(string imageId, string size)
    {
        int apiIndex = _baseUrl.IndexOf("/api/", StringComparison.OrdinalIgnoreCase);
        string root = apiIndex > 0 ? _baseUrl[..apiIndex] : _baseUrl;
        return $"{root}/static/images/{imageId}/{size}.png";
    }

    private HttpRequestMessage CreateRequest(HttpMethod method, string path, bool includePicnicHeaders, object? body = null)
    {
        var request = new HttpRequestMessage(method, this.BuildUrl(path));

        if (includePicnicHeaders)
        {
            request.Headers.TryAddWithoutValidation("x-picnic-agent", _picnicAgent);
            request.Headers.TryAddWithoutValidation("x-picnic-did", _picnicDid);
        }

        if (body is not null)
        {
            string json = JsonSerializer.Serialize(body);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        }

        return request;
    }

    private async Task<PicnicApiResponse> SendForJsonAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        using var response = await _httpClient.SendAsync(request, cancellationToken);
        this.UpdateAuthFromResponse(response);

        string payload = await response.Content.ReadAsStringAsync(cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw CreateException(payload, (int)response.StatusCode, response.ReasonPhrase);
        }

        if (string.IsNullOrWhiteSpace(payload))
        {
            using var empty = JsonDocument.Parse("{}");
            return new PicnicApiResponse(empty.RootElement.Clone());
        }

        using var doc = JsonDocument.Parse(payload);
        ThrowIfAuthError(doc.RootElement);
        return new PicnicApiResponse(doc.RootElement.Clone());
    }

    private static Exception CreateException(string payload, int statusCode, string? reasonPhrase)
    {
        if (!string.IsNullOrWhiteSpace(payload))
        {
            try
            {
                using var doc = JsonDocument.Parse(payload);
                if (doc.RootElement.TryGetProperty("error", out var error) && error.TryGetProperty("message", out var messageElement))
                {
                    string message = messageElement.GetString() ?? "Picnic API request failed.";
                    if (ContainsAuthError(doc.RootElement))
                    {
                        return new PicnicAuthException(message);
                    }

                    return new PicnicApiException(message, statusCode);
                }
            }
            catch (JsonException)
            {
            }
        }

        return new PicnicApiException($"Request failed with {statusCode} {reasonPhrase}".Trim(), statusCode);
    }

    private static void ThrowIfAuthError(JsonElement root)
    {
        if (!ContainsAuthError(root))
        {
            return;
        }

        string message = "Picnic authentication error";
        if (root.TryGetProperty("error", out var error) && error.TryGetProperty("message", out var messageElement))
        {
            message = messageElement.GetString() ?? message;
        }

        throw new PicnicAuthException(message);
    }

    private static bool ContainsAuthError(JsonElement root)
    {
        if (root.ValueKind != JsonValueKind.Object || !root.TryGetProperty("error", out var error))
        {
            return false;
        }

        if (!error.TryGetProperty("code", out var code))
        {
            return false;
        }

        string? codeValue = code.GetString();
        return string.Equals(codeValue, "AUTH_ERROR", StringComparison.OrdinalIgnoreCase)
            || string.Equals(codeValue, "AUTH_INVALID_CRED", StringComparison.OrdinalIgnoreCase);
    }

    private void UpdateAuthFromResponse(HttpResponseMessage response)
    {
        if (!response.Headers.TryGetValues(AUTH_HEADER, out var values))
        {
            return;
        }

        string? token = values.FirstOrDefault();
        if (string.IsNullOrWhiteSpace(token) || string.Equals(token, this.AuthToken, StringComparison.Ordinal))
        {
            return;
        }

        this.AuthToken = token;

        _httpClient.DefaultRequestHeaders.Remove(AUTH_HEADER);
        _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(AUTH_HEADER, token);
    }

    private string BuildUrl(string path)
    {
        if (path.StartsWith("http", StringComparison.OrdinalIgnoreCase))
        {
            return path;
        }

        return path.StartsWith('/') ? $"{_baseUrl}{path}" : $"{_baseUrl}/{path}";
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
