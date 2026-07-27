using Picnic.Api.Internal;
using Picnic.Api.Models.Delivery;
using Picnic.Api.Services.Interfaces;

namespace Picnic.Api.Services;

internal sealed class DeliveryService(PicnicHttpClient httpClient) : IDeliveryService
{
    public async Task<IReadOnlyList<Delivery>> GetDeliveriesAsync(IEnumerable<string>? filter = null, CancellationToken cancellationToken = default)
        => (await httpClient.PostAsync("/deliveries/summary", filter?.ToArray() ?? [], cancellationToken: cancellationToken)).DeserializeOrThrow<IReadOnlyList<Delivery>>();

    public async Task<DeliveryDetail> GetDeliveryAsync(string deliveryId, CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync($"/deliveries/{deliveryId}", cancellationToken: cancellationToken)).DeserializeOrThrow<DeliveryDetail>();

    public async Task<DeliveryPosition> GetDeliveryPositionAsync(string deliveryId, CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync($"/deliveries/{deliveryId}/position", includePicnicHeaders: true, cancellationToken: cancellationToken)).DeserializeOrThrow<DeliveryPosition>();

    public async Task<DeliveryScenario> GetDeliveryScenarioAsync(string deliveryId, CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync($"/deliveries/{deliveryId}/scenario", includePicnicHeaders: true, cancellationToken: cancellationToken)).DeserializeOrThrow<DeliveryScenario>();

    public async Task<object?> CancelDeliveryAsync(string deliveryId, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsync($"/order/delivery/{deliveryId}/cancel", cancellationToken: cancellationToken);
        return response.Deserialize<object>();
    }

    public async Task<object?> SetDeliveryRatingAsync(string deliveryId, int rating, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsync($"/deliveries/{deliveryId}/rating", new { rating }, cancellationToken: cancellationToken);
        return response.Deserialize<object>();
    }
}
