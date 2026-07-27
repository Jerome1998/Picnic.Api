using System.Text.Json.Serialization;

namespace Picnic.Api.Models.User;

/// <summary>
/// Represents business-related user details.
/// </summary>
public sealed class BusinessDetails
{
    /// <summary>
    /// Gets the business name.
    /// </summary>
    [JsonPropertyName("business_name")]
    public string? BusinessName { get; init; }

    /// <summary>
    /// Gets the business registration number.
    /// </summary>
    [JsonPropertyName("business_registration_number")]
    public string? BusinessRegistrationNumber { get; init; }

    /// <summary>
    /// Gets the business sector.
    /// </summary>
    [JsonPropertyName("sector")]
    public string? Sector { get; init; }

    /// <summary>
    /// Gets the employee count.
    /// </summary>
    [JsonPropertyName("employee_count")]
    public int? EmployeeCount { get; init; }
}

/// <summary>
/// Represents member-get-member referral details.
/// </summary>
public sealed class MgmDetails
{
    /// <summary>
    /// Gets the referral code.
    /// </summary>
    [JsonPropertyName("mgm_code")]
    public string? MgmCode { get; init; }

    /// <summary>
    /// Gets the invitee reward value.
    /// </summary>
    [JsonPropertyName("invitee_value")]
    public int InviteeValue { get; init; }

    /// <summary>
    /// Gets the inviter reward value.
    /// </summary>
    [JsonPropertyName("inviter_value")]
    public int InviterValue { get; init; }

    /// <summary>
    /// Gets the share URL for the referral.
    /// </summary>
    [JsonPropertyName("share_url")]
    public string? ShareUrl { get; init; }

    /// <summary>
    /// Gets the total amount earned from referrals.
    /// </summary>
    [JsonPropertyName("amount_earned")]
    public int AmountEarned { get; init; }
}

/// <summary>
/// Represents a user address.
/// </summary>
public sealed class Address
{
    /// <summary>
    /// Gets the address identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets the house number.
    /// </summary>
    [JsonPropertyName("house_number")]
    public int HouseNumber { get; init; }

    /// <summary>
    /// Gets the house number extension.
    /// </summary>
    [JsonPropertyName("house_number_ext")]
    public string? HouseNumberExt { get; init; }

    /// <summary>
    /// Gets the postal code.
    /// </summary>
    [JsonPropertyName("postcode")]
    public string? Postcode { get; init; }

    /// <summary>
    /// Gets the street name.
    /// </summary>
    [JsonPropertyName("street")]
    public string? Street { get; init; }

    /// <summary>
    /// Gets the city name.
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; init; }

    /// <summary>
    /// Gets the full house number extension.
    /// </summary>
    [JsonPropertyName("house_number_extension")]
    public string? HouseNumberExtension { get; init; }
}

/// <summary>
/// Represents a user subscription.
/// </summary>
public sealed class Subscription
{
    /// <summary>
    /// Gets the subscription list identifier.
    /// </summary>
    [JsonPropertyName("list_id")]
    public string? ListId { get; init; }

    /// <summary>
    /// Gets a value indicating whether the user is subscribed.
    /// </summary>
    [JsonPropertyName("subscribed")]
    public bool Subscribed { get; init; }

    /// <summary>
    /// Gets the subscription name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }
}

/// <summary>
/// Represents household composition details.
/// </summary>
public sealed class HouseholdDetails
{
    /// <summary>
    /// Gets the number of adults.
    /// </summary>
    [JsonPropertyName("adults")]
    public int Adults { get; init; }

    /// <summary>
    /// Gets the number of children.
    /// </summary>
    [JsonPropertyName("children")]
    public int Children { get; init; }

    /// <summary>
    /// Gets the number of cats.
    /// </summary>
    [JsonPropertyName("cats")]
    public int Cats { get; init; }

    /// <summary>
    /// Gets the number of dogs.
    /// </summary>
    [JsonPropertyName("dogs")]
    public int Dogs { get; init; }

    /// <summary>
    /// Gets the author of the last update.
    /// </summary>
    [JsonPropertyName("author")]
    public string? Author { get; init; }

    /// <summary>
    /// Gets the timestamp of the last edit.
    /// </summary>
    [JsonPropertyName("last_edit_ts")]
    public long LastEditTs { get; init; }
}

/// <summary>
/// Represents a feature toggle assigned to the user.
/// </summary>
public sealed class FeatureToggle
{
    /// <summary>
    /// Gets the feature toggle name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }
}

/// <summary>
/// Represents a Picnic user profile.
/// </summary>
public sealed class User
{
    /// <summary>
    /// Gets the user identifier.
    /// </summary>
    [JsonPropertyName("user_id")]
    public string? UserId { get; init; }

    /// <summary>
    /// Gets the first name.
    /// </summary>
    [JsonPropertyName("firstname")]
    public string? Firstname { get; init; }

    /// <summary>
    /// Gets the last name.
    /// </summary>
    [JsonPropertyName("lastname")]
    public string? Lastname { get; init; }

    /// <summary>
    /// Gets the primary address.
    /// </summary>
    [JsonPropertyName("address")]
    public Address? Address { get; init; }

    /// <summary>
    /// Gets the phone number.
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; init; }

    /// <summary>
    /// Gets the contact email address.
    /// </summary>
    [JsonPropertyName("contact_email")]
    public string? ContactEmail { get; init; }

    /// <summary>
    /// Gets the enabled feature toggles.
    /// </summary>
    [JsonPropertyName("feature_toggles")]
    public IReadOnlyList<FeatureToggle>? FeatureToggles { get; init; }

    /// <summary>
    /// Gets the push subscriptions.
    /// </summary>
    [JsonPropertyName("push_subscriptions")]
    public IReadOnlyList<Subscription>? PushSubscriptions { get; init; }

    /// <summary>
    /// Gets the subscriptions.
    /// </summary>
    [JsonPropertyName("subscriptions")]
    public IReadOnlyList<Subscription>? Subscriptions { get; init; }

    /// <summary>
    /// Gets the customer type.
    /// </summary>
    [JsonPropertyName("customer_type")]
    public string? CustomerType { get; init; }

    /// <summary>
    /// Gets the household details.
    /// </summary>
    [JsonPropertyName("household_details")]
    public HouseholdDetails? HouseholdDetails { get; init; }

    /// <summary>
    /// Gets the business details.
    /// </summary>
    [JsonPropertyName("business_details")]
    public BusinessDetails? BusinessDetails { get; init; }

    /// <summary>
    /// Gets a value indicating whether general consent must be checked.
    /// </summary>
    [JsonPropertyName("check_general_consent")]
    public bool CheckGeneralConsent { get; init; }

    /// <summary>
    /// Gets a value indicating whether the user has placed an order.
    /// </summary>
    [JsonPropertyName("placed_order")]
    public bool PlacedOrder { get; init; }

    /// <summary>
    /// Gets a value indicating whether the user has received a delivery.
    /// </summary>
    [JsonPropertyName("received_delivery")]
    public bool ReceivedDelivery { get; init; }

    /// <summary>
    /// Gets the total number of deliveries.
    /// </summary>
    [JsonPropertyName("total_deliveries")]
    public int TotalDeliveries { get; init; }

    /// <summary>
    /// Gets the number of completed deliveries.
    /// </summary>
    [JsonPropertyName("completed_deliveries")]
    public int CompletedDeliveries { get; init; }

    /// <summary>
    /// Gets consent decisions keyed by consent identifier.
    /// </summary>
    [JsonPropertyName("consent_decisions")]
    public Dictionary<string, bool?>? ConsentDecisions { get; init; }
}

/// <summary>
/// Represents a lightweight user information payload.
/// </summary>
public sealed class UserInfo
{
    /// <summary>
    /// Gets the user identifier.
    /// </summary>
    [JsonPropertyName("user_id")]
    public string? UserId { get; init; }

    /// <summary>
    /// Gets the redacted phone number.
    /// </summary>
    [JsonPropertyName("redacted_phone_number")]
    public string? RedactedPhoneNumber { get; init; }

    /// <summary>
    /// Gets the enabled feature toggles.
    /// </summary>
    [JsonPropertyName("feature_toggles")]
    public IReadOnlyList<FeatureToggle>? FeatureToggles { get; init; }
}

/// <summary>
/// Represents a user avatar.
/// </summary>
public sealed class Avatar
{
    /// <summary>
    /// Gets the avatar image URL.
    /// </summary>
    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; init; }

    /// <summary>
    /// Gets the avatar type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }
}

/// <summary>
/// Represents a user summary for the profile menu.
/// </summary>
public sealed class ProfileUser
{
    /// <summary>
    /// Gets the display name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Gets the user address.
    /// </summary>
    [JsonPropertyName("address")]
    public Address? Address { get; init; }

    /// <summary>
    /// Gets the user avatar.
    /// </summary>
    [JsonPropertyName("avatar")]
    public Avatar? Avatar { get; init; }

    /// <summary>
    /// Gets referral information for the user.
    /// </summary>
    [JsonPropertyName("mgm")]
    public MgmDetails? Mgm { get; init; }
}

/// <summary>
/// Represents the profile menu payload.
/// </summary>
public sealed class ProfileMenu
{
    /// <summary>
    /// Gets the highlight entries shown in the profile menu.
    /// </summary>
    [JsonPropertyName("highlights")]
    public IReadOnlyList<object>? Highlights { get; init; }

    /// <summary>
    /// Gets the user information shown in the profile menu.
    /// </summary>
    [JsonPropertyName("user")]
    public ProfileUser? User { get; init; }
}
