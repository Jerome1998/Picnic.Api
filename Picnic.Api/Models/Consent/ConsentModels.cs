using System.Text.Json.Serialization;

namespace Picnic.Api.Models.Consent;

public sealed class ConsentSettingText
{
    [JsonPropertyName("title")]
    public string? Title { get; init; }

    [JsonPropertyName("text")]
    public string? Text { get; init; }

    [JsonPropertyName("dissent_text")]
    public string? DissentText { get; init; }

    [JsonPropertyName("timestamp")]
    public string? Timestamp { get; init; }
}

public sealed class ConsentSetting
{
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("text_id")]
    public string? TextId { get; init; }

    [JsonPropertyName("text_locale")]
    public string? TextLocale { get; init; }

    [JsonPropertyName("text")]
    public ConsentSettingText? Text { get; init; }

    [JsonPropertyName("established_decision")]
    public bool EstablishedDecision { get; init; }

    [JsonPropertyName("initial_state")]
    public bool InitialState { get; init; }
}

public sealed class ConsentDeclaration
{
    [JsonPropertyName("consent_request_text_id")]
    public string? ConsentRequestTextId { get; init; }

    [JsonPropertyName("consent_request_locale")]
    public string? ConsentRequestLocale { get; init; }

    [JsonPropertyName("agreement")]
    public bool Agreement { get; init; }
}

public sealed class SetConsentSettingsInput
{
    [JsonPropertyName("consent_declarations")]
    public IReadOnlyList<ConsentDeclaration>? ConsentDeclarations { get; init; }
}

public sealed class SetConsentSettingsResult
{
    [JsonPropertyName("consent_request_text_ids")]
    public IReadOnlyList<string>? ConsentRequestTextIds { get; init; }
}

public sealed class ConsentFormattedContent
{
    [JsonPropertyName("text/html")]
    public string? TextHtml { get; init; }

    [JsonPropertyName("text/plain")]
    public string? TextPlain { get; init; }

    [JsonPropertyName("dialog_flow")]
    public string? DialogFlow { get; init; }
}

public sealed class ConsentRequest
{
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("text_id")]
    public string? TextId { get; init; }

    [JsonPropertyName("text_locale")]
    public string? TextLocale { get; init; }

    [JsonPropertyName("formatted_content")]
    public ConsentFormattedContent? FormattedContent { get; init; }

    [JsonPropertyName("timestamp")]
    public string? Timestamp { get; init; }
}

public sealed class SetGeneralConsentsInput
{
    [JsonPropertyName("consent_declarations")]
    public IReadOnlyList<ConsentDeclaration>? ConsentDeclarations { get; init; }

    [JsonPropertyName("general_consent")]
    public bool GeneralConsent { get; init; }
}
