using Picnic.Api.Models.Fusion;
using System.Text.Json.Serialization;

namespace Picnic.Api.Models.CustomerService;

/// <summary>
/// Represents an opening time window for a specific date.
/// </summary>
public sealed class OpeningTime
{
    /// <summary>
    /// Gets the start time as <c>[hour, minute]</c>.
    /// </summary>
    [JsonPropertyName("start")]
    public IReadOnlyList<int>? Start { get; init; }

    /// <summary>
    /// Gets the end time as <c>[hour, minute]</c>.
    /// </summary>
    [JsonPropertyName("end")]
    public IReadOnlyList<int>? End { get; init; }
}

/// <summary>
/// Represents customer service contact details.
/// </summary>
public sealed class ContactDetails
{
    /// <summary>
    /// Gets the support email address.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; init; }

    /// <summary>
    /// Gets the support phone number.
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; init; }

    /// <summary>
    /// Gets the support WhatsApp number.
    /// </summary>
    [JsonPropertyName("whatsapp")]
    public string? Whatsapp { get; init; }
}

/// <summary>
/// Represents customer service contact info and opening times.
/// </summary>
public sealed class CustomerServiceContactInfo
{
    /// <summary>
    /// Gets the contact details.
    /// </summary>
    [JsonPropertyName("contact_details")]
    public ContactDetails? ContactDetails { get; init; }

    /// <summary>
    /// Gets opening times keyed by date string.
    /// </summary>
    [JsonPropertyName("opening_times")]
    public Dictionary<string, OpeningTime>? OpeningTimes { get; init; }
}

/// <summary>
/// Represents the content payload of an in-app customer service message.
/// </summary>
public sealed class CustomerServiceMessageContent
{
    /// <summary>
    /// Gets the PML version.
    /// </summary>
    [JsonPropertyName("pml_version")]
    public string? PmlVersion { get; init; }

    /// <summary>
    /// Gets the root Fusion component.
    /// </summary>
    [JsonPropertyName("component")]
    public Component? Component { get; init; }

    /// <summary>
    /// Gets the image mapping used by the message.
    /// </summary>
    [JsonPropertyName("images")]
    public Dictionary<string, string>? Images { get; init; }

    /// <summary>
    /// Gets message tracking attributes.
    /// </summary>
    [JsonPropertyName("tracking_attributes")]
    public TrackingAttributes? TrackingAttributes { get; init; }
}

/// <summary>
/// Represents a single in-app customer service message.
/// </summary>
public sealed class CustomerServiceMessage
{
    /// <summary>
    /// Gets where in the app the message is shown.
    /// </summary>
    [JsonPropertyName("display_position")]
    public string? DisplayPosition { get; init; }

    /// <summary>
    /// Gets the correlation identifier for the message send event.
    /// </summary>
    [JsonPropertyName("send_correlation_id")]
    public string? SendCorrelationId { get; init; }

    /// <summary>
    /// Gets the sent time as a Unix timestamp in milliseconds.
    /// </summary>
    [JsonPropertyName("sent_time")]
    public long SentTime { get; init; }

    /// <summary>
    /// Gets the expiry time as a Unix timestamp in milliseconds.
    /// </summary>
    [JsonPropertyName("expiry_time")]
    public long ExpiryTime { get; init; }

    /// <summary>
    /// Gets the user identifier.
    /// </summary>
    [JsonPropertyName("user_id")]
    public string? UserId { get; init; }

    /// <summary>
    /// Gets the target entity identifier, if any.
    /// </summary>
    [JsonPropertyName("target_entity_id")]
    public string? TargetEntityId { get; init; }

    /// <summary>
    /// Gets the Fusion content payload.
    /// </summary>
    [JsonPropertyName("content")]
    public CustomerServiceMessageContent? Content { get; init; }
}

/// <summary>
/// Wraps the response returned by the <c>/messages</c> endpoint.
/// </summary>
public sealed class MessagesWrapper
{
    /// <summary>
    /// Gets the returned messages.
    /// </summary>
    [JsonPropertyName("messages")]
    public IReadOnlyList<CustomerServiceMessage>? Messages { get; init; }

    /// <summary>
    /// Gets the polling interval in milliseconds, if provided.
    /// </summary>
    [JsonPropertyName("query_interval")]
    public int? QueryInterval { get; init; }
}

/// <summary>
/// Represents a single reminder configuration.
/// </summary>
public sealed class Reminder
{
    /// <summary>
    /// Gets the day of week value such as <c>MONDAY</c>, or <c>null</c>.
    /// </summary>
    [JsonPropertyName("day_of_week")]
    public string? DayOfWeek { get; init; }

    /// <summary>
    /// Gets the time of day as <c>[hour, minute]</c>, or <c>null</c>.
    /// </summary>
    [JsonPropertyName("time_of_day")]
    public IReadOnlyList<int>? TimeOfDay { get; init; }
}

/// <summary>
/// Wraps the response returned by the <c>/reminders</c> endpoint.
/// </summary>
public sealed class RemindersWrapper
{
    /// <summary>
    /// Gets the configured reminders.
    /// </summary>
    [JsonPropertyName("reminders")]
    public IReadOnlyList<Reminder>? Reminders { get; init; }
}

/// <summary>
/// Represents the current status of a parcel.
/// </summary>
public sealed class ParcelCurrentStatus
{
    /// <summary>
    /// Gets the parcel status value.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// Gets the ISO 8601 timestamp for the current status.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public string? Timestamp { get; init; }
}

/// <summary>
/// Represents an externally shipped parcel.
/// </summary>
public sealed class Parcel
{
    /// <summary>
    /// Gets the carrier tracking identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets the carrier/handler name.
    /// </summary>
    [JsonPropertyName("handler_name")]
    public string? HandlerName { get; init; }

    /// <summary>
    /// Gets a value indicating whether the parcel is active.
    /// </summary>
    [JsonPropertyName("active")]
    public bool Active { get; init; }

    /// <summary>
    /// Gets the current parcel status.
    /// </summary>
    [JsonPropertyName("current_status")]
    public ParcelCurrentStatus? CurrentStatus { get; init; }
}
