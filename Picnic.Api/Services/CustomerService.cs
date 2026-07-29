using Picnic.Api.Internal;
using Picnic.Api.Models.CustomerService;
using Picnic.Api.Services.Interfaces;

namespace Picnic.Api.Services;

internal sealed class CustomerService(PicnicHttpClient httpClient) : ICustomerService
{
    /// <summary>
    /// Retrieves customer service contact information.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The contact information.</returns>
    public async Task<ContactInfo> GetContactInfoAsync(CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync(
            "/customer-service/contact-info",
            cancellationToken: cancellationToken)).DeserializeOrThrow<ContactInfo>();

    /// <summary>
    /// Retrieves support tickets for the current user.
    /// </summary>
    /// <param name="offset">The pagination offset (default: 0).</param>
    /// <param name="limit">The maximum number of tickets to return (default: 20).</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A paginated list of support tickets.</returns>
    public async Task<SupportTicketsResponse> GetTicketsAsync(int offset = 0, int limit = 20, CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync(
            $"/customer-service/tickets?offset={offset}&limit={limit}",
            cancellationToken: cancellationToken)).DeserializeOrThrow<SupportTicketsResponse>();

    /// <summary>
    /// Retrieves a specific support ticket by identifier.
    /// </summary>
    /// <param name="ticketId">The ticket identifier.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The support ticket details.</returns>
    public async Task<SupportTicket> GetTicketAsync(string ticketId, CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync(
            $"/customer-service/tickets/{Uri.EscapeDataString(ticketId)}",
            cancellationToken: cancellationToken)).DeserializeOrThrow<SupportTicket>();

    /// <summary>
    /// Creates a new support ticket.
    /// </summary>
    /// <param name="subject">The ticket subject.</param>
    /// <param name="description">The ticket description.</param>
    /// <param name="priority">The priority level (e.g., "low", "medium", "high").</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The created support ticket.</returns>
    public async Task<SupportTicket> CreateTicketAsync(string subject, string description, string priority = "medium", CancellationToken cancellationToken = default)
    {
        var request = new CreateSupportTicketRequest
        {
            Subject = subject,
            Description = description,
            Priority = priority
        };
        return (await httpClient.PostAsync("/customer-service/tickets", request, cancellationToken: cancellationToken))
            .DeserializeOrThrow<SupportTicket>();
    }

    /// <summary>
    /// Retrieves service messages for the current user.
    /// </summary>
    /// <param name="offset">The pagination offset (default: 0).</param>
    /// <param name="limit">The maximum number of messages to return (default: 20).</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A paginated list of service messages.</returns>
    public async Task<ServiceMessagesResponse> GetMessagesAsync(int offset = 0, int limit = 20, CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync(
            $"/customer-service/messages?offset={offset}&limit={limit}",
            cancellationToken: cancellationToken)).DeserializeOrThrow<ServiceMessagesResponse>();

    /// <summary>
    /// Adds a message/reply to a support ticket.
    /// </summary>
    /// <param name="ticketId">The ticket identifier.</param>
    /// <param name="messageContent">The message content.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task AddMessageAsync(string ticketId, string messageContent, CancellationToken cancellationToken = default)
    {
        var request = new { message = messageContent };
        await httpClient.PostAsync($"/customer-service/tickets/{Uri.EscapeDataString(ticketId)}/messages", request, cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Retrieves service reminders for the current user.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A list of service reminders.</returns>
    public async Task<ServiceRemindersResponse> GetRemindersAsync(CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync(
            "/customer-service/reminders",
            cancellationToken: cancellationToken)).DeserializeOrThrow<ServiceRemindersResponse>();

    /// <summary>
    /// Marks a reminder as resolved.
    /// </summary>
    /// <param name="reminderId">The reminder identifier.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task ResolveReminderAsync(string reminderId, CancellationToken cancellationToken = default)
    {
        await httpClient.PostAsync(
            $"/customer-service/reminders/{Uri.EscapeDataString(reminderId)}/resolve",
            new object(),
            cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Retrieves a list of parcels being shipped.
    /// </summary>
    /// <param name="offset">The pagination offset (default: 0).</param>
    /// <param name="limit">The maximum number of parcels to return (default: 20).</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A paginated list of parcels.</returns>
    public async Task<ParcelsResponse> GetParcelsAsync(int offset = 0, int limit = 20, CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync(
            $"/customer-service/parcels?offset={offset}&limit={limit}",
            cancellationToken: cancellationToken)).DeserializeOrThrow<ParcelsResponse>();

    /// <summary>
    /// Retrieves tracking information for a specific parcel.
    /// </summary>
    /// <param name="parcelId">The parcel identifier.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The parcel tracking information.</returns>
    public async Task<Parcel> GetParcelAsync(string parcelId, CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync(
            $"/customer-service/parcels/{Uri.EscapeDataString(parcelId)}",
            cancellationToken: cancellationToken)).DeserializeOrThrow<Parcel>();
}
