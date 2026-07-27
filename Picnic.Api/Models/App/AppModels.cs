using System.Text.Json.Serialization;

namespace Picnic.Api.Models.App;

public sealed class DeeplinkResolution
{
    [JsonPropertyName("url")]
    public string? Url { get; init; }
}
