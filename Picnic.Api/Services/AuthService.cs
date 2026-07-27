using Picnic.Api.Internal;
using Picnic.Api.Models.Auth;
using Picnic.Api.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Picnic.Api.Services;

internal sealed class AuthService(PicnicHttpClient httpClient) : IAuthService
{
    public async Task<LoginResult> LoginAsync(string username, string password, CancellationToken cancellationToken = default)
    {
        string secret = Convert.ToHexString(MD5.HashData(Encoding.UTF8.GetBytes(password))).ToLowerInvariant();
        var response = await httpClient.PostAsync("/user/login", new
        {
            key = username,
            secret,
            client_id = 30100
        }, cancellationToken: cancellationToken);

        var result = response.DeserializeOrThrow<LoginResult>();
        if (!string.IsNullOrWhiteSpace(httpClient.AuthToken))
        {
            result = new LoginResult
            {
                UserId = result.UserId,
                SecondFactorAuthenticationRequired = result.SecondFactorAuthenticationRequired,
                ShowSecondFactorAuthenticationIntro = result.ShowSecondFactorAuthenticationIntro,
                AuthKey = httpClient.AuthToken
            };
        }

        return result;
    }

    public async Task<object?> Generate2FaCodeAsync(TwoFactorChannel channel, CancellationToken cancellationToken = default)
    {
        string channelValue = channel.ToString().ToUpperInvariant();
        var response = await httpClient.PostAsync("/user/2fa/generate", new { channel = channelValue }, includePicnicHeaders: true, cancellationToken: cancellationToken);
        return response.Deserialize<object>();
    }

    public async Task<Verify2FaResult> Verify2FaCodeAsync(string code, CancellationToken cancellationToken = default)
    {
        await httpClient.PostAsync("/user/2fa/verify", new { otp = code }, includePicnicHeaders: true, cancellationToken: cancellationToken);
        return new Verify2FaResult { AuthKey = httpClient.AuthToken };
    }

    public async Task<object?> LogoutAsync(CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsync("/user/logout", cancellationToken: cancellationToken);
        return response.Deserialize<object>();
    }
}
