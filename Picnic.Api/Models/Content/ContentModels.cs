using Picnic.Api.Models.Fusion;
using System.Text.Json.Serialization;

namespace Picnic.Api.Models.Content;

/// <summary>
/// Represents a PML content document returned by the Content service.
/// </summary>
public sealed class ContentPml
{
    /// <summary>
    /// Gets the PML version.
    /// </summary>
    [JsonPropertyName("pml_version")]
    public string? PmlVersion { get; init; }

    /// <summary>
    /// Gets the root Fusion component.
    /// </summary>
    [JsonPropertyName("component")]
    public Component? Component { get; init; }

    /// <summary>
    /// Gets the image mapping used by the content payload.
    /// </summary>
    [JsonPropertyName("images")]
    public Dictionary<string, string>? Images { get; init; }

    /// <summary>
    /// Gets tracking attributes associated with the content payload.
    /// </summary>
    [JsonPropertyName("tracking_attributes")]
    public TrackingAttributes? TrackingAttributes { get; init; }
}
