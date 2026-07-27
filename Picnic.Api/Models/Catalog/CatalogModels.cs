using Picnic.Api.Models.Common;
using System.Text.Json.Serialization;

namespace Picnic.Api.Models.Catalog;

/// <summary>
/// Represents supported image size options for catalog images.
/// </summary>
public enum ImageSize
{
    /// <summary>
    /// Tiny image variant.
    /// </summary>
    Tiny,

    /// <summary>
    /// Small image variant.
    /// </summary>
    Small,

    /// <summary>
    /// Medium image variant.
    /// </summary>
    Medium,

    /// <summary>
    /// Large image variant.
    /// </summary>
    Large,

    /// <summary>
    /// Extra-large image variant.
    /// </summary>
    ExtraLarge
}

public sealed class SearchSuggestion
{
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("suggestion")]
    public string? Suggestion { get; init; }
}

public sealed class ProductInfoSection
{
    [JsonPropertyName("title")]
    public string? Title { get; init; }

    [JsonPropertyName("content")]
    public string? Content { get; init; }
}

public sealed class ProductPromotion
{
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("label")]
    public string? Label { get; init; }
}

public sealed class BundleItem
{
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; init; }

    [JsonPropertyName("pricePerUnit")]
    public int PricePerUnit { get; init; }

    [JsonPropertyName("imageId")]
    public string? ImageId { get; init; }

    [JsonPropertyName("maxCount")]
    public int MaxCount { get; init; }
}

public sealed class SimilarProduct
{
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("imageId")]
    public string? ImageId { get; init; }

    [JsonPropertyName("displayPrice")]
    public int DisplayPrice { get; init; }

    [JsonPropertyName("unitQuantity")]
    public string? UnitQuantity { get; init; }

    [JsonPropertyName("maxCount")]
    public int MaxCount { get; init; }

    [JsonPropertyName("deposit")]
    public int? Deposit { get; init; }

    [JsonPropertyName("priceRanges")]
    public IReadOnlyList<PriceRange>? PriceRanges { get; init; }
}

public sealed class ProductDetails
{
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("brand")]
    public string? Brand { get; init; }

    [JsonPropertyName("unitQuantity")]
    public string? UnitQuantity { get; init; }

    [JsonPropertyName("unitPrice")]
    public string? UnitPrice { get; init; }

    [JsonPropertyName("displayPrice")]
    public int DisplayPrice { get; init; }

    [JsonPropertyName("maxCount")]
    public int MaxCount { get; init; }

    [JsonPropertyName("imageIds")]
    public IReadOnlyList<string>? ImageIds { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("highlights")]
    public IReadOnlyList<string>? Highlights { get; init; }

    [JsonPropertyName("allergens")]
    public IReadOnlyList<string>? Allergens { get; init; }

    [JsonPropertyName("infoSections")]
    public IReadOnlyList<ProductInfoSection>? InfoSections { get; init; }

    [JsonPropertyName("promotion")]
    public ProductPromotion? Promotion { get; init; }

    [JsonPropertyName("bundles")]
    public IReadOnlyList<BundleItem>? Bundles { get; init; }

    [JsonPropertyName("priceRanges")]
    public IReadOnlyList<PriceRange>? PriceRanges { get; init; }

    [JsonPropertyName("similarProducts")]
    public IReadOnlyList<SimilarProduct>? SimilarProducts { get; init; }
}

public sealed class SellingUnit
{
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("image_id")]
    public string? ImageId { get; init; }

    [JsonPropertyName("display_price")]
    public int DisplayPrice { get; init; }

    [JsonPropertyName("unit_quantity")]
    public string? UnitQuantity { get; init; }

    [JsonPropertyName("max_count")]
    public int MaxCount { get; init; }

    [JsonPropertyName("decorators")]
    public IReadOnlyList<Decorator>? Decorators { get; init; }

    [JsonPropertyName("price_ranges")]
    public IReadOnlyList<PriceRange>? PriceRanges { get; init; }
}
