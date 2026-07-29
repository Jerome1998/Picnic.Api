using Picnic.Api.Models.Fusion;

namespace Picnic.Api.Services.Interfaces;

/// <summary>
/// Defines recipe browsing and meal-planner operations.
/// </summary>
public interface IRecipeService
{
    /// <summary>
    /// Returns the meals / meal-planner overview Fusion page.
    /// Recipe content inside this page is loaded lazily via SUSPENSE boundaries.
    /// To list the user's recipes, use <see cref="GetCookbookPageAsync"/>.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The meals page as a <see cref="FusionPage"/>.</returns>
    Task<FusionPage> GetRecipesPageAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the cookbook Fusion page, listing the user's recipes grouped by segment
    /// (e.g. saved recipes, user-defined recipes, new recipes, this week's recipes).
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The cookbook page as a <see cref="FusionPage"/>.</returns>
    Task<FusionPage> GetCookbookPageAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the detail Fusion page for a single recipe.
    /// Recipes are modelled as selling groups, so <paramref name="recipeId"/> is a
    /// <c>selling_group_id</c> (24 hex chars for catalog recipes, 32 for user-defined).
    /// </summary>
    /// <param name="recipeId">The recipe identifier (a selling group id).</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The recipe detail page as a <see cref="FusionPage"/>.</returns>
    Task<FusionPage> GetRecipeDetailsPageAsync(string recipeId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Saves a recipe to the user's saved recipes list by recording the current timestamp.
    /// </summary>
    /// <param name="recipeId">The recipe identifier to save.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task SaveRecipeAsync(string recipeId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes a recipe from the user's saved recipes list by setting the saved timestamp to <c>null</c>.
    /// </summary>
    /// <param name="recipeId">The recipe identifier to unsave.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task UnsaveRecipeAsync(string recipeId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Assigns a selling group (recipe bundle) to the basket in the meal planner.
    /// </summary>
    /// <param name="sellingGroupId">The selling group / recipe identifier.</param>
    /// <param name="dayOffset">Which delivery day to plan for, relative to the selected slot. <c>null</c> omits the field.</param>
    /// <param name="portions">Number of servings. <c>null</c> omits the field.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task AssignSellingGroupToBasketAsync(string sellingGroupId, int? dayOffset = null, int? portions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the number of portions for a selling group already in the basket.
    /// </summary>
    /// <param name="sellingGroupId">The selling group / recipe identifier.</param>
    /// <param name="dayOffset">The delivery day offset the recipe is planned for.</param>
    /// <param name="portions">The new number of servings.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task UpdateSellingGroupPortionsAsync(string sellingGroupId, int dayOffset, int portions, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes a selling group (recipe bundle) from the basket.
    /// </summary>
    /// <param name="sellingGroupId">The selling group / recipe identifier to remove.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task RemoveSellingGroupFromBasketAsync(string sellingGroupId, CancellationToken cancellationToken = default);
}

