using System.Text.Json.Serialization;

namespace Picnic.Api.Models.Auth;

/// <summary>
/// Represents the channel used for two-factor authentication.
/// </summary>
public enum TwoFactorChannel
{
    /// <summary>
    /// Send the verification code via SMS.
    /// </summary>
    Sms,

    /// <summary>
    /// Send the verification code via email.
    /// </summary>
    Email
}

/// <summary>
/// Represents the result of a login request.
/// </summary>
public sealed class LoginResult
{
    /// <summary>
    /// Gets the authenticated user identifier.
    /// </summary>
    [JsonPropertyName("user_id")]
    public string? UserId { get; init; }

    /// <summary>
    /// Gets a value indicating whether second-factor authentication is required.
    /// </summary>
    [JsonPropertyName("second_factor_authentication_required")]
    public bool SecondFactorAuthenticationRequired { get; init; }

    /// <summary>
    /// Gets a value indicating whether the two-factor introduction screen should be shown.
    /// </summary>
    [JsonPropertyName("show_second_factor_authentication_intro")]
    public bool ShowSecondFactorAuthenticationIntro { get; init; }

    /// <summary>
    /// Gets the authentication key returned by the API.
    /// </summary>
    [JsonPropertyName("authKey")]
    public string? AuthKey { get; init; }
}

/// <summary>
/// Represents the result of verifying a two-factor authentication challenge.
/// </summary>
public sealed class Verify2FaResult
{
    /// <summary>
    /// Gets the authentication key returned after successful verification.
    /// </summary>
    [JsonPropertyName("authKey")]
    public string? AuthKey { get; init; }
}
