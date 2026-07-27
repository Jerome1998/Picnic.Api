using System.Text.Json;
using System.Text.Json.Serialization;

namespace Picnic.Api.Models.Common;

/// <summary>
/// Represents a quantity-based price tier.
/// </summary>
public sealed class PriceRange
{
    /// <summary>
    /// Gets the price for this quantity tier.
    /// </summary>
    [JsonPropertyName("price")]
    public int Price { get; init; }

    /// <summary>
    /// Gets the minimum quantity required for this price tier.
    /// </summary>
    [JsonPropertyName("from_quantity")]
    public int FromQuantity { get; init; }
}

/// <summary>
/// Represents a typed hyperlink returned by the API.
/// </summary>
public sealed class Link
{
    /// <summary>
    /// Gets the link type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// Gets the link target.
    /// </summary>
    [JsonPropertyName("href")]
    public string? Href { get; init; }
}

/// <summary>
/// Represents a UI decorator returned by the API.
/// </summary>
public sealed class Decorator
{
    /// <summary>
    /// Gets the decorator type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// Gets additional decorator data not mapped to explicit properties.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; init; }
}
