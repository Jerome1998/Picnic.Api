using System.Text.Json.Serialization;

namespace Picnic.Api.Models.UserOnboarding;

/// <summary>
/// Represents the request body for push subscription during onboarding.
/// </summary>
public sealed class SubscribePushRequest
{
    /// <summary>
    /// Gets the push topics to subscribe to.
    /// </summary>
    [JsonPropertyName("topics")]
    public required IReadOnlyList<string> Topics { get; init; }
}
