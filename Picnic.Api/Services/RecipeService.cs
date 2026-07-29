using Picnic.Api.Internal;
using Picnic.Api.Models.Recipe;
using Picnic.Api.Services.Interfaces;

namespace Picnic.Api.Services;

internal sealed class RecipeService(PicnicHttpClient httpClient) : IRecipeService
{
    /// <summary>
    /// Retrieves a list of available recipes.
    /// </summary>
    /// <param name="offset">The pagination offset (default: 0).</param>
    /// <param name="limit">The maximum number of recipes to return (default: 20).</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A paginated list of recipe summaries.</returns>
    public async Task<RecipeBrowseResponse> GetRecipesAsync(int offset = 0, int limit = 20, CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync(
            $"/recipes?offset={offset}&limit={limit}",
            cancellationToken: cancellationToken)).DeserializeOrThrow<RecipeBrowseResponse>();

    /// <summary>
    /// Retrieves details for a specific recipe.
    /// </summary>
    /// <param name="recipeId">The recipe identifier.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The recipe details.</returns>
    public async Task<RecipeDetails> GetRecipeDetailsAsync(string recipeId, CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync(
            $"/recipes/{Uri.EscapeDataString(recipeId)}",
            cancellationToken: cancellationToken)).DeserializeOrThrow<RecipeDetails>();

    /// <summary>
    /// Retrieves a list of saved recipes.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A list of saved recipe identifiers.</returns>
    public async Task<SavedRecipesResponse> GetSavedRecipesAsync(CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync(
            "/recipes/saved",
            cancellationToken: cancellationToken)).DeserializeOrThrow<SavedRecipesResponse>();

    /// <summary>
    /// Saves a recipe for later viewing.
    /// </summary>
    /// <param name="recipeId">The recipe identifier.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task SaveRecipeAsync(string recipeId, CancellationToken cancellationToken = default)
    {
        var request = new SaveRecipeRequest { RecipeId = recipeId };
        await httpClient.PostAsync("/recipes/save", request, cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Removes a recipe from the saved list.
    /// </summary>
    /// <param name="recipeId">The recipe identifier.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task RemoveRecipeAsync(string recipeId, CancellationToken cancellationToken = default)
    {
        var request = new RemoveRecipeRequest { RecipeId = recipeId };
        await httpClient.PostAsync("/recipes/remove", request, cancellationToken: cancellationToken);
    }
}
