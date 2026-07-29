using System.Text.Json.Serialization;

namespace Picnic.Api.Models.CustomerService;

/// <summary>
/// Represents customer service contact information.
/// </summary>
public sealed class ContactInfo
{
    /// <summary>
    /// Gets the phone number for customer support.
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; init; }

    /// <summary>
    /// Gets the email address for customer support.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; init; }

    /// <summary>
    /// Gets the chat URL for live support.
    /// </summary>
    [JsonPropertyName("chat_url")]
    public string? ChatUrl { get; init; }

    /// <summary>
    /// Gets the website URL for support documentation.
    /// </summary>
    [JsonPropertyName("website_url")]
    public string? WebsiteUrl { get; init; }

    /// <summary>
    /// Gets the support hours information.
    /// </summary>
    [JsonPropertyName("hours")]
    public string? Hours { get; init; }

    /// <summary>
    /// Gets the country code for this contact information.
    /// </summary>
    [JsonPropertyName("country_code")]
    public string? CountryCode { get; init; }
}

/// <summary>
/// Represents a customer service message.
/// </summary>
public sealed class ServiceMessage
{
    /// <summary>
    /// Gets the message identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets the message subject.
    /// </summary>
    [JsonPropertyName("subject")]
    public string? Subject { get; init; }

    /// <summary>
    /// Gets the message content.
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; init; }

    /// <summary>
    /// Gets the sender identifier.
    /// </summary>
    [JsonPropertyName("sender_id")]
    public string? SenderId { get; init; }

    /// <summary>
    /// Gets the timestamp when the message was sent.
    /// </summary>
    [JsonPropertyName("sent_at")]
    public DateTime? SentAt { get; init; }

    /// <summary>
    /// Gets the message type (e.g., "ticket", "notification").
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// Gets the status of the message (e.g., "open", "closed").
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }
}

/// <summary>
/// Represents a customer service ticket.
/// </summary>
public sealed class SupportTicket
{
    /// <summary>
    /// Gets the ticket identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets the ticket number.
    /// </summary>
    [JsonPropertyName("ticket_number")]
    public string? TicketNumber { get; init; }

    /// <summary>
    /// Gets the ticket subject.
    /// </summary>
    [JsonPropertyName("subject")]
    public string? Subject { get; init; }

    /// <summary>
    /// Gets the ticket description.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// Gets the ticket status.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// Gets the priority level.
    /// </summary>
    [JsonPropertyName("priority")]
    public string? Priority { get; init; }

    /// <summary>
    /// Gets the timestamp when the ticket was created.
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; init; }

    /// <summary>
    /// Gets the timestamp of the last update.
    /// </summary>
    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; init; }

    /// <summary>
    /// Gets the list of messages in this ticket.
    /// </summary>
    [JsonPropertyName("messages")]
    public IReadOnlyList<ServiceMessage>? Messages { get; init; }
}

/// <summary>
/// Represents a customer service reminder.
/// </summary>
public sealed class ServiceReminder
{
    /// <summary>
    /// Gets the reminder identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets the reminder type (e.g., "order_issue", "delivery_delay").
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// Gets the reminder message.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; init; }

    /// <summary>
    /// Gets the timestamp when the reminder was sent.
    /// </summary>
    [JsonPropertyName("sent_at")]
    public DateTime? SentAt { get; init; }

    /// <summary>
    /// Gets whether the reminder has been acted upon.
    /// </summary>
    [JsonPropertyName("is_resolved")]
    public bool? IsResolved { get; init; }

    /// <summary>
    /// Gets the related order or delivery ID if applicable.
    /// </summary>
    [JsonPropertyName("related_id")]
    public string? RelatedId { get; init; }
}

/// <summary>
/// Represents a parcel for shipment.
/// </summary>
public sealed class Parcel
{
    /// <summary>
    /// Gets the parcel identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets the tracking number.
    /// </summary>
    [JsonPropertyName("tracking_number")]
    public string? TrackingNumber { get; init; }

    /// <summary>
    /// Gets the carrier name (e.g., "DPD", "DHL").
    /// </summary>
    [JsonPropertyName("carrier")]
    public string? Carrier { get; init; }

    /// <summary>
    /// Gets the current status of the parcel.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// Gets the estimated delivery date.
    /// </summary>
    [JsonPropertyName("estimated_delivery_date")]
    public DateTime? EstimatedDeliveryDate { get; init; }

    /// <summary>
    /// Gets the actual delivery date.
    /// </summary>
    [JsonPropertyName("delivered_at")]
    public DateTime? DeliveredAt { get; init; }

    /// <summary>
    /// Gets the tracking URL to check parcel status.
    /// </summary>
    [JsonPropertyName("tracking_url")]
    public string? TrackingUrl { get; init; }

    /// <summary>
    /// Gets the destination address.
    /// </summary>
    [JsonPropertyName("destination_address")]
    public string? DestinationAddress { get; init; }
}

/// <summary>
/// Represents a response containing service messages.
/// </summary>
public sealed class ServiceMessagesResponse
{
    /// <summary>
    /// Gets the list of service messages.
    /// </summary>
    [JsonPropertyName("messages")]
    public IReadOnlyList<ServiceMessage>? Messages { get; init; }

    /// <summary>
    /// Gets the total number of messages.
    /// </summary>
    [JsonPropertyName("total")]
    public int? Total { get; init; }
}

/// <summary>
/// Represents a response containing support tickets.
/// </summary>
public sealed class SupportTicketsResponse
{
    /// <summary>
    /// Gets the list of support tickets.
    /// </summary>
    [JsonPropertyName("tickets")]
    public IReadOnlyList<SupportTicket>? Tickets { get; init; }

    /// <summary>
    /// Gets the total number of tickets.
    /// </summary>
    [JsonPropertyName("total")]
    public int? Total { get; init; }
}

/// <summary>
/// Represents a response containing service reminders.
/// </summary>
public sealed class ServiceRemindersResponse
{
    /// <summary>
    /// Gets the list of service reminders.
    /// </summary>
    [JsonPropertyName("reminders")]
    public IReadOnlyList<ServiceReminder>? Reminders { get; init; }
}

/// <summary>
/// Represents a response containing parcels.
/// </summary>
public sealed class ParcelsResponse
{
    /// <summary>
    /// Gets the list of parcels.
    /// </summary>
    [JsonPropertyName("parcels")]
    public IReadOnlyList<Parcel>? Parcels { get; init; }

    /// <summary>
    /// Gets the total number of parcels.
    /// </summary>
    [JsonPropertyName("total")]
    public int? Total { get; init; }
}

/// <summary>
/// Represents a request to create a support ticket.
/// </summary>
public sealed class CreateSupportTicketRequest
{
    /// <summary>
    /// Gets or sets the ticket subject.
    /// </summary>
    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    /// <summary>
    /// Gets or sets the ticket description.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the priority level.
    /// </summary>
    [JsonPropertyName("priority")]
    public string? Priority { get; set; }
}
