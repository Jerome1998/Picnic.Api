using Picnic.Api.Models.Catalog;
using Picnic.Api.Models.Fusion;

namespace Picnic.Api.Services.Interfaces;

/// <summary>
/// Defines catalog and product discovery operations.
/// </summary>
public interface ICatalogService
{
    /// <summary>
    /// Searches the catalog for selling units matching a query.
    /// </summary>
    /// <param name="query">The search query text.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A list of matching selling units.</returns>
    Task<IReadOnlyList<SellingUnit>> SearchAsync(string query, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves search suggestions for a query.
    /// </summary>
    /// <param name="query">The partial search query text.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A list of search suggestions.</returns>
    Task<IReadOnlyList<SearchSuggestion>> GetSuggestionsAsync(string query, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the product details page for a product.
    /// </summary>
    /// <param name="productId">The product identifier.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The Fusion product details page.</returns>
    Task<FusionPage> GetProductDetailsPageAsync(string productId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Downloads a product image.
    /// </summary>
    /// <param name="imageId">The image identifier.</param>
    /// <param name="size">The requested image size.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The image data as a byte array.</returns>
    Task<byte[]> GetImageAsync(string imageId, ImageSize size, CancellationToken cancellationToken = default);
}
