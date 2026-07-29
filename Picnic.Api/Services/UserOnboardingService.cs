using Picnic.Api.Internal;
using Picnic.Api.Models.UserOnboarding;
using Picnic.Api.Services.Interfaces;

namespace Picnic.Api.Services;

internal sealed class UserOnboardingService(PicnicHttpClient httpClient) : IUserOnboardingService
{
    /// <summary>
    /// Retrieves the current onboarding status for the user.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The onboarding status.</returns>
    public async Task<OnboardingStatus> GetOnboardingStatusAsync(CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync(
            "/user/onboarding/status",
            cancellationToken: cancellationToken)).DeserializeOrThrow<OnboardingStatus>();

    /// <summary>
    /// Retrieves household information for the current user.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The household information.</returns>
    public async Task<HouseholdInfo> GetHouseholdInfoAsync(CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync(
            "/user/onboarding/household",
            cancellationToken: cancellationToken)).DeserializeOrThrow<HouseholdInfo>();

    /// <summary>
    /// Updates household information.
    /// </summary>
    /// <param name="request">The household update request.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The updated household information.</returns>
    public async Task<HouseholdInfo> UpdateHouseholdInfoAsync(UpdateHouseholdRequest request, CancellationToken cancellationToken = default)
        => (await httpClient.PutAsync(
            "/user/onboarding/household",
            request,
            cancellationToken: cancellationToken)).DeserializeOrThrow<HouseholdInfo>();

    /// <summary>
    /// Retrieves business information if the user is set up as a business account.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The business information.</returns>
    public async Task<BusinessInfo> GetBusinessInfoAsync(CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync(
            "/user/onboarding/business",
            cancellationToken: cancellationToken)).DeserializeOrThrow<BusinessInfo>();

    /// <summary>
    /// Updates business information.
    /// </summary>
    /// <param name="request">The business update request.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The updated business information.</returns>
    public async Task<BusinessInfo> UpdateBusinessInfoAsync(UpdateBusinessRequest request, CancellationToken cancellationToken = default)
        => (await httpClient.PutAsync(
            "/user/onboarding/business",
            request,
            cancellationToken: cancellationToken)).DeserializeOrThrow<BusinessInfo>();

    /// <summary>
    /// Retrieves the current push notification subscription settings.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The push subscription settings.</returns>
    public async Task<PushSubscription> GetPushSubscriptionAsync(CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync(
            "/user/onboarding/push-subscription",
            cancellationToken: cancellationToken)).DeserializeOrThrow<PushSubscription>();

    /// <summary>
    /// Updates push notification subscription settings.
    /// </summary>
    /// <param name="request">The push subscription update request.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The updated push subscription settings.</returns>
    public async Task<PushSubscription> UpdatePushSubscriptionAsync(UpdatePushSubscriptionRequest request, CancellationToken cancellationToken = default)
        => (await httpClient.PutAsync(
            "/user/onboarding/push-subscription",
            request,
            cancellationToken: cancellationToken)).DeserializeOrThrow<PushSubscription>();

    /// <summary>
    /// Completes a step in the onboarding process.
    /// </summary>
    /// <param name="stepName">The name of the onboarding step to complete.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task CompleteOnboardingStepAsync(string stepName, CancellationToken cancellationToken = default)
    {
        var request = new { step = stepName };
        await httpClient.PostAsync(
            "/user/onboarding/complete-step",
            request,
            cancellationToken: cancellationToken);
    }
}
