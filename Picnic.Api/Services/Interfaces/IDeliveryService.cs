using Picnic.Api.Models.Delivery;

namespace Picnic.Api.Services.Interfaces;

/// <summary>
/// Defines delivery-related operations.
/// </summary>
public interface IDeliveryService
{
    /// <summary>
    /// Retrieves deliveries for the authenticated user.
    /// </summary>
    /// <param name="filter">Optional delivery filters to include in the request.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A list of deliveries.</returns>
    Task<IReadOnlyList<Delivery>> GetDeliveriesAsync(IEnumerable<string>? filter = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves details for a specific delivery.
    /// </summary>
    /// <param name="deliveryId">The delivery identifier.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The delivery details.</returns>
    Task<DeliveryDetail> GetDeliveryAsync(string deliveryId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves live position information for a delivery.
    /// </summary>
    /// <param name="deliveryId">The delivery identifier.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The delivery position payload.</returns>
    Task<DeliveryPosition> GetDeliveryPositionAsync(string deliveryId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves scenario information for a delivery.
    /// </summary>
    /// <param name="deliveryId">The delivery identifier.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The delivery scenario payload.</returns>
    Task<DeliveryScenario> GetDeliveryScenarioAsync(string deliveryId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Cancels a scheduled delivery.
    /// </summary>
    /// <param name="deliveryId">The delivery identifier.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The API response payload for the cancellation request.</returns>
    Task<object?> CancelDeliveryAsync(string deliveryId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Submits a rating for a delivery.
    /// </summary>
    /// <param name="deliveryId">The delivery identifier.</param>
    /// <param name="rating">The rating value to submit.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The API response payload for the rating request.</returns>
    Task<object?> SetDeliveryRatingAsync(string deliveryId, int rating, CancellationToken cancellationToken = default);
}
