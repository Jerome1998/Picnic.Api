using Picnic.Api.Models.Cart;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Picnic.Api.Models.Payment;

public sealed class BankInformation
{
    [JsonPropertyName("bank_id")]
    public string? BankId { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }
}

public sealed class AvailablePaymentMethod
{
    [JsonPropertyName("available_banks")]
    public IReadOnlyList<BankInformation>? AvailableBanks { get; init; }

    [JsonPropertyName("payment_method")]
    public string? PaymentMethod { get; init; }
}

public sealed class PaymentMethodBrand
{
    [JsonPropertyName("brand")]
    public string? Brand { get; init; }

    [JsonPropertyName("display_name")]
    public string? DisplayName { get; init; }

    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; init; }
}

public sealed class PaymentMethod
{
    [JsonPropertyName("brands")]
    public IReadOnlyList<PaymentMethodBrand>? Brands { get; init; }

    [JsonPropertyName("data")]
    public JsonElement? Data { get; init; }

    [JsonPropertyName("display_name")]
    public string? DisplayName { get; init; }

    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; init; }

    [JsonPropertyName("payment_method")]
    public string? PaymentMethodType { get; init; }

    [JsonPropertyName("visibility")]
    public string? Visibility { get; init; }

    [JsonPropertyName("visibility_reason")]
    public string? VisibilityReason { get; init; }
}

public sealed class StoredPaymentOption
{
    [JsonPropertyName("account")]
    public string? Account { get; init; }

    [JsonPropertyName("brand")]
    public string? Brand { get; init; }

    [JsonPropertyName("display_name")]
    public string? DisplayName { get; init; }

    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; init; }

    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("payment_method")]
    public string? PaymentMethod { get; init; }
}

public sealed class PaymentProfile
{
    [JsonPropertyName("available_payment_method_item")]
    public JsonElement? AvailablePaymentMethodItem { get; init; }

    [JsonPropertyName("available_payment_methods")]
    public IReadOnlyList<AvailablePaymentMethod>? AvailablePaymentMethods { get; init; }

    [JsonPropertyName("checkout_banner")]
    public JsonElement? CheckoutBanner { get; init; }

    [JsonPropertyName("payment_methods")]
    public IReadOnlyList<PaymentMethod>? PaymentMethods { get; init; }

    [JsonPropertyName("preferred_payment_option_id")]
    public string? PreferredPaymentOptionId { get; init; }

    [JsonPropertyName("stored_payment_options")]
    public IReadOnlyList<StoredPaymentOption>? StoredPaymentOptions { get; init; }
}

public sealed class WalletTransaction
{
    [JsonPropertyName("account")]
    public string? Account { get; init; }

    [JsonPropertyName("amount_in_cents")]
    public int AmountInCents { get; init; }

    [JsonPropertyName("brand")]
    public string? Brand { get; init; }

    [JsonPropertyName("display_name")]
    public string? DisplayName { get; init; }

    [JsonPropertyName("domains")]
    public IReadOnlyList<string>? Domains { get; init; }

    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; init; }

    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("status")]
    public string? Status { get; init; }

    [JsonPropertyName("timestamp")]
    public long Timestamp { get; init; }

    [JsonPropertyName("transaction_method")]
    public string? TransactionMethod { get; init; }

    [JsonPropertyName("transaction_type")]
    public string? TransactionType { get; init; }
}

public sealed class ReturnedContainer
{
    [JsonPropertyName("localized_name")]
    public string? LocalizedName { get; init; }

    [JsonPropertyName("price")]
    public int Price { get; init; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }
}

public sealed class Deposit
{
    [JsonPropertyName("count")]
    public int Count { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("value")]
    public int Value { get; init; }
}

public sealed class WalletTransactionDetails
{
    [JsonPropertyName("amount_in_cents")]
    public int AmountInCents { get; init; }

    [JsonPropertyName("article_issue_refunds")]
    public IReadOnlyList<JsonElement>? ArticleIssueRefunds { get; init; }

    [JsonPropertyName("debt_resolution")]
    public JsonElement? DebtResolution { get; init; }

    [JsonPropertyName("delivery_debt")]
    public JsonElement? DeliveryDebt { get; init; }

    [JsonPropertyName("delivery_id")]
    public string? DeliveryId { get; init; }

    [JsonPropertyName("deposits")]
    public IReadOnlyList<Deposit>? Deposits { get; init; }

    [JsonPropertyName("fees")]
    public IReadOnlyList<JsonElement>? Fees { get; init; }

    [JsonPropertyName("payment_execution_timestamp")]
    public long PaymentExecutionTimestamp { get; init; }

    [JsonPropertyName("payment_method_icon_url")]
    public string? PaymentMethodIconUrl { get; init; }

    [JsonPropertyName("payment_option_account")]
    public string? PaymentOptionAccount { get; init; }

    [JsonPropertyName("payment_option_display_name")]
    public string? PaymentOptionDisplayName { get; init; }

    [JsonPropertyName("refunded_items")]
    public IReadOnlyList<JsonElement>? RefundedItems { get; init; }

    [JsonPropertyName("returned_containers")]
    public IReadOnlyList<ReturnedContainer>? ReturnedContainers { get; init; }

    [JsonPropertyName("shop_items")]
    public IReadOnlyList<OrderLine>? ShopItems { get; init; }

    [JsonPropertyName("transaction_method")]
    public string? TransactionMethod { get; init; }

    [JsonPropertyName("transaction_status")]
    public string? TransactionStatus { get; init; }

    [JsonPropertyName("transaction_type")]
    public string? TransactionType { get; init; }
}
