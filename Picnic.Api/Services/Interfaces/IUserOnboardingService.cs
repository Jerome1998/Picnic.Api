using Picnic.Api.Models.UserOnboarding;

namespace Picnic.Api.Services.Interfaces;

/// <summary>
/// Defines user onboarding operations including household and business setup.
/// </summary>
public interface IUserOnboardingService
{
    /// <summary>
    /// Retrieves the current onboarding status for the user.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The onboarding status.</returns>
    Task<OnboardingStatus> GetOnboardingStatusAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves household information for the current user.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The household information.</returns>
    Task<HouseholdInfo> GetHouseholdInfoAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates household information.
    /// </summary>
    /// <param name="request">The household update request.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The updated household information.</returns>
    Task<HouseholdInfo> UpdateHouseholdInfoAsync(UpdateHouseholdRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves business information if the user is set up as a business account.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The business information.</returns>
    Task<BusinessInfo> GetBusinessInfoAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates business information.
    /// </summary>
    /// <param name="request">The business update request.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The updated business information.</returns>
    Task<BusinessInfo> UpdateBusinessInfoAsync(UpdateBusinessRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the current push notification subscription settings.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The push subscription settings.</returns>
    Task<PushSubscription> GetPushSubscriptionAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates push notification subscription settings.
    /// </summary>
    /// <param name="request">The push subscription update request.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The updated push subscription settings.</returns>
    Task<PushSubscription> UpdatePushSubscriptionAsync(UpdatePushSubscriptionRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Completes a step in the onboarding process.
    /// </summary>
    /// <param name="stepName">The name of the onboarding step to complete.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task CompleteOnboardingStepAsync(string stepName, CancellationToken cancellationToken = default);
}
