using System.Text.Json.Serialization;

namespace Picnic.Api.Models.User;

public sealed class BusinessDetails
{
    [JsonPropertyName("business_name")]
    public string? BusinessName { get; init; }

    [JsonPropertyName("business_registration_number")]
    public string? BusinessRegistrationNumber { get; init; }

    [JsonPropertyName("sector")]
    public string? Sector { get; init; }

    [JsonPropertyName("employee_count")]
    public int? EmployeeCount { get; init; }
}

public sealed class MgmDetails
{
    [JsonPropertyName("mgm_code")]
    public string? MgmCode { get; init; }

    [JsonPropertyName("invitee_value")]
    public int InviteeValue { get; init; }

    [JsonPropertyName("inviter_value")]
    public int InviterValue { get; init; }

    [JsonPropertyName("share_url")]
    public string? ShareUrl { get; init; }

    [JsonPropertyName("amount_earned")]
    public int AmountEarned { get; init; }
}

public sealed class Address
{
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("house_number")]
    public int HouseNumber { get; init; }

    [JsonPropertyName("house_number_ext")]
    public string? HouseNumberExt { get; init; }

    [JsonPropertyName("postcode")]
    public string? Postcode { get; init; }

    [JsonPropertyName("street")]
    public string? Street { get; init; }

    [JsonPropertyName("city")]
    public string? City { get; init; }

    [JsonPropertyName("house_number_extension")]
    public string? HouseNumberExtension { get; init; }
}

public sealed class Subscription
{
    [JsonPropertyName("list_id")]
    public string? ListId { get; init; }

    [JsonPropertyName("subscribed")]
    public bool Subscribed { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }
}

public sealed class HouseholdDetails
{
    [JsonPropertyName("adults")]
    public int Adults { get; init; }

    [JsonPropertyName("children")]
    public int Children { get; init; }

    [JsonPropertyName("cats")]
    public int Cats { get; init; }

    [JsonPropertyName("dogs")]
    public int Dogs { get; init; }

    [JsonPropertyName("author")]
    public string? Author { get; init; }

    [JsonPropertyName("last_edit_ts")]
    public long LastEditTs { get; init; }
}

public sealed class FeatureToggle
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }
}

public sealed class User
{
    [JsonPropertyName("user_id")]
    public string? UserId { get; init; }

    [JsonPropertyName("firstname")]
    public string? Firstname { get; init; }

    [JsonPropertyName("lastname")]
    public string? Lastname { get; init; }

    [JsonPropertyName("address")]
    public Address? Address { get; init; }

    [JsonPropertyName("phone")]
    public string? Phone { get; init; }

    [JsonPropertyName("contact_email")]
    public string? ContactEmail { get; init; }

    [JsonPropertyName("feature_toggles")]
    public IReadOnlyList<FeatureToggle>? FeatureToggles { get; init; }

    [JsonPropertyName("push_subscriptions")]
    public IReadOnlyList<Subscription>? PushSubscriptions { get; init; }

    [JsonPropertyName("subscriptions")]
    public IReadOnlyList<Subscription>? Subscriptions { get; init; }

    [JsonPropertyName("customer_type")]
    public string? CustomerType { get; init; }

    [JsonPropertyName("household_details")]
    public HouseholdDetails? HouseholdDetails { get; init; }

    [JsonPropertyName("business_details")]
    public BusinessDetails? BusinessDetails { get; init; }

    [JsonPropertyName("check_general_consent")]
    public bool CheckGeneralConsent { get; init; }

    [JsonPropertyName("placed_order")]
    public bool PlacedOrder { get; init; }

    [JsonPropertyName("received_delivery")]
    public bool ReceivedDelivery { get; init; }

    [JsonPropertyName("total_deliveries")]
    public int TotalDeliveries { get; init; }

    [JsonPropertyName("completed_deliveries")]
    public int CompletedDeliveries { get; init; }

    [JsonPropertyName("consent_decisions")]
    public Dictionary<string, bool?>? ConsentDecisions { get; init; }
}

public sealed class UserInfo
{
    [JsonPropertyName("user_id")]
    public string? UserId { get; init; }

    [JsonPropertyName("redacted_phone_number")]
    public string? RedactedPhoneNumber { get; init; }

    [JsonPropertyName("feature_toggles")]
    public IReadOnlyList<FeatureToggle>? FeatureToggles { get; init; }
}

public sealed class Avatar
{
    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }
}

public sealed class ProfileUser
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("address")]
    public Address? Address { get; init; }

    [JsonPropertyName("avatar")]
    public Avatar? Avatar { get; init; }

    [JsonPropertyName("mgm")]
    public MgmDetails? Mgm { get; init; }
}

public sealed class ProfileMenu
{
    [JsonPropertyName("highlights")]
    public IReadOnlyList<object>? Highlights { get; init; }

    [JsonPropertyName("user")]
    public ProfileUser? User { get; init; }
}
