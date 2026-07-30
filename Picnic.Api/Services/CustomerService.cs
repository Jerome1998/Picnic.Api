using Picnic.Api.Internal;
using Picnic.Api.Models;
using Picnic.Api.Models.CustomerService;
using Picnic.Api.Services.Interfaces;
using System.Text.Json;

namespace Picnic.Api.Services;

internal sealed class CustomerService(PicnicHttpClient httpClient) : ICustomerService
{
    private static readonly HttpClient Client = new();

    /// <summary>
    /// Returns customer service contact details and opening times.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The customer service contact information.</returns>
    public async Task<CustomerServiceContactInfo> GetContactInfoAsync(CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync("/cs-contact-info", includePicnicHeaders: true, cancellationToken: cancellationToken))
            .DeserializeOrThrow<CustomerServiceContactInfo>();

    /// <summary>
    /// Returns popup messages in the app.
    /// </summary>
    /// <param name="displayPositions">Optional display position filters.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The messages response wrapper.</returns>
    public async Task<MessagesWrapper> GetMessagesAsync(IReadOnlyList<string>? displayPositions = null, CancellationToken cancellationToken = default)
    {
        string query = string.Empty;
        if (displayPositions is { Count: > 0 })
        {
            query = "?" + string.Join("&", displayPositions.Select(static p => $"display_position={Uri.EscapeDataString(p)}"));
        }

        return (await httpClient.GetAsync($"/messages{query}", includePicnicHeaders: true, cancellationToken: cancellationToken))
            .DeserializeOrThrow<MessagesWrapper>();
    }

    /// <summary>
    /// Returns the user's configured delivery reminders.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The reminders response wrapper.</returns>
    public async Task<RemindersWrapper> GetRemindersAsync(CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync("/reminders", includePicnicHeaders: true, cancellationToken: cancellationToken))
            .DeserializeOrThrow<RemindersWrapper>();

    /// <summary>
    /// Replaces the user's configured delivery reminders.
    /// </summary>
    /// <param name="reminders">The reminders to store.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task SetRemindersAsync(IReadOnlyList<Reminder> reminders, CancellationToken cancellationToken = default)
    {
        await httpClient.PutAsync("/reminders", reminders, includePicnicHeaders: true, cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Returns externally shipped parcels tracked via a carrier.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The tracked parcels.</returns>
    public async Task<IReadOnlyList<Parcel>> GetParcelsAsync(CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync("/parcels", includePicnicHeaders: true, cancellationToken: cancellationToken))
            .DeserializeOrThrow<IReadOnlyList<Parcel>>();

    /// <summary>
    /// Returns customer service contact info without requiring authentication.
    /// </summary>
    /// <param name="countryCode">The country code to pass in the picnic-country header.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The customer service contact information.</returns>
    public async Task<CustomerServiceContactInfo> GetUnauthenticatedContactInfoAsync(string countryCode, CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, httpClient.BuildPublicUrl("/cs-contact-info"));
        request.Headers.TryAddWithoutValidation("picnic-country", countryCode);

        using var response = await Client.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();

        string payload = await response.Content.ReadAsStringAsync(cancellationToken);
        using var document = JsonDocument.Parse(payload);
        return new PicnicApiResponse(document.RootElement.Clone()).DeserializeOrThrow<CustomerServiceContactInfo>();
    }
}
