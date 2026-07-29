using System.Text.Json.Serialization;

namespace Picnic.Api.Models.UserOnboarding;

/// <summary>
/// Represents information about a household.
/// </summary>
public sealed class HouseholdInfo
{
    /// <summary>
    /// Gets the household identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets the household name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Gets the number of members in the household.
    /// </summary>
    [JsonPropertyName("member_count")]
    public int? MemberCount { get; init; }

    /// <summary>
    /// Gets the household type (e.g., "household", "family", "couples").
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// Gets the primary address of the household.
    /// </summary>
    [JsonPropertyName("address")]
    public string? Address { get; init; }

    /// <summary>
    /// Gets the zip code.
    /// </summary>
    [JsonPropertyName("zip_code")]
    public string? ZipCode { get; init; }

    /// <summary>
    /// Gets the city.
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; init; }

    /// <summary>
    /// Gets the creation date of the household.
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; init; }
}

/// <summary>
/// Represents business/company information for onboarding.
/// </summary>
public sealed class BusinessInfo
{
    /// <summary>
    /// Gets the business identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets the business name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Gets the business type (e.g., "restaurant", "office", "retail").
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// Gets the business registration number.
    /// </summary>
    [JsonPropertyName("registration_number")]
    public string? RegistrationNumber { get; init; }

    /// <summary>
    /// Gets the business address.
    /// </summary>
    [JsonPropertyName("address")]
    public string? Address { get; init; }

    /// <summary>
    /// Gets the business email.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; init; }

    /// <summary>
    /// Gets the business phone number.
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; init; }

    /// <summary>
    /// Gets the industry/sector.
    /// </summary>
    [JsonPropertyName("industry")]
    public string? Industry { get; init; }
}

/// <summary>
/// Represents push notification subscription settings.
/// </summary>
public sealed class PushSubscription
{
    /// <summary>
    /// Gets the subscription identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets the push notification categories the user is subscribed to.
    /// </summary>
    [JsonPropertyName("subscribed_categories")]
    public IReadOnlyList<string>? SubscribedCategories { get; init; }

    /// <summary>
    /// Gets whether the user has opted in to marketing communications.
    /// </summary>
    [JsonPropertyName("marketing_opted_in")]
    public bool? MarketingOptedIn { get; init; }

    /// <summary>
    /// Gets whether the user has opted in to order notifications.
    /// </summary>
    [JsonPropertyName("order_notifications_enabled")]
    public bool? OrderNotificationsEnabled { get; init; }

    /// <summary>
    /// Gets whether the user has opted in to promotional notifications.
    /// </summary>
    [JsonPropertyName("promotional_enabled")]
    public bool? PromotionalEnabled { get; init; }

    /// <summary>
    /// Gets the timestamp of the last subscription update.
    /// </summary>
    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; init; }
}

/// <summary>
/// Represents onboarding status for a user.
/// </summary>
public sealed class OnboardingStatus
{
    /// <summary>
    /// Gets whether the user has completed email verification.
    /// </summary>
    [JsonPropertyName("email_verified")]
    public bool? EmailVerified { get; init; }

    /// <summary>
    /// Gets whether the user has completed phone verification.
    /// </summary>
    [JsonPropertyName("phone_verified")]
    public bool? PhoneVerified { get; init; }

    /// <summary>
    /// Gets whether the user has set up household information.
    /// </summary>
    [JsonPropertyName("household_setup")]
    public bool? HouseholdSetup { get; init; }

    /// <summary>
    /// Gets whether the user has set up payment method.
    /// </summary>
    [JsonPropertyName("payment_setup")]
    public bool? PaymentSetup { get; init; }

    /// <summary>
    /// Gets whether the user has agreed to terms and conditions.
    /// </summary>
    [JsonPropertyName("terms_accepted")]
    public bool? TermsAccepted { get; init; }

    /// <summary>
    /// Gets the onboarding completion percentage.
    /// </summary>
    [JsonPropertyName("completion_percentage")]
    public int? CompletionPercentage { get; init; }

    /// <summary>
    /// Gets the list of remaining onboarding steps.
    /// </summary>
    [JsonPropertyName("remaining_steps")]
    public IReadOnlyList<string>? RemainingSteps { get; init; }
}

/// <summary>
/// Represents a request to update household information.
/// </summary>
public sealed class UpdateHouseholdRequest
{
    /// <summary>
    /// Gets or sets the household name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the household type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Gets or sets the household address.
    /// </summary>
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    /// <summary>
    /// Gets or sets the zip code.
    /// </summary>
    [JsonPropertyName("zip_code")]
    public string? ZipCode { get; set; }

    /// <summary>
    /// Gets or sets the city.
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>
    /// Gets or sets the number of members.
    /// </summary>
    [JsonPropertyName("member_count")]
    public int? MemberCount { get; set; }
}

/// <summary>
/// Represents a request to update business information.
/// </summary>
public sealed class UpdateBusinessRequest
{
    /// <summary>
    /// Gets or sets the business name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the business type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Gets or sets the business registration number.
    /// </summary>
    [JsonPropertyName("registration_number")]
    public string? RegistrationNumber { get; set; }

    /// <summary>
    /// Gets or sets the business address.
    /// </summary>
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    /// <summary>
    /// Gets or sets the business email.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Gets or sets the business phone number.
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// Gets or sets the industry/sector.
    /// </summary>
    [JsonPropertyName("industry")]
    public string? Industry { get; set; }
}

/// <summary>
/// Represents a request to update push notification settings.
/// </summary>
public sealed class UpdatePushSubscriptionRequest
{
    /// <summary>
    /// Gets or sets whether to opt in to marketing communications.
    /// </summary>
    [JsonPropertyName("marketing_opted_in")]
    public bool? MarketingOptedIn { get; set; }

    /// <summary>
    /// Gets or sets whether to enable order notifications.
    /// </summary>
    [JsonPropertyName("order_notifications_enabled")]
    public bool? OrderNotificationsEnabled { get; set; }

    /// <summary>
    /// Gets or sets whether to enable promotional notifications.
    /// </summary>
    [JsonPropertyName("promotional_enabled")]
    public bool? PromotionalEnabled { get; set; }

    /// <summary>
    /// Gets or sets the push notification categories to subscribe to.
    /// </summary>
    [JsonPropertyName("subscribed_categories")]
    public IReadOnlyList<string>? SubscribedCategories { get; set; }
}
