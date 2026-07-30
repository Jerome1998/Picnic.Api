using Picnic.Api.Internal;
using Picnic.Api.Models.UserOnboarding;
using Picnic.Api.Services.Interfaces;

namespace Picnic.Api.Services;

internal sealed class UserOnboardingService(PicnicHttpClient httpClient) : IUserOnboardingService
{
    /// <summary>
    /// Submits household details during user onboarding.
    /// </summary>
    /// <param name="details">The household details payload.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task SetHouseholdDetailsAsync(IReadOnlyDictionary<string, object?> details, CancellationToken cancellationToken = default)
    {
        await httpClient.PostAsync("/user-onboarding/household-details", details, cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Submits business details during user onboarding.
    /// </summary>
    /// <param name="details">The business details payload.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task SetBusinessDetailsAsync(IReadOnlyDictionary<string, object?> details, CancellationToken cancellationToken = default)
    {
        await httpClient.PostAsync("/user-onboarding/business-details", details, cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Subscribes the user to push notification topics during onboarding.
    /// </summary>
    /// <param name="topics">The push notification topics to subscribe to.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task SubscribePushAsync(IReadOnlyList<string> topics, CancellationToken cancellationToken = default)
    {
        var request = new SubscribePushRequest { Topics = topics };
        await httpClient.PostAsync("/user-onboarding/subscribe-push", request, cancellationToken: cancellationToken);
    }
}
