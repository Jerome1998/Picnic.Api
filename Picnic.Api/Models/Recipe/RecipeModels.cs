using System.Text.Json.Serialization;

namespace Picnic.Api.Models.Recipe;

/// <summary>
/// Represents a recipe in the Picnic catalog.
/// </summary>
public sealed class RecipeDetails
{
    /// <summary>
    /// Gets the recipe identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets the recipe title.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; init; }

    /// <summary>
    /// Gets the recipe description.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// Gets the recipe image URL.
    /// </summary>
    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; init; }

    /// <summary>
    /// Gets the preparation time in minutes.
    /// </summary>
    [JsonPropertyName("preparation_time_minutes")]
    public int? PreparationTimeMinutes { get; init; }

    /// <summary>
    /// Gets the cooking time in minutes.
    /// </summary>
    [JsonPropertyName("cooking_time_minutes")]
    public int? CookingTimeMinutes { get; init; }

    /// <summary>
    /// Gets the number of servings.
    /// </summary>
    [JsonPropertyName("servings")]
    public int? Servings { get; init; }

    /// <summary>
    /// Gets the difficulty level (e.g., "easy", "medium", "hard").
    /// </summary>
    [JsonPropertyName("difficulty")]
    public string? Difficulty { get; init; }

    /// <summary>
    /// Gets the recipe ingredients.
    /// </summary>
    [JsonPropertyName("ingredients")]
    public IReadOnlyList<RecipeIngredient>? Ingredients { get; init; }

    /// <summary>
    /// Gets the recipe instructions.
    /// </summary>
    [JsonPropertyName("instructions")]
    public string? Instructions { get; init; }

    /// <summary>
    /// Gets the recipe tags or categories.
    /// </summary>
    [JsonPropertyName("tags")]
    public IReadOnlyList<string>? Tags { get; init; }

    /// <summary>
    /// Gets whether the recipe is saved by the user.
    /// </summary>
    [JsonPropertyName("is_saved")]
    public bool? IsSaved { get; init; }
}

/// <summary>
/// Represents an ingredient in a recipe.
/// </summary>
public sealed class RecipeIngredient
{
    /// <summary>
    /// Gets the ingredient name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Gets the ingredient quantity.
    /// </summary>
    [JsonPropertyName("quantity")]
    public decimal? Quantity { get; init; }

    /// <summary>
    /// Gets the ingredient unit of measurement.
    /// </summary>
    [JsonPropertyName("unit")]
    public string? Unit { get; init; }

    /// <summary>
    /// Gets the product identifier for the ingredient, if available.
    /// </summary>
    [JsonPropertyName("product_id")]
    public string? ProductId { get; init; }
}

/// <summary>
/// Represents a recipe summary in a list.
/// </summary>
public sealed class RecipeSummary
{
    /// <summary>
    /// Gets the recipe identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets the recipe title.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; init; }

    /// <summary>
    /// Gets the recipe image URL.
    /// </summary>
    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; init; }

    /// <summary>
    /// Gets the recipe difficulty level.
    /// </summary>
    [JsonPropertyName("difficulty")]
    public string? Difficulty { get; init; }

    /// <summary>
    /// Gets whether the recipe is saved by the user.
    /// </summary>
    [JsonPropertyName("is_saved")]
    public bool? IsSaved { get; init; }
}

/// <summary>
/// Represents a request to save a recipe.
/// </summary>
public sealed class SaveRecipeRequest
{
    /// <summary>
    /// Gets or sets the recipe identifier.
    /// </summary>
    [JsonPropertyName("recipe_id")]
    public string? RecipeId { get; set; }
}

/// <summary>
/// Represents a request to remove a saved recipe.
/// </summary>
public sealed class RemoveRecipeRequest
{
    /// <summary>
    /// Gets or sets the recipe identifier.
    /// </summary>
    [JsonPropertyName("recipe_id")]
    public string? RecipeId { get; set; }
}

/// <summary>
/// Represents the response for recipe browsing.
/// </summary>
public sealed class RecipeBrowseResponse
{
    /// <summary>
    /// Gets the list of recipes.
    /// </summary>
    [JsonPropertyName("recipes")]
    public IReadOnlyList<RecipeSummary>? Recipes { get; init; }

    /// <summary>
    /// Gets the total number of available recipes.
    /// </summary>
    [JsonPropertyName("total")]
    public int? Total { get; init; }

    /// <summary>
    /// Gets the pagination offset.
    /// </summary>
    [JsonPropertyName("offset")]
    public int? Offset { get; init; }

    /// <summary>
    /// Gets the pagination limit.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; init; }
}

/// <summary>
/// Represents saved recipes response.
/// </summary>
public sealed class SavedRecipesResponse
{
    /// <summary>
    /// Gets the list of saved recipe identifiers.
    /// </summary>
    [JsonPropertyName("saved_recipe_ids")]
    public IReadOnlyList<string>? SavedRecipeIds { get; init; }
}
