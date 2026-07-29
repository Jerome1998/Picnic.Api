using Picnic.Api.Internal;
using Picnic.Api.Models.Content;
using Picnic.Api.Services.Interfaces;

namespace Picnic.Api.Services;

internal sealed class ContentService(PicnicHttpClient httpClient) : IContentService
{
    /// <summary>
    /// Retrieves a static content page by identifier.
    /// </summary>
    /// <param name="pageId">The content page identifier.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The content page details.</returns>
    public async Task<ContentPage> GetPageAsync(string pageId, CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync(
            $"/content/pages/{Uri.EscapeDataString(pageId)}",
            cancellationToken: cancellationToken)).DeserializeOrThrow<ContentPage>();

    /// <summary>
    /// Retrieves the FAQ content organized by categories.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>FAQ categories and items.</returns>
    public async Task<FaqResponse> GetFaqAsync(CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync(
            "/content/faq",
            cancellationToken: cancellationToken)).DeserializeOrThrow<FaqResponse>();

    /// <summary>
    /// Retrieves a specific FAQ item by identifier.
    /// </summary>
    /// <param name="faqItemId">The FAQ item identifier.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The FAQ item details.</returns>
    public async Task<FaqItem> GetFaqItemAsync(string faqItemId, CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync(
            $"/content/faq/{Uri.EscapeDataString(faqItemId)}",
            cancellationToken: cancellationToken)).DeserializeOrThrow<FaqItem>();

    /// <summary>
    /// Retrieves the search empty state content.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>Search empty state content.</returns>
    public async Task<SearchEmptyStateContent> GetSearchEmptyStateAsync(CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync(
            "/content/search-empty-state",
            cancellationToken: cancellationToken)).DeserializeOrThrow<SearchEmptyStateContent>();

    /// <summary>
    /// Retrieves a list of blog posts.
    /// </summary>
    /// <param name="offset">The pagination offset (default: 0).</param>
    /// <param name="limit">The maximum number of posts to return (default: 10).</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A paginated list of blog posts.</returns>
    public async Task<BlogPostListResponse> GetBlogPostsAsync(int offset = 0, int limit = 10, CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync(
            $"/content/blog?offset={offset}&limit={limit}",
            cancellationToken: cancellationToken)).DeserializeOrThrow<BlogPostListResponse>();

    /// <summary>
    /// Retrieves a specific blog post by identifier.
    /// </summary>
    /// <param name="postId">The blog post identifier.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The blog post details.</returns>
    public async Task<BlogPost> GetBlogPostAsync(string postId, CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync(
            $"/content/blog/{Uri.EscapeDataString(postId)}",
            cancellationToken: cancellationToken)).DeserializeOrThrow<BlogPost>();
}
