using Picnic.Api.Models.Consent;

namespace Picnic.Api.Services.Interfaces;

/// <summary>
/// Defines consent-related operations.
/// </summary>
public interface IConsentService
{
    /// <summary>
    /// Retrieves available consent settings.
    /// </summary>
    /// <param name="general">When <see langword="true"/>, retrieves general consent settings.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A list of consent settings.</returns>
    Task<IReadOnlyList<ConsentSetting>> GetConsentSettingsAsync(bool general = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates consent settings.
    /// </summary>
    /// <param name="declarations">The consent declarations to set.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The result of the consent update operation.</returns>
    Task<SetConsentSettingsResult> SetConsentSettingsAsync(SetConsentSettingsInput declarations, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves consent requests for specific topics.
    /// </summary>
    /// <param name="consentTopics">The consent topics to query.</param>
    /// <param name="strategy">The retrieval strategy used by the API.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A list of consent requests.</returns>
    Task<IReadOnlyList<ConsentRequest>> GetConsentsAsync(IEnumerable<string> consentTopics, string strategy, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves general consent information.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The general consent request payload.</returns>
    Task<ConsentRequest> GetGeneralConsentsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates general consent declarations.
    /// </summary>
    /// <param name="declarations">The general consent declarations to set.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The API response payload for the update request.</returns>
    Task<object?> SetGeneralConsentsAsync(SetGeneralConsentsInput declarations, CancellationToken cancellationToken = default);
}
