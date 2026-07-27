using System.Text.Json.Serialization;

namespace Picnic.Api.Models.Consent;

/// <summary>
/// Represents localized text content for a consent setting.
/// </summary>
public sealed class ConsentSettingText
{
    /// <summary>
    /// Gets the consent title.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; init; }

    /// <summary>
    /// Gets the consent text.
    /// </summary>
    [JsonPropertyName("text")]
    public string? Text { get; init; }

    /// <summary>
    /// Gets the text shown when the user dissents.
    /// </summary>
    [JsonPropertyName("dissent_text")]
    public string? DissentText { get; init; }

    /// <summary>
    /// Gets the timestamp associated with the text version.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public string? Timestamp { get; init; }
}

/// <summary>
/// Represents a consent setting available to the user.
/// </summary>
public sealed class ConsentSetting
{
    /// <summary>
    /// Gets the consent setting type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// Gets the consent setting identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets the text identifier for the setting.
    /// </summary>
    [JsonPropertyName("text_id")]
    public string? TextId { get; init; }

    /// <summary>
    /// Gets the locale of the consent text.
    /// </summary>
    [JsonPropertyName("text_locale")]
    public string? TextLocale { get; init; }

    /// <summary>
    /// Gets the localized consent text details.
    /// </summary>
    [JsonPropertyName("text")]
    public ConsentSettingText? Text { get; init; }

    /// <summary>
    /// Gets a value indicating whether a decision was already established.
    /// </summary>
    [JsonPropertyName("established_decision")]
    public bool EstablishedDecision { get; init; }

    /// <summary>
    /// Gets the initial enabled state for the consent setting.
    /// </summary>
    [JsonPropertyName("initial_state")]
    public bool InitialState { get; init; }
}

/// <summary>
/// Represents a user's response to a consent request.
/// </summary>
public sealed class ConsentDeclaration
{
    /// <summary>
    /// Gets the consent request text identifier.
    /// </summary>
    [JsonPropertyName("consent_request_text_id")]
    public string? ConsentRequestTextId { get; init; }

    /// <summary>
    /// Gets the locale of the consent request text.
    /// </summary>
    [JsonPropertyName("consent_request_locale")]
    public string? ConsentRequestLocale { get; init; }

    /// <summary>
    /// Gets a value indicating whether the user agreed.
    /// </summary>
    [JsonPropertyName("agreement")]
    public bool Agreement { get; init; }
}

/// <summary>
/// Represents the payload used to update consent settings.
/// </summary>
public sealed class SetConsentSettingsInput
{
    /// <summary>
    /// Gets the consent declarations to submit.
    /// </summary>
    [JsonPropertyName("consent_declarations")]
    public IReadOnlyList<ConsentDeclaration>? ConsentDeclarations { get; init; }
}

/// <summary>
/// Represents the result of updating consent settings.
/// </summary>
public sealed class SetConsentSettingsResult
{
    /// <summary>
    /// Gets the consent request text identifiers affected by the update.
    /// </summary>
    [JsonPropertyName("consent_request_text_ids")]
    public IReadOnlyList<string>? ConsentRequestTextIds { get; init; }
}

/// <summary>
/// Represents formatted consent content in multiple formats.
/// </summary>
public sealed class ConsentFormattedContent
{
    /// <summary>
    /// Gets the HTML representation of the content.
    /// </summary>
    [JsonPropertyName("text/html")]
    public string? TextHtml { get; init; }

    /// <summary>
    /// Gets the plain text representation of the content.
    /// </summary>
    [JsonPropertyName("text/plain")]
    public string? TextPlain { get; init; }

    /// <summary>
    /// Gets the dialog flow identifier.
    /// </summary>
    [JsonPropertyName("dialog_flow")]
    public string? DialogFlow { get; init; }
}

/// <summary>
/// Represents a consent request returned by the API.
/// </summary>
public sealed class ConsentRequest
{
    /// <summary>
    /// Gets the consent request type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// Gets the consent request identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets the text identifier for the request.
    /// </summary>
    [JsonPropertyName("text_id")]
    public string? TextId { get; init; }

    /// <summary>
    /// Gets the locale of the request text.
    /// </summary>
    [JsonPropertyName("text_locale")]
    public string? TextLocale { get; init; }

    /// <summary>
    /// Gets the formatted content for the request.
    /// </summary>
    [JsonPropertyName("formatted_content")]
    public ConsentFormattedContent? FormattedContent { get; init; }

    /// <summary>
    /// Gets the request timestamp.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public string? Timestamp { get; init; }
}

/// <summary>
/// Represents the payload used to update general consent decisions.
/// </summary>
public sealed class SetGeneralConsentsInput
{
    /// <summary>
    /// Gets the consent declarations to submit.
    /// </summary>
    [JsonPropertyName("consent_declarations")]
    public IReadOnlyList<ConsentDeclaration>? ConsentDeclarations { get; init; }

    /// <summary>
    /// Gets a value indicating whether general consent is granted.
    /// </summary>
    [JsonPropertyName("general_consent")]
    public bool GeneralConsent { get; init; }
}
