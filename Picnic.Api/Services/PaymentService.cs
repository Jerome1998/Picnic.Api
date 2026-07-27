using Picnic.Api.Internal;
using Picnic.Api.Models.Payment;
using Picnic.Api.Services.Interfaces;

namespace Picnic.Api.Services;

internal sealed class PaymentService(PicnicHttpClient httpClient) : IPaymentService
{
    public async Task<PaymentProfile> GetPaymentProfileAsync(CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync("/payment-profile", includePicnicHeaders: true, cancellationToken: cancellationToken)).DeserializeOrThrow<PaymentProfile>();

    public async Task<IReadOnlyList<WalletTransaction>> GetWalletTransactionsAsync(int pageNumber, CancellationToken cancellationToken = default)
        => (await httpClient.PostAsync("/wallet/transactions", new { page_number = pageNumber }, cancellationToken: cancellationToken)).DeserializeOrThrow<IReadOnlyList<WalletTransaction>>();

    public async Task<WalletTransactionDetails> GetWalletTransactionDetailsAsync(string walletTransactionId, CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync($"/wallet/transactions/{walletTransactionId}", cancellationToken: cancellationToken)).DeserializeOrThrow<WalletTransactionDetails>();
}
