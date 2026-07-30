using Picnic.Api.Internal;
using Picnic.Api.Models.Content;
using Picnic.Api.Services.Interfaces;

namespace Picnic.Api.Services;

internal sealed class ContentService(PicnicHttpClient httpClient) : IContentService
{
    /// <summary>
    /// Returns the FAQ content page in PML format.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The FAQ content payload.</returns>
    public async Task<ContentPml> GetFaqContentAsync(CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync("/content/faq", includePicnicHeaders: true, cancellationToken: cancellationToken))
            .DeserializeOrThrow<ContentPml>();

    /// <summary>
    /// Returns the content shown on the search empty-state screen in PML format.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The search empty-state content payload.</returns>
    public async Task<ContentPml> GetSearchEmptyStateAsync(CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync("/content/search_empty_state", includePicnicHeaders: true, cancellationToken: cancellationToken))
            .DeserializeOrThrow<ContentPml>();
}
