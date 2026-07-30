using Picnic.Api.Models.Content;

namespace Picnic.Api.Services.Interfaces;

/// <summary>
/// Defines operations for retrieving static content pages.
/// </summary>
public interface IContentService
{
    /// <summary>
    /// Returns the FAQ content page in PML format.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The FAQ content payload.</returns>
    Task<ContentPml> GetFaqContentAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the content shown on the search empty-state screen in PML format.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The search empty-state content payload.</returns>
    Task<ContentPml> GetSearchEmptyStateAsync(CancellationToken cancellationToken = default);
}
