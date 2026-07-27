using Picnic.Api.Models.Cart;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Picnic.Api.Models.Payment;

/// <summary>
/// Represents bank information for a payment method.
/// </summary>
public sealed class BankInformation
{
    /// <summary>
    /// Gets the bank identifier.
    /// </summary>
    [JsonPropertyName("bank_id")]
    public string? BankId { get; init; }

    /// <summary>
    /// Gets the bank name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }
}

/// <summary>
/// Represents a payment method currently available to the user.
/// </summary>
public sealed class AvailablePaymentMethod
{
    /// <summary>
    /// Gets the banks available for the payment method.
    /// </summary>
    [JsonPropertyName("available_banks")]
    public IReadOnlyList<BankInformation>? AvailableBanks { get; init; }

    /// <summary>
    /// Gets the payment method identifier.
    /// </summary>
    [JsonPropertyName("payment_method")]
    public string? PaymentMethod { get; init; }
}

/// <summary>
/// Represents a payment method brand.
/// </summary>
public sealed class PaymentMethodBrand
{
    /// <summary>
    /// Gets the brand identifier.
    /// </summary>
    [JsonPropertyName("brand")]
    public string? Brand { get; init; }

    /// <summary>
    /// Gets the display name of the brand.
    /// </summary>
    [JsonPropertyName("display_name")]
    public string? DisplayName { get; init; }

    /// <summary>
    /// Gets the brand icon URL.
    /// </summary>
    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; init; }
}

/// <summary>
/// Represents a supported payment method.
/// </summary>
public sealed class PaymentMethod
{
    /// <summary>
    /// Gets the supported brands for the payment method.
    /// </summary>
    [JsonPropertyName("brands")]
    public IReadOnlyList<PaymentMethodBrand>? Brands { get; init; }

    /// <summary>
    /// Gets additional payment method data.
    /// </summary>
    [JsonPropertyName("data")]
    public JsonElement? Data { get; init; }

    /// <summary>
    /// Gets the display name of the payment method.
    /// </summary>
    [JsonPropertyName("display_name")]
    public string? DisplayName { get; init; }

    /// <summary>
    /// Gets the payment method icon URL.
    /// </summary>
    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; init; }

    /// <summary>
    /// Gets the payment method type.
    /// </summary>
    [JsonPropertyName("payment_method")]
    public string? PaymentMethodType { get; init; }

    /// <summary>
    /// Gets the payment method visibility.
    /// </summary>
    [JsonPropertyName("visibility")]
    public string? Visibility { get; init; }

    /// <summary>
    /// Gets the reason for the current visibility state.
    /// </summary>
    [JsonPropertyName("visibility_reason")]
    public string? VisibilityReason { get; init; }
}

/// <summary>
/// Represents a stored payment option.
/// </summary>
public sealed class StoredPaymentOption
{
    /// <summary>
    /// Gets the redacted payment account.
    /// </summary>
    [JsonPropertyName("account")]
    public string? Account { get; init; }

    /// <summary>
    /// Gets the payment brand.
    /// </summary>
    [JsonPropertyName("brand")]
    public string? Brand { get; init; }

    /// <summary>
    /// Gets the display name of the stored payment option.
    /// </summary>
    [JsonPropertyName("display_name")]
    public string? DisplayName { get; init; }

    /// <summary>
    /// Gets the icon URL for the stored payment option.
    /// </summary>
    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; init; }

    /// <summary>
    /// Gets the stored payment option identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets the payment method identifier.
    /// </summary>
    [JsonPropertyName("payment_method")]
    public string? PaymentMethod { get; init; }
}

/// <summary>
/// Represents the user's payment profile.
/// </summary>
public sealed class PaymentProfile
{
    /// <summary>
    /// Gets the available payment method item payload.
    /// </summary>
    [JsonPropertyName("available_payment_method_item")]
    public JsonElement? AvailablePaymentMethodItem { get; init; }

    /// <summary>
    /// Gets the available payment methods.
    /// </summary>
    [JsonPropertyName("available_payment_methods")]
    public IReadOnlyList<AvailablePaymentMethod>? AvailablePaymentMethods { get; init; }

    /// <summary>
    /// Gets the checkout banner payload.
    /// </summary>
    [JsonPropertyName("checkout_banner")]
    public JsonElement? CheckoutBanner { get; init; }

    /// <summary>
    /// Gets the configured payment methods.
    /// </summary>
    [JsonPropertyName("payment_methods")]
    public IReadOnlyList<PaymentMethod>? PaymentMethods { get; init; }

    /// <summary>
    /// Gets the preferred stored payment option identifier.
    /// </summary>
    [JsonPropertyName("preferred_payment_option_id")]
    public string? PreferredPaymentOptionId { get; init; }

    /// <summary>
    /// Gets the stored payment options.
    /// </summary>
    [JsonPropertyName("stored_payment_options")]
    public IReadOnlyList<StoredPaymentOption>? StoredPaymentOptions { get; init; }
}

/// <summary>
/// Represents a wallet transaction summary.
/// </summary>
public sealed class WalletTransaction
{
    /// <summary>
    /// Gets the redacted payment account.
    /// </summary>
    [JsonPropertyName("account")]
    public string? Account { get; init; }

    /// <summary>
    /// Gets the transaction amount in cents.
    /// </summary>
    [JsonPropertyName("amount_in_cents")]
    public int AmountInCents { get; init; }

    /// <summary>
    /// Gets the payment brand.
    /// </summary>
    [JsonPropertyName("brand")]
    public string? Brand { get; init; }

    /// <summary>
    /// Gets the display name associated with the transaction.
    /// </summary>
    [JsonPropertyName("display_name")]
    public string? DisplayName { get; init; }

    /// <summary>
    /// Gets the domains associated with the transaction.
    /// </summary>
    [JsonPropertyName("domains")]
    public IReadOnlyList<string>? Domains { get; init; }

    /// <summary>
    /// Gets the icon URL associated with the transaction.
    /// </summary>
    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; init; }

    /// <summary>
    /// Gets the transaction identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets the transaction status.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// Gets the transaction timestamp.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public long Timestamp { get; init; }

    /// <summary>
    /// Gets the transaction method.
    /// </summary>
    [JsonPropertyName("transaction_method")]
    public string? TransactionMethod { get; init; }

    /// <summary>
    /// Gets the transaction type.
    /// </summary>
    [JsonPropertyName("transaction_type")]
    public string? TransactionType { get; init; }
}

/// <summary>
/// Represents a returned container included in a wallet transaction.
/// </summary>
public sealed class ReturnedContainer
{
    /// <summary>
    /// Gets the localized name of the container.
    /// </summary>
    [JsonPropertyName("localized_name")]
    public string? LocalizedName { get; init; }

    /// <summary>
    /// Gets the container price.
    /// </summary>
    [JsonPropertyName("price")]
    public int Price { get; init; }

    /// <summary>
    /// Gets the number of returned containers.
    /// </summary>
    [JsonPropertyName("quantity")]
    public int Quantity { get; init; }

    /// <summary>
    /// Gets the container type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }
}

/// <summary>
/// Represents a deposit entry in a wallet transaction.
/// </summary>
public sealed class Deposit
{
    /// <summary>
    /// Gets the number of deposit items.
    /// </summary>
    [JsonPropertyName("count")]
    public int Count { get; init; }

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
}

/// <summary>
/// Represents detailed information about a wallet transaction.
/// </summary>
public sealed class WalletTransactionDetails
{
    /// <summary>
    /// Gets the transaction amount in cents.
    /// </summary>
    [JsonPropertyName("amount_in_cents")]
    public int AmountInCents { get; init; }

    /// <summary>
    /// Gets refund payloads for article issues.
    /// </summary>
    [JsonPropertyName("article_issue_refunds")]
    public IReadOnlyList<JsonElement>? ArticleIssueRefunds { get; init; }

    /// <summary>
    /// Gets the debt resolution payload.
    /// </summary>
    [JsonPropertyName("debt_resolution")]
    public JsonElement? DebtResolution { get; init; }

    /// <summary>
    /// Gets the delivery debt payload.
    /// </summary>
    [JsonPropertyName("delivery_debt")]
    public JsonElement? DeliveryDebt { get; init; }

    /// <summary>
    /// Gets the related delivery identifier.
    /// </summary>
    [JsonPropertyName("delivery_id")]
    public string? DeliveryId { get; init; }

    /// <summary>
    /// Gets the deposits included in the transaction.
    /// </summary>
    [JsonPropertyName("deposits")]
    public IReadOnlyList<Deposit>? Deposits { get; init; }

    /// <summary>
    /// Gets any fees included in the transaction.
    /// </summary>
    [JsonPropertyName("fees")]
    public IReadOnlyList<JsonElement>? Fees { get; init; }

    /// <summary>
    /// Gets the payment execution timestamp.
    /// </summary>
    [JsonPropertyName("payment_execution_timestamp")]
    public long PaymentExecutionTimestamp { get; init; }

    /// <summary>
    /// Gets the payment method icon URL.
    /// </summary>
    [JsonPropertyName("payment_method_icon_url")]
    public string? PaymentMethodIconUrl { get; init; }

    /// <summary>
    /// Gets the redacted payment option account.
    /// </summary>
    [JsonPropertyName("payment_option_account")]
    public string? PaymentOptionAccount { get; init; }

    /// <summary>
    /// Gets the display name of the payment option.
    /// </summary>
    [JsonPropertyName("payment_option_display_name")]
    public string? PaymentOptionDisplayName { get; init; }

    /// <summary>
    /// Gets refunded item payloads.
    /// </summary>
    [JsonPropertyName("refunded_items")]
    public IReadOnlyList<JsonElement>? RefundedItems { get; init; }

    /// <summary>
    /// Gets the returned containers included in the transaction.
    /// </summary>
    [JsonPropertyName("returned_containers")]
    public IReadOnlyList<ReturnedContainer>? ReturnedContainers { get; init; }

    /// <summary>
    /// Gets the purchased shop items.
    /// </summary>
    [JsonPropertyName("shop_items")]
    public IReadOnlyList<OrderLine>? ShopItems { get; init; }

    /// <summary>
    /// Gets the transaction method.
    /// </summary>
    [JsonPropertyName("transaction_method")]
    public string? TransactionMethod { get; init; }

    /// <summary>
    /// Gets the transaction status.
    /// </summary>
    [JsonPropertyName("transaction_status")]
    public string? TransactionStatus { get; init; }

    /// <summary>
    /// Gets the transaction type.
    /// </summary>
    [JsonPropertyName("transaction_type")]
    public string? TransactionType { get; init; }
}
