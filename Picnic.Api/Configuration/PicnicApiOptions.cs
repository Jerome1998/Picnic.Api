namespace Picnic.Api.Configuration;

/// <summary>
/// Represents configuration options for <c>PicnicClient</c>.
/// </summary>
public sealed class PicnicApiOptions
{
    /// <summary>
    /// The default country code used for API requests.
    /// </summary>
    public const string DefaultCountryCode = "NL";

    /// <summary>
    /// The default Picnic API version.
    /// </summary>
    public const string DefaultApiVersion = "15";

    /// <summary>
    /// Gets the country code used to resolve the default API base URL.
    /// </summary>
    public string CountryCode { get; init; } = DefaultCountryCode;

    /// <summary>
    /// Gets the API version used to resolve the default API base URL.
    /// </summary>
    public string ApiVersion { get; init; } = DefaultApiVersion;

    /// <summary>
    /// The default value used for the <c>x-picnic-agent</c> request header.
    /// </summary>
    public const string DefaultPicnicAgent = "30100;1.228.1-15480;";

    /// <summary>
    /// The default value used for the <c>x-picnic-did</c> request header.
    /// </summary>
    public const string DefaultPicnicDid = "3C417201548B2E3B";

    /// <summary>
    /// Gets the value used for the <c>x-picnic-agent</c> request header.
    /// </summary>
    public string PicnicAgent { get; init; } = DefaultPicnicAgent;

    /// <summary>
    /// Gets the value used for the <c>x-picnic-did</c> request header.
    /// </summary>
    public string PicnicDid { get; init; } = DefaultPicnicDid;

    /// <summary>
    /// Gets the initial authentication token.
    /// </summary>
    public string? AuthToken { get; init; }

    /// <summary>
    /// Gets a custom API base URL. When not set, the default Picnic URL is derived from <see cref="CountryCode"/> and <see cref="ApiVersion"/>.
    /// </summary>
    public string? BaseUrl { get; init; }

    internal string ResolveBaseUrl()
    {
        if (!string.IsNullOrWhiteSpace(this.BaseUrl))
        {
            return this.BaseUrl.TrimEnd('/');
        }

        return $"https://storefront-prod.{this.CountryCode.ToLowerInvariant()}.picnicinternational.com/api/{this.ApiVersion}";
    }
}
