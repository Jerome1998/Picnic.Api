namespace Picnic.Api.Services.Interfaces;

/// <summary>
/// Defines user onboarding operations.
/// </summary>
public interface IUserOnboardingService
{
    /// <summary>
    /// Submits household details during user onboarding.
    /// </summary>
    /// <param name="details">The household details payload. The exact API shape is not specified by the upstream implementation.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task SetHouseholdDetailsAsync(IReadOnlyDictionary<string, object?> details, CancellationToken cancellationToken = default);

    /// <summary>
    /// Submits business details during user onboarding.
    /// </summary>
    /// <param name="details">The business details payload. The exact API shape is not specified by the upstream implementation.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task SetBusinessDetailsAsync(IReadOnlyDictionary<string, object?> details, CancellationToken cancellationToken = default);

    /// <summary>
    /// Subscribes the user to push notification topics during onboarding.
    /// </summary>
    /// <param name="topics">The push notification topics to subscribe to.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task SubscribePushAsync(IReadOnlyList<string> topics, CancellationToken cancellationToken = default);
}
