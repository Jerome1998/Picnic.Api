using Picnic.Api.Internal;
using Picnic.Api.Models.Fusion;
using Picnic.Api.Models.Recipe;
using Picnic.Api.Services.Interfaces;

namespace Picnic.Api.Services;

internal sealed class RecipeService(PicnicHttpClient httpClient) : IRecipeService
{
    /// <summary>
    /// Returns the meals / meal-planner overview Fusion page.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The meals page as a <see cref="FusionPage"/>.</returns>
    public async Task<FusionPage> GetRecipesPageAsync(CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync("/pages/meals-page-root", includePicnicHeaders: true, cancellationToken: cancellationToken))
            .DeserializeOrThrow<FusionPage>();

    /// <summary>
    /// Returns the cookbook Fusion page, listing the user's recipes grouped by segment.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The cookbook page as a <see cref="FusionPage"/>.</returns>
    public async Task<FusionPage> GetCookbookPageAsync(CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync("/pages/cookbook-page-content", includePicnicHeaders: true, cancellationToken: cancellationToken))
            .DeserializeOrThrow<FusionPage>();

    /// <summary>
    /// Returns the detail Fusion page for a single recipe.
    /// </summary>
    /// <param name="recipeId">The recipe identifier (a selling group id).</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The recipe detail page as a <see cref="FusionPage"/>.</returns>
    public async Task<FusionPage> GetRecipeDetailsPageAsync(string recipeId, CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync(
            $"/pages/selling-group-details-page?selling_group_id={Uri.EscapeDataString(recipeId)}",
            includePicnicHeaders: true, cancellationToken: cancellationToken))
            .DeserializeOrThrow<FusionPage>();

    /// <summary>
    /// Saves a recipe to the user's saved recipes list by recording the current timestamp.
    /// </summary>
    /// <param name="recipeId">The recipe identifier to save.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task SaveRecipeAsync(string recipeId, CancellationToken cancellationToken = default)
    {
        var request = new RecipeSavingRequest
        {
            Payload = new RecipeSavingPayload
            {
                RecipeId = recipeId,
                SavedAt = DateTime.UtcNow.ToString("o"),
            }
        };
        await httpClient.PostAsync("/pages/task/recipe-saving", request, includePicnicHeaders: true, cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Removes a recipe from the user's saved recipes list by setting the saved timestamp to null.
    /// </summary>
    /// <param name="recipeId">The recipe identifier to unsave.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task UnsaveRecipeAsync(string recipeId, CancellationToken cancellationToken = default)
    {
        var request = new RecipeSavingRequest
        {
            Payload = new RecipeSavingPayload
            {
                RecipeId = recipeId,
                SavedAt = null,
            }
        };
        await httpClient.PostAsync("/pages/task/recipe-saving", request, includePicnicHeaders: true, cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Assigns a selling group (recipe bundle) to the basket in the meal planner.
    /// </summary>
    /// <param name="sellingGroupId">The selling group / recipe identifier.</param>
    /// <param name="dayOffset">Which delivery day to plan for, relative to the selected slot.</param>
    /// <param name="portions">Number of servings.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task AssignSellingGroupToBasketAsync(string sellingGroupId, int? dayOffset = null, int? portions = null, CancellationToken cancellationToken = default)
    {
        var request = new AssignSellingGroupRequest
        {
            Payload = new AssignSellingGroupPayload
            {
                SellingGroupId = sellingGroupId,
                DayOffset = dayOffset,
                Portions = portions,
            }
        };
        await httpClient.PostAsync("/pages/task/assign-selling-group-to-basket", request, includePicnicHeaders: true, cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Updates the number of portions for a selling group already in the basket.
    /// </summary>
    /// <param name="sellingGroupId">The selling group / recipe identifier.</param>
    /// <param name="dayOffset">The delivery day offset the recipe is planned for.</param>
    /// <param name="portions">The new number of servings.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task UpdateSellingGroupPortionsAsync(string sellingGroupId, int dayOffset, int portions, CancellationToken cancellationToken = default)
    {
        var request = new UpdateSellingGroupPortionsRequest
        {
            Payload = new UpdateSellingGroupPortionsPayload
            {
                SellingGroupId = sellingGroupId,
                DayOffset = dayOffset,
                Portions = portions,
            }
        };
        await httpClient.PostAsync("/pages/task/update-selling-group-number-of-portions-task", request, includePicnicHeaders: true, cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Removes a selling group (recipe bundle) from the basket.
    /// </summary>
    /// <param name="sellingGroupId">The selling group / recipe identifier to remove.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task RemoveSellingGroupFromBasketAsync(string sellingGroupId, CancellationToken cancellationToken = default)
    {
        var request = new RemoveSellingGroupRequest
        {
            Payload = new RemoveSellingGroupPayload
            {
                SellingGroupId = sellingGroupId,
            }
        };
        await httpClient.PostAsync("/pages/task/remove-selling-group-from-basket", request, includePicnicHeaders: true, cancellationToken: cancellationToken);
    }
}

