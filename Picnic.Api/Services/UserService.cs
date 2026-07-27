using Picnic.Api.Internal;
using Picnic.Api.Models.User;
using Picnic.Api.Services.Interfaces;

namespace Picnic.Api.Services;

internal sealed class UserService(PicnicHttpClient httpClient) : IUserService
{
    public async Task<User> GetUserDetailsAsync(CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync("/user", cancellationToken: cancellationToken)).DeserializeOrThrow<User>();

    public async Task<UserInfo> GetUserInfoAsync(CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync("/user-info", cancellationToken: cancellationToken)).DeserializeOrThrow<UserInfo>();

    public async Task<ProfileMenu> GetProfileMenuAsync(CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync("/profile-menu?fetch_mgm=true", includePicnicHeaders: true, cancellationToken: cancellationToken)).DeserializeOrThrow<ProfileMenu>();

    public async Task<object?> SubmitSuggestionAsync(string suggestion, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsync("/user/suggestion", new { suggestion }, cancellationToken: cancellationToken);
        return response.Deserialize<object>();
    }

    public async Task<object?> RegisterPushTokenAsync(string pushToken, string platform, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsync("/user/device/register_push", new { push_token = pushToken, platform }, cancellationToken: cancellationToken);
        return response.Deserialize<object>();
    }

    public async Task<object?> CheckForUpdatesAsync(CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsync("/update_check", new { }, includePicnicHeaders: true, cancellationToken: cancellationToken);
        return response.Deserialize<object>();
    }
}
