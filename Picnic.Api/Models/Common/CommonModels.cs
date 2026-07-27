using System.Text.Json;
using System.Text.Json.Serialization;

namespace Picnic.Api.Models.Common;

public sealed class PriceRange
{
    [JsonPropertyName("price")]
    public int Price { get; init; }

    [JsonPropertyName("from_quantity")]
    public int FromQuantity { get; init; }
}

public sealed class Link
{
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("href")]
    public string? Href { get; init; }
}

public sealed class Decorator
{
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; init; }
}
