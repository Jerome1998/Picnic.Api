using Picnic.Api.Models.Cart;
using System.Text.Json;
using System.Text.Json.Serialization;
using UserAddress = Picnic.Api.Models.User.Address;

namespace Picnic.Api.Models.Delivery;

/// <summary>
/// Represents a delivery time window.
/// </summary>
public sealed class DeliveryTime
{
    /// <summary>
    /// Gets the start of the time window.
    /// </summary>
    [JsonPropertyName("start")]
    public string? Start { get; init; }

    /// <summary>
    /// Gets the end of the time window.
    /// </summary>
    [JsonPropertyName("end")]
    public string? End { get; init; }
}

/// <summary>
/// Represents an order included in a delivery.
/// </summary>
public sealed class DeliveryOrder
{
    /// <summary>
    /// Gets the order type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// Gets the order identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets the order creation time.
    /// </summary>
    [JsonPropertyName("creation_time")]
    public string? CreationTime { get; init; }

    /// <summary>
    /// Gets the order total price.
    /// </summary>
    [JsonPropertyName("total_price")]
    public int TotalPrice { get; init; }

    /// <summary>
    /// Gets the order status.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// Gets the cancellation time, when available.
    /// </summary>
    [JsonPropertyName("cancellation_time")]
    public string? CancellationTime { get; init; }
}

/// <summary>
/// Represents a scheduled delivery.
/// </summary>
public sealed class Delivery
{
    /// <summary>
    /// Gets the delivery identifier.
    /// </summary>
    [JsonPropertyName("delivery_id")]
    public string? DeliveryId { get; init; }

    /// <summary>
    /// Gets the delivery creation time.
    /// </summary>
    [JsonPropertyName("creation_time")]
    public string? CreationTime { get; init; }

    /// <summary>
    /// Gets the assigned delivery slot.
    /// </summary>
    [JsonPropertyName("slot")]
    public DeliverySlot? Slot { get; init; }

    /// <summary>
    /// Gets the estimated delivery time window.
    /// </summary>
    [JsonPropertyName("eta2")]
    public DeliveryTime? Eta2 { get; init; }

    /// <summary>
    /// Gets the delivery status.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// Gets the delivery time window.
    /// </summary>
    [JsonPropertyName("delivery_time")]
    public DeliveryTime? DeliveryTime { get; init; }

    /// <summary>
    /// Gets the orders included in the delivery.
    /// </summary>
    [JsonPropertyName("orders")]
    public IReadOnlyList<DeliveryOrder>? Orders { get; init; }
}

/// <summary>
/// Represents a returned container associated with a delivery.
/// </summary>
public sealed class ReturnedContainer
{
    /// <summary>
    /// Gets the container type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// Gets the localized container name.
    /// </summary>
    [JsonPropertyName("localized_name")]
    public string? LocalizedName { get; init; }

    /// <summary>
    /// Gets the number of returned containers.
    /// </summary>
    [JsonPropertyName("quantity")]
    public int Quantity { get; init; }

    /// <summary>
    /// Gets the container price.
    /// </summary>
    [JsonPropertyName("price")]
    public int Price { get; init; }
}

/// <summary>
/// Represents detailed information about a delivery.
/// </summary>
public sealed class DeliveryDetail
{
    /// <summary>
    /// Gets the delivery detail type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// Gets the detail identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets the delivery identifier.
    /// </summary>
    [JsonPropertyName("delivery_id")]
    public string? DeliveryId { get; init; }

    /// <summary>
    /// Gets the creation time.
    /// </summary>
    [JsonPropertyName("creation_time")]
    public string? CreationTime { get; init; }

    /// <summary>
    /// Gets the assigned delivery slot.
    /// </summary>
    [JsonPropertyName("slot")]
    public DeliverySlot? Slot { get; init; }

    /// <summary>
    /// Gets the estimated delivery time window.
    /// </summary>
    [JsonPropertyName("eta2")]
    public DeliveryTime? Eta2 { get; init; }

    /// <summary>
    /// Gets the delivery status.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// Gets the delivery time window.
    /// </summary>
    [JsonPropertyName("delivery_time")]
    public DeliveryTime? DeliveryTime { get; init; }

    /// <summary>
    /// Gets the orders included in the delivery.
    /// </summary>
    [JsonPropertyName("orders")]
    public IReadOnlyList<Order>? Orders { get; init; }

    /// <summary>
    /// Gets the returned containers associated with the delivery.
    /// </summary>
    [JsonPropertyName("returned_containers")]
    public IReadOnlyList<ReturnedContainer>? ReturnedContainers { get; init; }

    /// <summary>
    /// Gets parcel data returned by the API.
    /// </summary>
    [JsonPropertyName("parcels")]
    public IReadOnlyList<JsonElement>? Parcels { get; init; }
}

/// <summary>
/// Represents a delivery vehicle.
/// </summary>
public sealed class Vehicle
{
    /// <summary>
    /// Gets the vehicle image URL.
    /// </summary>
    [JsonPropertyName("image")]
    public string? Image { get; init; }

    /// <summary>
    /// Gets the vehicle name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }
}

/// <summary>
/// Represents the driver assigned to a delivery.
/// </summary>
public sealed class DeliveryDriver
{
    /// <summary>
    /// Gets the driver name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Gets the driver photo URL.
    /// </summary>
    [JsonPropertyName("photo_url")]
    public string? PhotoUrl { get; init; }
}

/// <summary>
/// Represents a position sample in a delivery scenario.
/// </summary>
public sealed class ScenarioEntry
{
    /// <summary>
    /// Gets the scenario timestamp.
    /// </summary>
    [JsonPropertyName("ts")]
    public long Ts { get; init; }

    /// <summary>
    /// Gets the latitude.
    /// </summary>
    [JsonPropertyName("lat")]
    public double Lat { get; init; }

    /// <summary>
    /// Gets the longitude.
    /// </summary>
    [JsonPropertyName("lng")]
    public double Lng { get; init; }
}

/// <summary>
/// Represents a delivery tracking scenario.
/// </summary>
public sealed class DeliveryScenario
{
    /// <summary>
    /// Gets the scenario version.
    /// </summary>
    [JsonPropertyName("version")]
    public int Version { get; init; }

    /// <summary>
    /// Gets the scenario entries.
    /// </summary>
    [JsonPropertyName("scenario")]
    public IReadOnlyList<ScenarioEntry>? Scenario { get; init; }

    /// <summary>
    /// Gets the primary delivery vehicle.
    /// </summary>
    [JsonPropertyName("vehicle")]
    public Vehicle? Vehicle { get; init; }

    /// <summary>
    /// Gets the assigned driver.
    /// </summary>
    [JsonPropertyName("driver")]
    public DeliveryDriver? Driver { get; init; }

    /// <summary>
    /// Gets the trailer vehicles.
    /// </summary>
    [JsonPropertyName("trailers")]
    public IReadOnlyList<Vehicle>? Trailers { get; init; }

    /// <summary>
    /// Gets the destination address.
    /// </summary>
    [JsonPropertyName("destination")]
    public UserAddress? Destination { get; init; }
}

/// <summary>
/// Represents the current calculated position of a delivery.
/// </summary>
public sealed class DeliveryPosition
{
    /// <summary>
    /// Gets the position payload version.
    /// </summary>
    [JsonPropertyName("version")]
    public int Version { get; init; }

    /// <summary>
    /// Gets the scenario timestamp used for the position.
    /// </summary>
    [JsonPropertyName("scenario_ts")]
    public long ScenarioTs { get; init; }

    /// <summary>
    /// Gets the estimated arrival timestamp.
    /// </summary>
    [JsonPropertyName("eta")]
    public long Eta { get; init; }

    /// <summary>
    /// Gets the estimated arrival time window.
    /// </summary>
    [JsonPropertyName("eta_window")]
    public DeliveryTime? EtaWindow { get; init; }

    /// <summary>
    /// Gets the recommended polling interval.
    /// </summary>
    [JsonPropertyName("query_interval")]
    public int QueryInterval { get; init; }

    /// <summary>
    /// Gets a value indicating whether the scenario is currently in progress.
    /// </summary>
    [JsonPropertyName("scenario_in_progress")]
    public bool ScenarioInProgress { get; init; }
}
