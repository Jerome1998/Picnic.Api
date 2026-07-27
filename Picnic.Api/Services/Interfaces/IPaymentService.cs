using Picnic.Api.Models.Payment;

namespace Picnic.Api.Services.Interfaces;

/// <summary>
/// Defines payment and wallet-related operations.
/// </summary>
public interface IPaymentService
{
    /// <summary>
    /// Retrieves the payment profile for the authenticated user.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The payment profile.</returns>
    Task<PaymentProfile> GetPaymentProfileAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves wallet transactions for a specific page.
    /// </summary>
    /// <param name="pageNumber">The page number to retrieve.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A list of wallet transactions.</returns>
    Task<IReadOnlyList<WalletTransaction>> GetWalletTransactionsAsync(int pageNumber, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves details for a specific wallet transaction.
    /// </summary>
    /// <param name="walletTransactionId">The wallet transaction identifier.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The wallet transaction details.</returns>
    Task<WalletTransactionDetails> GetWalletTransactionDetailsAsync(string walletTransactionId, CancellationToken cancellationToken = default);
}
