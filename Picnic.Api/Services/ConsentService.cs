using Picnic.Api.Internal;
using Picnic.Api.Models.Consent;
using Picnic.Api.Services.Interfaces;

namespace Picnic.Api.Services;

internal sealed class ConsentService(PicnicHttpClient httpClient) : IConsentService
{
    public async Task<IReadOnlyList<ConsentSetting>> GetConsentSettingsAsync(bool general = false, CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync($"/consents{(general ? "/general" : string.Empty)}/settings-page", cancellationToken: cancellationToken)).DeserializeOrThrow<IReadOnlyList<ConsentSetting>>();

    public async Task<SetConsentSettingsResult> SetConsentSettingsAsync(SetConsentSettingsInput declarations, CancellationToken cancellationToken = default)
        => (await httpClient.PutAsync("/consents", declarations, cancellationToken: cancellationToken)).DeserializeOrThrow<SetConsentSettingsResult>();

    public async Task<IReadOnlyList<ConsentRequest>> GetConsentsAsync(IEnumerable<string> consentTopics, string strategy, CancellationToken cancellationToken = default)
    {
        string query = BuildConsentsQuery(consentTopics, strategy);
        return (await httpClient.GetAsync($"/consents?{query}", cancellationToken: cancellationToken)).DeserializeOrThrow<IReadOnlyList<ConsentRequest>>();
    }

    public async Task<ConsentRequest> GetGeneralConsentsAsync(CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync("/consents/general", cancellationToken: cancellationToken)).DeserializeOrThrow<ConsentRequest>();

    public async Task<object?> SetGeneralConsentsAsync(SetGeneralConsentsInput declarations, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PutAsync("/consents/general", declarations, cancellationToken: cancellationToken);
        return response.Deserialize<object>();
    }

    private static string BuildConsentsQuery(IEnumerable<string> consentTopics, string strategy)
    {
        var queryParts = consentTopics
            .Select(topic => $"consent_topics={Uri.EscapeDataString(topic)}")
            .ToList();

        queryParts.Add($"strategy={Uri.EscapeDataString(strategy)}");
        return string.Join("&", queryParts);
    }
}
