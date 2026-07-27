using Picnic.Api.Internal;
using Picnic.Api.Models.App;
using Picnic.Api.Models.Fusion;
using Picnic.Api.Services.Interfaces;

namespace Picnic.Api.Services;

internal sealed class AppService(PicnicHttpClient httpClient) : IAppService
{
    public async Task<BootstrapData> GetBootstrapDataAsync(CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync("/bootstrap", cancellationToken: cancellationToken)).DeserializeOrThrow<BootstrapData>();

    public async Task<FusionPage> GetPageAsync(string pageId, CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync($"/pages/{pageId}", includePicnicHeaders: true, cancellationToken: cancellationToken)).DeserializeOrThrow<FusionPage>();

    public async Task<DeeplinkResolution> ResolveDeeplinkAsync(string url, CancellationToken cancellationToken = default)
        => (await httpClient.PostAsync("/deeplink/resolve", new { url }, includePicnicHeaders: true, cancellationToken: cancellationToken)).DeserializeOrThrow<DeeplinkResolution>();
}
