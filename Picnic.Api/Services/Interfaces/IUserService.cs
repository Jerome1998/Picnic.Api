using Picnic.Api.Models.User;

namespace Picnic.Api.Services.Interfaces;

/// <summary>
/// Defines user and profile-related operations.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Retrieves full user details.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The user details payload.</returns>
    Task<User> GetUserDetailsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves basic user information.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The user info payload.</returns>
    Task<UserInfo> GetUserInfoAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the user profile menu configuration.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The profile menu payload.</returns>
    Task<ProfileMenu> GetProfileMenuAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Submits a user suggestion.
    /// </summary>
    /// <param name="suggestion">The suggestion text to submit.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The API response payload for the suggestion request.</returns>
    Task<object?> SubmitSuggestionAsync(string suggestion, CancellationToken cancellationToken = default);

    /// <summary>
    /// Registers a push token for notifications.
    /// </summary>
    /// <param name="pushToken">The device push token.</param>
    /// <param name="platform">The platform name for the device.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The API response payload for the registration request.</returns>
    Task<object?> RegisterPushTokenAsync(string pushToken, string platform, CancellationToken cancellationToken = default);

    /// <summary>
    /// Checks whether app updates are available.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>The API response payload for the update check.</returns>
    Task<object?> CheckForUpdatesAsync(CancellationToken cancellationToken = default);
}
