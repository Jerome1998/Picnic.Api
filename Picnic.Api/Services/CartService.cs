using Picnic.Api.Internal;
using Picnic.Api.Models.Cart;
using Picnic.Api.Services.Interfaces;

namespace Picnic.Api.Services;

internal sealed class CartService(PicnicHttpClient httpClient) : ICartService
{
    public async Task<Cart> GetCartAsync(CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync("/cart", includePicnicHeaders: true, cancellationToken: cancellationToken)).DeserializeOrThrow<Cart>();

    public async Task<Cart> AddProductToCartAsync(string productId, int count = 1, CancellationToken cancellationToken = default)
        => (await httpClient.PostAsync("/cart/add_product", new { product_id = productId, count }, includePicnicHeaders: true, cancellationToken: cancellationToken)).DeserializeOrThrow<Cart>();

    public async Task<Cart> RemoveProductFromCartAsync(string productId, int count = 1, CancellationToken cancellationToken = default)
        => (await httpClient.PostAsync("/cart/remove_product", new { product_id = productId, count }, includePicnicHeaders: true, cancellationToken: cancellationToken)).DeserializeOrThrow<Cart>();

    public async Task<Cart> ClearCartAsync(CancellationToken cancellationToken = default)
        => (await httpClient.PostAsync("/cart/clear", includePicnicHeaders: true, cancellationToken: cancellationToken)).DeserializeOrThrow<Cart>();

    public async Task<GetDeliverySlotsResult> GetDeliverySlotsAsync(CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync("/cart/delivery_slots", cancellationToken: cancellationToken)).DeserializeOrThrow<GetDeliverySlotsResult>();

    public async Task<Cart> SetDeliverySlotAsync(string slotId, CancellationToken cancellationToken = default)
        => (await httpClient.PostAsync("/cart/set_delivery_slot", new { slot_id = slotId }, includePicnicHeaders: true, cancellationToken: cancellationToken)).DeserializeOrThrow<Cart>();

    public async Task<OrderStatus> GetOrderStatusAsync(string orderId, CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync($"/cart/checkout/order/{orderId}/status", cancellationToken: cancellationToken)).DeserializeOrThrow<OrderStatus>();
}
