using Picnic.Api.Models.Cart;

namespace Picnic.Api.Services.Interfaces;

/// <summary>
/// Defines shopping cart operations.
/// </summary>
public interface ICartService
{
    /// <summary>
    /// Retrieves the current shopping cart.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The current cart.</returns>
    Task<Cart> GetCartAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a product to the shopping cart.
    /// </summary>
    /// <param name="productId">The product identifier.</param>
    /// <param name="count">The quantity to add.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The updated cart.</returns>
    Task<Cart> AddProductToCartAsync(string productId, int count = 1, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes a product from the shopping cart.
    /// </summary>
    /// <param name="productId">The product identifier.</param>
    /// <param name="count">The quantity to remove.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The updated cart.</returns>
    Task<Cart> RemoveProductFromCartAsync(string productId, int count = 1, CancellationToken cancellationToken = default);

    /// <summary>
    /// Clears all items from the shopping cart.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The cleared cart.</returns>
    Task<Cart> ClearCartAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves available delivery slots for the current cart.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The available delivery slots.</returns>
    Task<GetDeliverySlotsResult> GetDeliverySlotsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Sets the selected delivery slot for the current cart.
    /// </summary>
    /// <param name="slotId">The delivery slot identifier.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The updated cart.</returns>
    Task<Cart> SetDeliverySlotAsync(string slotId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves order status for a checkout order.
    /// </summary>
    /// <param name="orderId">The order identifier.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The order status payload.</returns>
    Task<OrderStatus> GetOrderStatusAsync(string orderId, CancellationToken cancellationToken = default);
}
