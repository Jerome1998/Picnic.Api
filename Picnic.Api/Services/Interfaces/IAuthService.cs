using Picnic.Api.Models.Auth;

namespace Picnic.Api.Services.Interfaces;

/// <summary>
/// Defines authentication operations for the Picnic API.
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Authenticates a user with username and password.
    /// </summary>
    /// <param name="username">The Picnic account username.</param>
    /// <param name="password">The Picnic account password.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The login result containing authentication details.</returns>
    Task<LoginResult> LoginAsync(string username, string password, CancellationToken cancellationToken = default);

    /// <summary>
    /// Requests a two-factor authentication code.
    /// </summary>
    /// <param name="channel">The channel used to send the verification code.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The API response payload for the code generation request.</returns>
    Task<object?> Generate2FaCodeAsync(TwoFactorChannel channel, CancellationToken cancellationToken = default);

    /// <summary>
    /// Verifies a previously received two-factor authentication code.
    /// </summary>
    /// <param name="code">The one-time verification code.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The verification result containing the authentication token.</returns>
    Task<Verify2FaResult> Verify2FaCodeAsync(string code, CancellationToken cancellationToken = default);

    /// <summary>
    /// Logs out the currently authenticated user.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The API response payload for the logout request.</returns>
    Task<object?> LogoutAsync(CancellationToken cancellationToken = default);
}
