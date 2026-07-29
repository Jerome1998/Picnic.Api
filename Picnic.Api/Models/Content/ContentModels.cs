using System.Text.Json.Serialization;

namespace Picnic.Api.Models.Content;

/// <summary>
/// Represents a static content page.
/// </summary>
public sealed class ContentPage
{
    /// <summary>
    /// Gets the content page identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets the page title.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; init; }

    /// <summary>
    /// Gets the page content in HTML format.
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; init; }

    /// <summary>
    /// Gets the page type (e.g., "faq", "help", "about").
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// Gets the language code for the content.
    /// </summary>
    [JsonPropertyName("language")]
    public string? Language { get; init; }

    /// <summary>
    /// Gets the last update timestamp.
    /// </summary>
    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; init; }
}

/// <summary>
/// Represents a FAQ item.
/// </summary>
public sealed class FaqItem
{
    /// <summary>
    /// Gets the FAQ item identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets the question text.
    /// </summary>
    [JsonPropertyName("question")]
    public string? Question { get; init; }

    /// <summary>
    /// Gets the answer text.
    /// </summary>
    [JsonPropertyName("answer")]
    public string? Answer { get; init; }

    /// <summary>
    /// Gets the category this FAQ belongs to.
    /// </summary>
    [JsonPropertyName("category")]
    public string? Category { get; init; }

    /// <summary>
    /// Gets the order/priority of this FAQ item.
    /// </summary>
    [JsonPropertyName("order")]
    public int? Order { get; init; }
}

/// <summary>
/// Represents a FAQ category with items.
/// </summary>
public sealed class FaqCategory
{
    /// <summary>
    /// Gets the category identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets the category name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Gets the FAQ items in this category.
    /// </summary>
    [JsonPropertyName("items")]
    public IReadOnlyList<FaqItem>? Items { get; init; }

    /// <summary>
    /// Gets the order/priority of this category.
    /// </summary>
    [JsonPropertyName("order")]
    public int? Order { get; init; }
}

/// <summary>
/// Represents a response containing FAQ data.
/// </summary>
public sealed class FaqResponse
{
    /// <summary>
    /// Gets the list of FAQ categories.
    /// </summary>
    [JsonPropertyName("categories")]
    public IReadOnlyList<FaqCategory>? Categories { get; init; }
}

/// <summary>
/// Represents search empty state content.
/// </summary>
public sealed class SearchEmptyStateContent
{
    /// <summary>
    /// Gets the title shown when search returns no results.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; init; }

    /// <summary>
    /// Gets the subtitle/description shown when search returns no results.
    /// </summary>
    [JsonPropertyName("subtitle")]
    public string? Subtitle { get; init; }

    /// <summary>
    /// Gets suggested search terms to try.
    /// </summary>
    [JsonPropertyName("suggestions")]
    public IReadOnlyList<string>? Suggestions { get; init; }

    /// <summary>
    /// Gets the URL to an image or icon for empty state.
    /// </summary>
    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; init; }
}

/// <summary>
/// Represents a blog post or news article.
/// </summary>
public sealed class BlogPost
{
    /// <summary>
    /// Gets the blog post identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets the post title.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; init; }

    /// <summary>
    /// Gets the post excerpt/summary.
    /// </summary>
    [JsonPropertyName("excerpt")]
    public string? Excerpt { get; init; }

    /// <summary>
    /// Gets the full post content.
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; init; }

    /// <summary>
    /// Gets the post author name.
    /// </summary>
    [JsonPropertyName("author")]
    public string? Author { get; init; }

    /// <summary>
    /// Gets the publication date.
    /// </summary>
    [JsonPropertyName("published_at")]
    public DateTime? PublishedAt { get; init; }

    /// <summary>
    /// Gets the featured image URL.
    /// </summary>
    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; init; }

    /// <summary>
    /// Gets the blog post categories/tags.
    /// </summary>
    [JsonPropertyName("tags")]
    public IReadOnlyList<string>? Tags { get; init; }
}

/// <summary>
/// Represents a response containing a list of blog posts.
/// </summary>
public sealed class BlogPostListResponse
{
    /// <summary>
    /// Gets the list of blog posts.
    /// </summary>
    [JsonPropertyName("posts")]
    public IReadOnlyList<BlogPost>? Posts { get; init; }

    /// <summary>
    /// Gets the total number of blog posts available.
    /// </summary>
    [JsonPropertyName("total")]
    public int? Total { get; init; }
}
