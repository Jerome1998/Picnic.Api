using System.Text.Json.Serialization;

namespace Picnic.Api.Models.Recipe;

/// <summary>
/// Represents the request body for saving or unsaving a recipe.
/// Both operations use the same endpoint; the <see cref="RecipeSavingPayload.SavedAt"/>
/// field distinguishes them: an ISO 8601 timestamp saves the recipe, <c>null</c> unsaves it.
/// </summary>
public sealed class RecipeSavingRequest
{
    /// <summary>
    /// Gets the task payload.
    /// </summary>
    [JsonPropertyName("payload")]
    public required RecipeSavingPayload Payload { get; init; }
}

/// <summary>
/// Represents the payload for a recipe save/unsave task.
/// </summary>
public sealed class RecipeSavingPayload
{
    /// <summary>
    /// Gets the recipe (selling group) identifier.
    /// </summary>
    [JsonPropertyName("recipe_id")]
    public required string RecipeId { get; init; }

    /// <summary>
    /// Gets the ISO 8601 timestamp at which the recipe was saved, or <c>null</c> to unsave.
    /// </summary>
    [JsonPropertyName("saved_at")]
    public string? SavedAt { get; init; }
}

/// <summary>
/// Represents the request body for assigning a selling group (recipe) to the basket.
/// </summary>
public sealed class AssignSellingGroupRequest
{
    /// <summary>
    /// Gets the task payload.
    /// </summary>
    [JsonPropertyName("payload")]
    public required AssignSellingGroupPayload Payload { get; init; }
}

/// <summary>
/// Represents the payload for assigning a selling group to the basket.
/// </summary>
public sealed class AssignSellingGroupPayload
{
    /// <summary>
    /// Gets the selling group (recipe) identifier.
    /// </summary>
    [JsonPropertyName("selling_group_id")]
    public required string SellingGroupId { get; init; }

    /// <summary>
    /// Gets the delivery day offset relative to the selected slot, if specified.
    /// </summary>
    [JsonPropertyName("day_offset")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? DayOffset { get; init; }

    /// <summary>
    /// Gets the number of servings to assign, if specified.
    /// </summary>
    [JsonPropertyName("portions")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Portions { get; init; }
}

/// <summary>
/// Represents the request body for updating the number of portions of a selling group in the basket.
/// </summary>
public sealed class UpdateSellingGroupPortionsRequest
{
    /// <summary>
    /// Gets the task payload.
    /// </summary>
    [JsonPropertyName("payload")]
    public required UpdateSellingGroupPortionsPayload Payload { get; init; }
}

/// <summary>
/// Represents the payload for updating the portions of a selling group.
/// </summary>
public sealed class UpdateSellingGroupPortionsPayload
{
    /// <summary>
    /// Gets the selling group (recipe) identifier.
    /// </summary>
    [JsonPropertyName("selling_group_id")]
    public required string SellingGroupId { get; init; }

    /// <summary>
    /// Gets the delivery day offset the recipe is planned for.
    /// </summary>
    [JsonPropertyName("day_offset")]
    public int DayOffset { get; init; }

    /// <summary>
    /// Gets the new number of servings.
    /// </summary>
    [JsonPropertyName("portions")]
    public int Portions { get; init; }
}

/// <summary>
/// Represents the request body for removing a selling group (recipe) from the basket.
/// </summary>
public sealed class RemoveSellingGroupRequest
{
    /// <summary>
    /// Gets the task payload.
    /// </summary>
    [JsonPropertyName("payload")]
    public required RemoveSellingGroupPayload Payload { get; init; }
}

/// <summary>
/// Represents the payload for removing a selling group from the basket.
/// </summary>
public sealed class RemoveSellingGroupPayload
{
    /// <summary>
    /// Gets the selling group (recipe) identifier to remove.
    /// </summary>
    [JsonPropertyName("selling_group_id")]
    public required string SellingGroupId { get; init; }
}
