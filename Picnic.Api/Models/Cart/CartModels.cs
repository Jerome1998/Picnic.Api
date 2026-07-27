using Picnic.Api.Models.Common;
using Picnic.Api.Models.Fusion;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Picnic.Api.Models.Cart;

public sealed class DeliverySlot
{
    [JsonPropertyName("slot_id")]
    public string? SlotId { get; init; }

    [JsonPropertyName("hub_id")]
    public string? HubId { get; init; }

    [JsonPropertyName("fc_id")]
    public string? FcId { get; init; }

    [JsonPropertyName("window_start")]
    public string? WindowStart { get; init; }

    [JsonPropertyName("window_end")]
    public string? WindowEnd { get; init; }

    [JsonPropertyName("cut_off_time")]
    public string? CutOffTime { get; init; }

    [JsonPropertyName("is_available")]
    public bool IsAvailable { get; init; }

    [JsonPropertyName("selected")]
    public bool Selected { get; init; }

    [JsonPropertyName("reserved")]
    public bool Reserved { get; init; }

    [JsonPropertyName("minimum_order_value")]
    public int? MinimumOrderValue { get; init; }

    [JsonPropertyName("unavailability_reason")]
    public string? UnavailabilityReason { get; init; }

    [JsonPropertyName("icon")]
    public Icon? Icon { get; init; }

    [JsonPropertyName("slot_characteristics")]
    public IReadOnlyList<string>? SlotCharacteristics { get; init; }
}

public sealed class SelectedSlot
{
    [JsonPropertyName("slot_id")]
    public string? SlotId { get; init; }

    [JsonPropertyName("state")]
    public string? State { get; init; }
}

public sealed class SlotSelectorMessage
{
    [JsonPropertyName("pml_version")]
    public string? PmlVersion { get; init; }

    [JsonPropertyName("component")]
    public Component? Component { get; init; }

    [JsonPropertyName("images")]
    public Dictionary<string, string>? Images { get; init; }

    [JsonPropertyName("tracking_attributes")]
    public TrackingAttributes? TrackingAttributes { get; init; }
}

public sealed class OrderArticle
{
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("unit_quantity")]
    public string? UnitQuantity { get; init; }

    [JsonPropertyName("unit_quantity_sub")]
    public string? UnitQuantitySub { get; init; }

    [JsonPropertyName("price")]
    public int Price { get; init; }

    [JsonPropertyName("price_ranges")]
    public IReadOnlyList<PriceRange>? PriceRanges { get; init; }

    [JsonPropertyName("decorators")]
    public IReadOnlyList<Decorator>? Decorators { get; init; }

    [JsonPropertyName("max_count")]
    public int MaxCount { get; init; }

    [JsonPropertyName("image_ids")]
    public IReadOnlyList<string>? ImageIds { get; init; }

    [JsonPropertyName("perishable")]
    public bool Perishable { get; init; }

    [JsonPropertyName("analytics_contexts")]
    public IReadOnlyList<JsonElement>? AnalyticsContexts { get; init; }

    [JsonPropertyName("selling_unit_contexts_for_mutations")]
    public IReadOnlyList<JsonElement>? SellingUnitContextsForMutations { get; init; }
}

public sealed class OrderLine
{
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("items")]
    public IReadOnlyList<OrderArticle>? Items { get; init; }

    [JsonPropertyName("display_price")]
    public int DisplayPrice { get; init; }

    [JsonPropertyName("price")]
    public int Price { get; init; }

    [JsonPropertyName("decorators")]
    public IReadOnlyList<Decorator>? Decorators { get; init; }
}

public sealed class DepositBreakdown
{
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("value")]
    public int Value { get; init; }

    [JsonPropertyName("count")]
    public int Count { get; init; }
}

public sealed class TransactionInfo
{
    [JsonPropertyName("bank_id")]
    public string? BankId { get; init; }

    [JsonPropertyName("payment_type")]
    public string? PaymentType { get; init; }

    [JsonPropertyName("redacted_iban")]
    public string? RedactedIban { get; init; }

    [JsonPropertyName("refund_account")]
    public bool RefundAccount { get; init; }
}

public sealed class CartAnalyticsItem
{
    [JsonPropertyName("product_id")]
    public string? ProductId { get; init; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; init; }

    [JsonPropertyName("is_available")]
    public bool IsAvailable { get; init; }

    [JsonPropertyName("is_in_recipe")]
    public bool IsInRecipe { get; init; }
}

public sealed class CartAnalyticsContextData
{
    [JsonPropertyName("items_list")]
    public IReadOnlyList<CartAnalyticsItem>? ItemsList { get; init; }
}

public sealed class Cart
{
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("items")]
    public IReadOnlyList<OrderLine>? Items { get; init; }

    [JsonPropertyName("delivery_slots")]
    public IReadOnlyList<DeliverySlot>? DeliverySlots { get; init; }

    [JsonPropertyName("selected_slot")]
    public SelectedSlot? SelectedSlot { get; init; }

    [JsonPropertyName("slot_selector_message")]
    public SlotSelectorMessage? SlotSelectorMessage { get; init; }

    [JsonPropertyName("total_count")]
    public int TotalCount { get; init; }

    [JsonPropertyName("total_price")]
    public int TotalPrice { get; init; }

    [JsonPropertyName("checkout_total_price")]
    public int CheckoutTotalPrice { get; init; }

    [JsonPropertyName("total_savings")]
    public int? TotalSavings { get; init; }

    [JsonPropertyName("mts")]
    public long Mts { get; init; }

    [JsonPropertyName("deposit_breakdown")]
    public IReadOnlyList<DepositBreakdown>? DepositBreakdown { get; init; }

    [JsonPropertyName("decorator_overrides")]
    public Dictionary<string, IReadOnlyList<Decorator>>? DecoratorOverrides { get; init; }

    [JsonPropertyName("state_token")]
    public string? StateToken { get; init; }

    [JsonPropertyName("fees")]
    public IReadOnlyList<JsonElement>? Fees { get; init; }

    [JsonPropertyName("basket_sections")]
    public IReadOnlyList<JsonElement>? BasketSections { get; init; }

    [JsonPropertyName("analytics_context_data")]
    public CartAnalyticsContextData? AnalyticsContextData { get; init; }

    [JsonPropertyName("show_create_sellable_banner")]
    public bool ShowCreateSellableBanner { get; init; }

    [JsonPropertyName("membership_savings")]
    public int MembershipSavings { get; init; }
}

public sealed class Order
{
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("items")]
    public IReadOnlyList<OrderLine>? Items { get; init; }

    [JsonPropertyName("total_price")]
    public int TotalPrice { get; init; }

    [JsonPropertyName("checkout_total_price")]
    public int CheckoutTotalPrice { get; init; }

    [JsonPropertyName("total_savings")]
    public int TotalSavings { get; init; }

    [JsonPropertyName("total_deposit")]
    public int TotalDeposit { get; init; }

    [JsonPropertyName("cancellable")]
    public bool Cancellable { get; init; }

    [JsonPropertyName("creation_time")]
    public string? CreationTime { get; init; }

    [JsonPropertyName("status")]
    public string? Status { get; init; }

    [JsonPropertyName("decorator_overrides")]
    public Dictionary<string, IReadOnlyList<Decorator>>? DecoratorOverrides { get; init; }

    [JsonPropertyName("cancellation_time")]
    public string? CancellationTime { get; init; }

    [JsonPropertyName("transaction_info")]
    public TransactionInfo? TransactionInfo { get; init; }

    [JsonPropertyName("slot_selector_message")]
    public SlotSelectorMessage? SlotSelectorMessage { get; init; }

    [JsonPropertyName("deposit_breakdown")]
    public IReadOnlyList<DepositBreakdown>? DepositBreakdown { get; init; }

    [JsonPropertyName("fees")]
    public IReadOnlyList<JsonElement>? Fees { get; init; }

    [JsonPropertyName("basket_sections")]
    public IReadOnlyList<JsonElement>? BasketSections { get; init; }

    [JsonPropertyName("analytics_context_data")]
    public JsonElement? AnalyticsContextData { get; init; }

    [JsonPropertyName("membership_savings")]
    public int? MembershipSavings { get; init; }
}

public sealed class GetDeliverySlotsResult
{
    [JsonPropertyName("delivery_slots")]
    public IReadOnlyList<DeliverySlot>? DeliverySlots { get; init; }

    [JsonPropertyName("slot_selector_message")]
    public SlotSelectorMessage? SlotSelectorMessage { get; init; }

    [JsonPropertyName("selected_slot")]
    public SelectedSlot? SelectedSlot { get; init; }
}

public sealed class OrderStatus
{
    [JsonPropertyName("checkout_status")]
    public string? CheckoutStatus { get; init; }
}

public sealed class UserSlotMinimumOrderValue
{
    [JsonPropertyName("slot_id")]
    public string? SlotId { get; init; }

    [JsonPropertyName("minimum_order_value")]
    public int MinimumOrderValue { get; init; }
}

public sealed class CheckoutConfirmation
{
    [JsonPropertyName("order_id")]
    public string? OrderId { get; init; }

    [JsonPropertyName("delivery_slot")]
    public DeliverySlot? DeliverySlot { get; init; }

    [JsonPropertyName("analytics")]
    public JsonElement? Analytics { get; init; }
}
