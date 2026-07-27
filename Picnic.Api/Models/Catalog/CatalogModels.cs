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

/// <summary>
/// Represents a search suggestion returned by the catalog.
/// </summary>
public sealed class SearchSuggestion
{
    /// <summary>
    /// Gets the suggestion type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// Gets the suggestion identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets the suggested search text.
    /// </summary>
    [JsonPropertyName("suggestion")]
    public string? Suggestion { get; init; }
}

/// <summary>
/// Represents an informational section on a product page.
/// </summary>
public sealed class ProductInfoSection
{
    /// <summary>
    /// Gets the section title.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; init; }

    /// <summary>
    /// Gets the section content.
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; init; }
}

/// <summary>
/// Represents a promotion associated with a product.
/// </summary>
public sealed class ProductPromotion
{
    /// <summary>
    /// Gets the promotion identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets the promotion label.
    /// </summary>
    [JsonPropertyName("label")]
    public string? Label { get; init; }
}

/// <summary>
/// Represents an item included in a product bundle.
/// </summary>
public sealed class BundleItem
{
    /// <summary>
    /// Gets the bundled item identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets the quantity included in the bundle.
    /// </summary>
    [JsonPropertyName("quantity")]
    public int Quantity { get; init; }

    /// <summary>
    /// Gets the unit price for the bundled item.
    /// </summary>
    [JsonPropertyName("pricePerUnit")]
    public int PricePerUnit { get; init; }

    /// <summary>
    /// Gets the image identifier for the bundled item.
    /// </summary>
    [JsonPropertyName("imageId")]
    public string? ImageId { get; init; }

    /// <summary>
    /// Gets the maximum quantity that can be purchased.
    /// </summary>
    [JsonPropertyName("maxCount")]
    public int MaxCount { get; init; }
}

/// <summary>
/// Represents a similar product suggestion.
/// </summary>
public sealed class SimilarProduct
{
    /// <summary>
    /// Gets the product identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets the product name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Gets the image identifier.
    /// </summary>
    [JsonPropertyName("imageId")]
    public string? ImageId { get; init; }

    /// <summary>
    /// Gets the displayed price.
    /// </summary>
    [JsonPropertyName("displayPrice")]
    public int DisplayPrice { get; init; }

    /// <summary>
    /// Gets the unit quantity label.
    /// </summary>
    [JsonPropertyName("unitQuantity")]
    public string? UnitQuantity { get; init; }

    /// <summary>
    /// Gets the maximum quantity that can be added.
    /// </summary>
    [JsonPropertyName("maxCount")]
    public int MaxCount { get; init; }

    /// <summary>
    /// Gets the deposit amount, when applicable.
    /// </summary>
    [JsonPropertyName("deposit")]
    public int? Deposit { get; init; }

    /// <summary>
    /// Gets the quantity-based price ranges.
    /// </summary>
    [JsonPropertyName("priceRanges")]
    public IReadOnlyList<PriceRange>? PriceRanges { get; init; }
}

/// <summary>
/// Represents detailed information for a product.
/// </summary>
public sealed class ProductDetails
{
    /// <summary>
    /// Gets the product identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets the product name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Gets the product brand.
    /// </summary>
    [JsonPropertyName("brand")]
    public string? Brand { get; init; }

    /// <summary>
    /// Gets the unit quantity label.
    /// </summary>
    [JsonPropertyName("unitQuantity")]
    public string? UnitQuantity { get; init; }

    /// <summary>
    /// Gets the formatted unit price.
    /// </summary>
    [JsonPropertyName("unitPrice")]
    public string? UnitPrice { get; init; }

    /// <summary>
    /// Gets the displayed product price.
    /// </summary>
    [JsonPropertyName("displayPrice")]
    public int DisplayPrice { get; init; }

    /// <summary>
    /// Gets the maximum quantity that can be added.
    /// </summary>
    [JsonPropertyName("maxCount")]
    public int MaxCount { get; init; }

    /// <summary>
    /// Gets the image identifiers for the product.
    /// </summary>
    [JsonPropertyName("imageIds")]
    public IReadOnlyList<string>? ImageIds { get; init; }

    /// <summary>
    /// Gets the product description.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// Gets the product highlights.
    /// </summary>
    [JsonPropertyName("highlights")]
    public IReadOnlyList<string>? Highlights { get; init; }

    /// <summary>
    /// Gets the allergen information.
    /// </summary>
    [JsonPropertyName("allergens")]
    public IReadOnlyList<string>? Allergens { get; init; }

    /// <summary>
    /// Gets additional informational sections for the product.
    /// </summary>
    [JsonPropertyName("infoSections")]
    public IReadOnlyList<ProductInfoSection>? InfoSections { get; init; }

    /// <summary>
    /// Gets the promotion applied to the product.
    /// </summary>
    [JsonPropertyName("promotion")]
    public ProductPromotion? Promotion { get; init; }

    /// <summary>
    /// Gets the bundle items available for the product.
    /// </summary>
    [JsonPropertyName("bundles")]
    public IReadOnlyList<BundleItem>? Bundles { get; init; }

    /// <summary>
    /// Gets the quantity-based price ranges for the product.
    /// </summary>
    [JsonPropertyName("priceRanges")]
    public IReadOnlyList<PriceRange>? PriceRanges { get; init; }

    /// <summary>
    /// Gets similar product suggestions.
    /// </summary>
    [JsonPropertyName("similarProducts")]
    public IReadOnlyList<SimilarProduct>? SimilarProducts { get; init; }
}

/// <summary>
/// Represents a sellable unit in the catalog.
/// </summary>
public sealed class SellingUnit
{
    /// <summary>
    /// Gets the selling unit identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets the selling unit name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Gets the image identifier.
    /// </summary>
    [JsonPropertyName("image_id")]
    public string? ImageId { get; init; }

    /// <summary>
    /// Gets the displayed price.
    /// </summary>
    [JsonPropertyName("display_price")]
    public int DisplayPrice { get; init; }

    /// <summary>
    /// Gets the unit quantity label.
    /// </summary>
    [JsonPropertyName("unit_quantity")]
    public string? UnitQuantity { get; init; }

    /// <summary>
    /// Gets the maximum quantity that can be added.
    /// </summary>
    [JsonPropertyName("max_count")]
    public int MaxCount { get; init; }

    /// <summary>
    /// Gets decorators applied to the selling unit.
    /// </summary>
    [JsonPropertyName("decorators")]
    public IReadOnlyList<Decorator>? Decorators { get; init; }

    /// <summary>
    /// Gets the quantity-based price ranges.
    /// </summary>
    [JsonPropertyName("price_ranges")]
    public IReadOnlyList<PriceRange>? PriceRanges { get; init; }
}
