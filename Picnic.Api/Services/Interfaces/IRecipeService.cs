using Picnic.Api.Models.Recipe;

namespace Picnic.Api.Services.Interfaces;

/// <summary>
/// Defines recipe browsing and management operations.
/// </summary>
public interface IRecipeService
{
    /// <summary>
    /// Retrieves a list of available recipes.
    /// </summary>
    /// <param name="offset">The pagination offset (default: 0).</param>
    /// <param name="limit">The maximum number of recipes to return (default: 20).</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A paginated list of recipe summaries.</returns>
    Task<RecipeBrowseResponse> GetRecipesAsync(int offset = 0, int limit = 20, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves details for a specific recipe.
    /// </summary>
    /// <param name="recipeId">The recipe identifier.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The recipe details.</returns>
    Task<RecipeDetails> GetRecipeDetailsAsync(string recipeId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of saved recipes.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A list of saved recipe identifiers.</returns>
    Task<SavedRecipesResponse> GetSavedRecipesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Saves a recipe for later viewing.
    /// </summary>
    /// <param name="recipeId">The recipe identifier.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task SaveRecipeAsync(string recipeId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes a recipe from the saved list.
    /// </summary>
    /// <param name="recipeId">The recipe identifier.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task RemoveRecipeAsync(string recipeId, CancellationToken cancellationToken = default);
}
