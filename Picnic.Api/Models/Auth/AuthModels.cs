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

public sealed class LoginResult
{
    [JsonPropertyName("user_id")]
    public string? UserId { get; init; }

    [JsonPropertyName("second_factor_authentication_required")]
    public bool SecondFactorAuthenticationRequired { get; init; }

    [JsonPropertyName("show_second_factor_authentication_intro")]
    public bool ShowSecondFactorAuthenticationIntro { get; init; }

    [JsonPropertyName("authKey")]
    public string? AuthKey { get; init; }
}

public sealed class Verify2FaResult
{
    [JsonPropertyName("authKey")]
    public string? AuthKey { get; init; }
}
