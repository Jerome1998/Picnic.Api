using Picnic.Api.Models.Common;
using Picnic.Api.Models.Fusion;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Picnic.Api.Models.Cart;

/// <summary>
/// Represents an available delivery slot for the cart.
/// </summary>
public sealed class DeliverySlot
{
    /// <summary>
    /// Gets the delivery slot identifier.
    /// </summary>
    [JsonPropertyName("slot_id")]
    public string? SlotId { get; init; }

    /// <summary>
    /// Gets the hub identifier for the slot.
    /// </summary>
    [JsonPropertyName("hub_id")]
    public string? HubId { get; init; }

    /// <summary>
    /// Gets the fulfillment center identifier for the slot.
    /// </summary>
    [JsonPropertyName("fc_id")]
    public string? FcId { get; init; }

    /// <summary>
    /// Gets the slot window start time.
    /// </summary>
    [JsonPropertyName("window_start")]
    public string? WindowStart { get; init; }

    /// <summary>
    /// Gets the slot window end time.
    /// </summary>
    [JsonPropertyName("window_end")]
    public string? WindowEnd { get; init; }

    /// <summary>
    /// Gets the cutoff time for selecting the slot.
    /// </summary>
    [JsonPropertyName("cut_off_time")]
    public string? CutOffTime { get; init; }

    /// <summary>
    /// Gets a value indicating whether the slot is available.
    /// </summary>
    [JsonPropertyName("is_available")]
    public bool IsAvailable { get; init; }

    /// <summary>
    /// Gets a value indicating whether the slot is currently selected.
    /// </summary>
    [JsonPropertyName("selected")]
    public bool Selected { get; init; }

    /// <summary>
    /// Gets a value indicating whether the slot is reserved.
    /// </summary>
    [JsonPropertyName("reserved")]
    public bool Reserved { get; init; }

    /// <summary>
    /// Gets the minimum order value required for the slot.
    /// </summary>
    [JsonPropertyName("minimum_order_value")]
    public int? MinimumOrderValue { get; init; }

    /// <summary>
    /// Gets the reason the slot is unavailable, when applicable.
    /// </summary>
    [JsonPropertyName("unavailability_reason")]
    public string? UnavailabilityReason { get; init; }

    /// <summary>
    /// Gets the icon associated with the slot.
    /// </summary>
    [JsonPropertyName("icon")]
    public Icon? Icon { get; init; }

    /// <summary>
    /// Gets the characteristics associated with the slot.
    /// </summary>
    [JsonPropertyName("slot_characteristics")]
    public IReadOnlyList<string>? SlotCharacteristics { get; init; }
}

/// <summary>
/// Represents the slot currently selected for the cart.
/// </summary>
public sealed class SelectedSlot
{
    /// <summary>
    /// Gets the selected slot identifier.
    /// </summary>
    [JsonPropertyName("slot_id")]
    public string? SlotId { get; init; }

    /// <summary>
    /// Gets the selection state.
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; init; }
}

/// <summary>
/// Represents the message shown by the slot selector UI.
/// </summary>
public sealed class SlotSelectorMessage
{
    /// <summary>
    /// Gets the PML version used by the message payload.
    /// </summary>
    [JsonPropertyName("pml_version")]
    public string? PmlVersion { get; init; }

    /// <summary>
    /// Gets the root component of the message.
    /// </summary>
    [JsonPropertyName("component")]
    public Component? Component { get; init; }

    /// <summary>
    /// Gets the images referenced by the message.
    /// </summary>
    [JsonPropertyName("images")]
    public Dictionary<string, string>? Images { get; init; }

    /// <summary>
    /// Gets tracking attributes associated with the message.
    /// </summary>
    [JsonPropertyName("tracking_attributes")]
    public TrackingAttributes? TrackingAttributes { get; init; }
}

/// <summary>
/// Represents an article within an order line.
/// </summary>
public sealed class OrderArticle
{
    /// <summary>
    /// Gets the article type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// Gets the article identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets the article name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Gets the primary unit quantity label.
    /// </summary>
    [JsonPropertyName("unit_quantity")]
    public string? UnitQuantity { get; init; }

    /// <summary>
    /// Gets the secondary unit quantity label.
    /// </summary>
    [JsonPropertyName("unit_quantity_sub")]
    public string? UnitQuantitySub { get; init; }

    /// <summary>
    /// Gets the article price.
    /// </summary>
    [JsonPropertyName("price")]
    public int Price { get; init; }

    /// <summary>
    /// Gets the quantity-based price ranges.
    /// </summary>
    [JsonPropertyName("price_ranges")]
    public IReadOnlyList<PriceRange>? PriceRanges { get; init; }

    /// <summary>
    /// Gets decorators applied to the article.
    /// </summary>
    [JsonPropertyName("decorators")]
    public IReadOnlyList<Decorator>? Decorators { get; init; }

    /// <summary>
    /// Gets the maximum quantity that can be added.
    /// </summary>
    [JsonPropertyName("max_count")]
    public int MaxCount { get; init; }

    /// <summary>
    /// Gets the image identifiers for the article.
    /// </summary>
    [JsonPropertyName("image_ids")]
    public IReadOnlyList<string>? ImageIds { get; init; }

    /// <summary>
    /// Gets a value indicating whether the article is perishable.
    /// </summary>
    [JsonPropertyName("perishable")]
    public bool Perishable { get; init; }

    /// <summary>
    /// Gets the analytics contexts associated with the article.
    /// </summary>
    [JsonPropertyName("analytics_contexts")]
    public IReadOnlyList<JsonElement>? AnalyticsContexts { get; init; }

    /// <summary>
    /// Gets the selling unit contexts used for mutations.
    /// </summary>
    [JsonPropertyName("selling_unit_contexts_for_mutations")]
    public IReadOnlyList<JsonElement>? SellingUnitContextsForMutations { get; init; }
}

/// <summary>
/// Represents a line item in a cart or order.
/// </summary>
public sealed class OrderLine
{
    /// <summary>
    /// Gets the line item type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// Gets the line item identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets the articles contained in the line item.
    /// </summary>
    [JsonPropertyName("items")]
    public IReadOnlyList<OrderArticle>? Items { get; init; }

    /// <summary>
    /// Gets the price shown to the user for the line item.
    /// </summary>
    [JsonPropertyName("display_price")]
    public int DisplayPrice { get; init; }

    /// <summary>
    /// Gets the actual price of the line item.
    /// </summary>
    [JsonPropertyName("price")]
    public int Price { get; init; }

    /// <summary>
    /// Gets decorators applied to the line item.
    /// </summary>
    [JsonPropertyName("decorators")]
    public IReadOnlyList<Decorator>? Decorators { get; init; }
}

/// <summary>
/// Represents a deposit amount grouped by type.
/// </summary>
public sealed class DepositBreakdown
{
    /// <summary>
    /// Gets the deposit type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// Gets the deposit value.
    /// </summary>
    [JsonPropertyName("value")]
    public int Value { get; init; }

    /// <summary>
    /// Gets the number of deposited items.
    /// </summary>
    [JsonPropertyName("count")]
    public int Count { get; init; }
}

/// <summary>
/// Represents payment transaction details for an order.
/// </summary>
public sealed class TransactionInfo
{
    /// <summary>
    /// Gets the bank identifier.
    /// </summary>
    [JsonPropertyName("bank_id")]
    public string? BankId { get; init; }

    /// <summary>
    /// Gets the payment type.
    /// </summary>
    [JsonPropertyName("payment_type")]
    public string? PaymentType { get; init; }

    /// <summary>
    /// Gets the redacted IBAN used for the transaction.
    /// </summary>
    [JsonPropertyName("redacted_iban")]
    public string? RedactedIban { get; init; }

    /// <summary>
    /// Gets a value indicating whether the account is a refund account.
    /// </summary>
    [JsonPropertyName("refund_account")]
    public bool RefundAccount { get; init; }
}

/// <summary>
/// Represents an analytics item in the cart context.
/// </summary>
public sealed class CartAnalyticsItem
{
    /// <summary>
    /// Gets the related product identifier.
    /// </summary>
    [JsonPropertyName("product_id")]
    public string? ProductId { get; init; }

    /// <summary>
    /// Gets the product quantity.
    /// </summary>
    [JsonPropertyName("quantity")]
    public int Quantity { get; init; }

    /// <summary>
    /// Gets a value indicating whether the product is available.
    /// </summary>
    [JsonPropertyName("is_available")]
    public bool IsAvailable { get; init; }

    /// <summary>
    /// Gets a value indicating whether the product belongs to a recipe.
    /// </summary>
    [JsonPropertyName("is_in_recipe")]
    public bool IsInRecipe { get; init; }
}

/// <summary>
/// Represents analytics context data for the cart.
/// </summary>
public sealed class CartAnalyticsContextData
{
    /// <summary>
    /// Gets the analytics items included in the cart context.
    /// </summary>
    [JsonPropertyName("items_list")]
    public IReadOnlyList<CartAnalyticsItem>? ItemsList { get; init; }
}

/// <summary>
/// Represents the current shopping cart.
/// </summary>
public sealed class Cart
{
    /// <summary>
    /// Gets the cart type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// Gets the cart identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets the cart line items.
    /// </summary>
    [JsonPropertyName("items")]
    public IReadOnlyList<OrderLine>? Items { get; init; }

    /// <summary>
    /// Gets the available delivery slots for the cart.
    /// </summary>
    [JsonPropertyName("delivery_slots")]
    public IReadOnlyList<DeliverySlot>? DeliverySlots { get; init; }

    /// <summary>
    /// Gets the selected delivery slot.
    /// </summary>
    [JsonPropertyName("selected_slot")]
    public SelectedSlot? SelectedSlot { get; init; }

    /// <summary>
    /// Gets the slot selector message shown in the UI.
    /// </summary>
    [JsonPropertyName("slot_selector_message")]
    public SlotSelectorMessage? SlotSelectorMessage { get; init; }

    /// <summary>
    /// Gets the total number of items in the cart.
    /// </summary>
    [JsonPropertyName("total_count")]
    public int TotalCount { get; init; }

    /// <summary>
    /// Gets the cart total price.
    /// </summary>
    [JsonPropertyName("total_price")]
    public int TotalPrice { get; init; }

    /// <summary>
    /// Gets the total checkout price.
    /// </summary>
    [JsonPropertyName("checkout_total_price")]
    public int CheckoutTotalPrice { get; init; }

    /// <summary>
    /// Gets the total savings applied to the cart.
    /// </summary>
    [JsonPropertyName("total_savings")]
    public int? TotalSavings { get; init; }

    /// <summary>
    /// Gets the cart timestamp value returned by the API.
    /// </summary>
    [JsonPropertyName("mts")]
    public long Mts { get; init; }

    /// <summary>
    /// Gets the deposit breakdown for the cart.
    /// </summary>
    [JsonPropertyName("deposit_breakdown")]
    public IReadOnlyList<DepositBreakdown>? DepositBreakdown { get; init; }

    /// <summary>
    /// Gets decorator overrides keyed by item identifier.
    /// </summary>
    [JsonPropertyName("decorator_overrides")]
    public Dictionary<string, IReadOnlyList<Decorator>>? DecoratorOverrides { get; init; }

    /// <summary>
    /// Gets the state token for cart mutations.
    /// </summary>
    [JsonPropertyName("state_token")]
    public string? StateToken { get; init; }

    /// <summary>
    /// Gets additional fees applied to the cart.
    /// </summary>
    [JsonPropertyName("fees")]
    public IReadOnlyList<JsonElement>? Fees { get; init; }

    /// <summary>
    /// Gets the basket sections returned by the API.
    /// </summary>
    [JsonPropertyName("basket_sections")]
    public IReadOnlyList<JsonElement>? BasketSections { get; init; }

    /// <summary>
    /// Gets analytics context data for the cart.
    /// </summary>
    [JsonPropertyName("analytics_context_data")]
    public CartAnalyticsContextData? AnalyticsContextData { get; init; }

    /// <summary>
    /// Gets a value indicating whether the create-sellable banner should be shown.
    /// </summary>
    [JsonPropertyName("show_create_sellable_banner")]
    public bool ShowCreateSellableBanner { get; init; }

    /// <summary>
    /// Gets the membership savings applied to the cart.
    /// </summary>
    [JsonPropertyName("membership_savings")]
    public int MembershipSavings { get; init; }
}

/// <summary>
/// Represents an order derived from a cart.
/// </summary>
public sealed class Order
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
    /// Gets the order line items.
    /// </summary>
    [JsonPropertyName("items")]
    public IReadOnlyList<OrderLine>? Items { get; init; }

    /// <summary>
    /// Gets the total order price.
    /// </summary>
    [JsonPropertyName("total_price")]
    public int TotalPrice { get; init; }

    /// <summary>
    /// Gets the total checkout price for the order.
    /// </summary>
    [JsonPropertyName("checkout_total_price")]
    public int CheckoutTotalPrice { get; init; }

    /// <summary>
    /// Gets the total savings applied to the order.
    /// </summary>
    [JsonPropertyName("total_savings")]
    public int TotalSavings { get; init; }

    /// <summary>
    /// Gets the total deposit amount in the order.
    /// </summary>
    [JsonPropertyName("total_deposit")]
    public int TotalDeposit { get; init; }

    /// <summary>
    /// Gets a value indicating whether the order can be cancelled.
    /// </summary>
    [JsonPropertyName("cancellable")]
    public bool Cancellable { get; init; }

    /// <summary>
    /// Gets the order creation time.
    /// </summary>
    [JsonPropertyName("creation_time")]
    public string? CreationTime { get; init; }

    /// <summary>
    /// Gets the order status.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// Gets decorator overrides keyed by item identifier.
    /// </summary>
    [JsonPropertyName("decorator_overrides")]
    public Dictionary<string, IReadOnlyList<Decorator>>? DecoratorOverrides { get; init; }

    /// <summary>
    /// Gets the cancellation time, when available.
    /// </summary>
    [JsonPropertyName("cancellation_time")]
    public string? CancellationTime { get; init; }

    /// <summary>
    /// Gets payment transaction information for the order.
    /// </summary>
    [JsonPropertyName("transaction_info")]
    public TransactionInfo? TransactionInfo { get; init; }

    /// <summary>
    /// Gets the slot selector message for the order.
    /// </summary>
    [JsonPropertyName("slot_selector_message")]
    public SlotSelectorMessage? SlotSelectorMessage { get; init; }

    /// <summary>
    /// Gets the deposit breakdown for the order.
    /// </summary>
    [JsonPropertyName("deposit_breakdown")]
    public IReadOnlyList<DepositBreakdown>? DepositBreakdown { get; init; }

    /// <summary>
    /// Gets additional fees applied to the order.
    /// </summary>
    [JsonPropertyName("fees")]
    public IReadOnlyList<JsonElement>? Fees { get; init; }

    /// <summary>
    /// Gets the basket sections returned for the order.
    /// </summary>
    [JsonPropertyName("basket_sections")]
    public IReadOnlyList<JsonElement>? BasketSections { get; init; }

    /// <summary>
    /// Gets analytics context data for the order.
    /// </summary>
    [JsonPropertyName("analytics_context_data")]
    public JsonElement? AnalyticsContextData { get; init; }

    /// <summary>
    /// Gets the membership savings applied to the order.
    /// </summary>
    [JsonPropertyName("membership_savings")]
    public int? MembershipSavings { get; init; }
}

/// <summary>
/// Represents the result of retrieving delivery slot information.
/// </summary>
public sealed class GetDeliverySlotsResult
{
    /// <summary>
    /// Gets the available delivery slots.
    /// </summary>
    [JsonPropertyName("delivery_slots")]
    public IReadOnlyList<DeliverySlot>? DeliverySlots { get; init; }

    /// <summary>
    /// Gets the slot selector message.
    /// </summary>
    [JsonPropertyName("slot_selector_message")]
    public SlotSelectorMessage? SlotSelectorMessage { get; init; }

    /// <summary>
    /// Gets the currently selected slot.
    /// </summary>
    [JsonPropertyName("selected_slot")]
    public SelectedSlot? SelectedSlot { get; init; }
}

/// <summary>
/// Represents checkout status information.
/// </summary>
public sealed class OrderStatus
{
    /// <summary>
    /// Gets the current checkout status.
    /// </summary>
    [JsonPropertyName("checkout_status")]
    public string? CheckoutStatus { get; init; }
}

/// <summary>
/// Represents the minimum order value for a specific user slot.
/// </summary>
public sealed class UserSlotMinimumOrderValue
{
    /// <summary>
    /// Gets the slot identifier.
    /// </summary>
    [JsonPropertyName("slot_id")]
    public string? SlotId { get; init; }

    /// <summary>
    /// Gets the minimum order value for the slot.
    /// </summary>
    [JsonPropertyName("minimum_order_value")]
    public int MinimumOrderValue { get; init; }
}

/// <summary>
/// Represents a successful checkout confirmation.
/// </summary>
public sealed class CheckoutConfirmation
{
    /// <summary>
    /// Gets the created order identifier.
    /// </summary>
    [JsonPropertyName("order_id")]
    public string? OrderId { get; init; }

    /// <summary>
    /// Gets the confirmed delivery slot.
    /// </summary>
    [JsonPropertyName("delivery_slot")]
    public DeliverySlot? DeliverySlot { get; init; }

    /// <summary>
    /// Gets the analytics payload returned with the confirmation.
    /// </summary>
    [JsonPropertyName("analytics")]
    public JsonElement? Analytics { get; init; }
}
