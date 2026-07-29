using Picnic.Api.Models.CustomerService;

namespace Picnic.Api.Services.Interfaces;

/// <summary>
/// Defines customer service operations including support tickets, messages, and reminders.
/// </summary>
public interface ICustomerService
{
    /// <summary>
    /// Retrieves customer service contact information.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The contact information.</returns>
    Task<ContactInfo> GetContactInfoAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves support tickets for the current user.
    /// </summary>
    /// <param name="offset">The pagination offset (default: 0).</param>
    /// <param name="limit">The maximum number of tickets to return (default: 20).</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A paginated list of support tickets.</returns>
    Task<SupportTicketsResponse> GetTicketsAsync(int offset = 0, int limit = 20, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a specific support ticket by identifier.
    /// </summary>
    /// <param name="ticketId">The ticket identifier.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The support ticket details.</returns>
    Task<SupportTicket> GetTicketAsync(string ticketId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new support ticket.
    /// </summary>
    /// <param name="subject">The ticket subject.</param>
    /// <param name="description">The ticket description.</param>
    /// <param name="priority">The priority level (e.g., "low", "medium", "high").</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The created support ticket.</returns>
    Task<SupportTicket> CreateTicketAsync(string subject, string description, string priority = "medium", CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves service messages for the current user.
    /// </summary>
    /// <param name="offset">The pagination offset (default: 0).</param>
    /// <param name="limit">The maximum number of messages to return (default: 20).</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A paginated list of service messages.</returns>
    Task<ServiceMessagesResponse> GetMessagesAsync(int offset = 0, int limit = 20, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a message/reply to a support ticket.
    /// </summary>
    /// <param name="ticketId">The ticket identifier.</param>
    /// <param name="messageContent">The message content.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task AddMessageAsync(string ticketId, string messageContent, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves service reminders for the current user.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A list of service reminders.</returns>
    Task<ServiceRemindersResponse> GetRemindersAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Marks a reminder as resolved.
    /// </summary>
    /// <param name="reminderId">The reminder identifier.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task ResolveReminderAsync(string reminderId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of parcels being shipped.
    /// </summary>
    /// <param name="offset">The pagination offset (default: 0).</param>
    /// <param name="limit">The maximum number of parcels to return (default: 20).</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A paginated list of parcels.</returns>
    Task<ParcelsResponse> GetParcelsAsync(int offset = 0, int limit = 20, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves tracking information for a specific parcel.
    /// </summary>
    /// <param name="parcelId">The parcel identifier.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The parcel tracking information.</returns>
    Task<Parcel> GetParcelAsync(string parcelId, CancellationToken cancellationToken = default);
}
