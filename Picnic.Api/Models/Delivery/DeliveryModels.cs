using Picnic.Api.Models.Cart;
using System.Text.Json;
using System.Text.Json.Serialization;
using UserAddress = Picnic.Api.Models.User.Address;

namespace Picnic.Api.Models.Delivery;

public sealed class DeliveryTime
{
    [JsonPropertyName("start")]
    public string? Start { get; init; }

    [JsonPropertyName("end")]
    public string? End { get; init; }
}

public sealed class DeliveryOrder
{
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("creation_time")]
    public string? CreationTime { get; init; }

    [JsonPropertyName("total_price")]
    public int TotalPrice { get; init; }

    [JsonPropertyName("status")]
    public string? Status { get; init; }

    [JsonPropertyName("cancellation_time")]
    public string? CancellationTime { get; init; }
}

public sealed class Delivery
{
    [JsonPropertyName("delivery_id")]
    public string? DeliveryId { get; init; }

    [JsonPropertyName("creation_time")]
    public string? CreationTime { get; init; }

    [JsonPropertyName("slot")]
    public DeliverySlot? Slot { get; init; }

    [JsonPropertyName("eta2")]
    public DeliveryTime? Eta2 { get; init; }

    [JsonPropertyName("status")]
    public string? Status { get; init; }

    [JsonPropertyName("delivery_time")]
    public DeliveryTime? DeliveryTime { get; init; }

    [JsonPropertyName("orders")]
    public IReadOnlyList<DeliveryOrder>? Orders { get; init; }
}

public sealed class ReturnedContainer
{
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("localized_name")]
    public string? LocalizedName { get; init; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; init; }

    [JsonPropertyName("price")]
    public int Price { get; init; }
}

public sealed class DeliveryDetail
{
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("delivery_id")]
    public string? DeliveryId { get; init; }

    [JsonPropertyName("creation_time")]
    public string? CreationTime { get; init; }

    [JsonPropertyName("slot")]
    public DeliverySlot? Slot { get; init; }

    [JsonPropertyName("eta2")]
    public DeliveryTime? Eta2 { get; init; }

    [JsonPropertyName("status")]
    public string? Status { get; init; }

    [JsonPropertyName("delivery_time")]
    public DeliveryTime? DeliveryTime { get; init; }

    [JsonPropertyName("orders")]
    public IReadOnlyList<Order>? Orders { get; init; }

    [JsonPropertyName("returned_containers")]
    public IReadOnlyList<ReturnedContainer>? ReturnedContainers { get; init; }

    [JsonPropertyName("parcels")]
    public IReadOnlyList<JsonElement>? Parcels { get; init; }
}

public sealed class Vehicle
{
    [JsonPropertyName("image")]
    public string? Image { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }
}

public sealed class DeliveryDriver
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("photo_url")]
    public string? PhotoUrl { get; init; }
}

public sealed class ScenarioEntry
{
    [JsonPropertyName("ts")]
    public long Ts { get; init; }

    [JsonPropertyName("lat")]
    public double Lat { get; init; }

    [JsonPropertyName("lng")]
    public double Lng { get; init; }
}

public sealed class DeliveryScenario
{
    [JsonPropertyName("version")]
    public int Version { get; init; }

    [JsonPropertyName("scenario")]
    public IReadOnlyList<ScenarioEntry>? Scenario { get; init; }

    [JsonPropertyName("vehicle")]
    public Vehicle? Vehicle { get; init; }

    [JsonPropertyName("driver")]
    public DeliveryDriver? Driver { get; init; }

    [JsonPropertyName("trailers")]
    public IReadOnlyList<Vehicle>? Trailers { get; init; }

    [JsonPropertyName("destination")]
    public UserAddress? Destination { get; init; }
}

public sealed class DeliveryPosition
{
    [JsonPropertyName("version")]
    public int Version { get; init; }

    [JsonPropertyName("scenario_ts")]
    public long ScenarioTs { get; init; }

    [JsonPropertyName("eta")]
    public long Eta { get; init; }

    [JsonPropertyName("eta_window")]
    public DeliveryTime? EtaWindow { get; init; }

    [JsonPropertyName("query_interval")]
    public int QueryInterval { get; init; }

    [JsonPropertyName("scenario_in_progress")]
    public bool ScenarioInProgress { get; init; }
}
