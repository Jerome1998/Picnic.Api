using Picnic.Api.Models.Content;

namespace Picnic.Api.Services.Interfaces;

/// <summary>
/// Defines operations for retrieving static content pages.
/// </summary>
public interface IContentService
{
    /// <summary>
    /// Retrieves a static content page by identifier.
    /// </summary>
    /// <param name="pageId">The content page identifier.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The content page details.</returns>
    Task<ContentPage> GetPageAsync(string pageId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the FAQ content organized by categories.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>FAQ categories and items.</returns>
    Task<FaqResponse> GetFaqAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a specific FAQ item by identifier.
    /// </summary>
    /// <param name="faqItemId">The FAQ item identifier.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The FAQ item details.</returns>
    Task<FaqItem> GetFaqItemAsync(string faqItemId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the search empty state content.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>Search empty state content.</returns>
    Task<SearchEmptyStateContent> GetSearchEmptyStateAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of blog posts.
    /// </summary>
    /// <param name="offset">The pagination offset (default: 0).</param>
    /// <param name="limit">The maximum number of posts to return (default: 10).</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A paginated list of blog posts.</returns>
    Task<BlogPostListResponse> GetBlogPostsAsync(int offset = 0, int limit = 10, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a specific blog post by identifier.
    /// </summary>
    /// <param name="postId">The blog post identifier.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The blog post details.</returns>
    Task<BlogPost> GetBlogPostAsync(string postId, CancellationToken cancellationToken = default);
}
