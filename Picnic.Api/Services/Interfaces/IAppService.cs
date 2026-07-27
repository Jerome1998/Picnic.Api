using Picnic.Api.Models.App;
using Picnic.Api.Models.Fusion;

namespace Picnic.Api.Services.Interfaces;

/// <summary>
/// Defines app-level operations for bootstrap and page resolution.
/// </summary>
public interface IAppService
{
    /// <summary>
    /// Retrieves bootstrap data required by the Picnic app experience.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The bootstrap data payload.</returns>
    Task<BootstrapData> GetBootstrapDataAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a Fusion page by page identifier.
    /// </summary>
    /// <param name="pageId">The page identifier.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The Fusion page payload.</returns>
    Task<FusionPage> GetPageAsync(string pageId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Resolves a Picnic deeplink URL to its target payload.
    /// </summary>
    /// <param name="url">The deeplink URL to resolve.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The deeplink resolution result.</returns>
    Task<DeeplinkResolution> ResolveDeeplinkAsync(string url, CancellationToken cancellationToken = default);
}
