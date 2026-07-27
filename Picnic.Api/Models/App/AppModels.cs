using System.Text.Json.Serialization;

namespace Picnic.Api.Models.App;

/// <summary>
/// Represents the result of resolving an app deeplink.
/// </summary>
public sealed class DeeplinkResolution
{
    /// <summary>
    /// Gets the resolved URL.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; init; }
}
