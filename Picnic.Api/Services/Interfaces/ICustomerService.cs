using Picnic.Api.Models.CustomerService;

namespace Picnic.Api.Services.Interfaces;

/// <summary>
/// Defines customer service operations.
/// </summary>
public interface ICustomerService
{
    /// <summary>
    /// Returns customer service contact details and opening times.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The customer service contact information.</returns>
    Task<CustomerServiceContactInfo> GetContactInfoAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns popup messages in the app, such as prompts, message-bar notifications, and order-confirmation cards.
    /// </summary>
    /// <param name="displayPositions">Optional filter values such as <c>PROMPT</c>, <c>MESSAGE_BAR</c>, <c>ORDER_CONFIRMATION</c>, or <c>STOREFRONT_DIALOG</c>.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The messages response wrapper.</returns>
    Task<MessagesWrapper> GetMessagesAsync(IReadOnlyList<string>? displayPositions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the user's configured delivery reminders.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The reminders response wrapper.</returns>
    Task<RemindersWrapper> GetRemindersAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Replaces the user's configured delivery reminders.
    /// </summary>
    /// <param name="reminders">The reminders to store.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task SetRemindersAsync(IReadOnlyList<Reminder> reminders, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns externally shipped parcels tracked via a carrier.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The tracked parcels.</returns>
    Task<IReadOnlyList<Parcel>> GetParcelsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns customer service contact info without requiring authentication.
    /// </summary>
    /// <param name="countryCode">The country code to pass in the <c>picnic-country</c> header.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The customer service contact information.</returns>
    Task<CustomerServiceContactInfo> GetUnauthenticatedContactInfoAsync(string countryCode, CancellationToken cancellationToken = default);
}
