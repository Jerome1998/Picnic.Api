using System.Text.Json;
using System.Text.Json.Serialization;

namespace Picnic.Api.Models.Fusion;

/// <summary>
/// Represents a Fusion UI component.
/// </summary>
public sealed class Component
{
    /// <summary>
    /// Gets the component type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// Gets additional component fields not mapped to explicit properties.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; init; }
}

/// <summary>
/// Represents an icon payload rendered by Fusion.
/// </summary>
public sealed class Icon
{
    /// <summary>
    /// Gets the PML version for the icon payload.
    /// </summary>
    [JsonPropertyName("pml_version")]
    public string? PmlVersion { get; init; }

    /// <summary>
    /// Gets the root component for the icon.
    /// </summary>
    [JsonPropertyName("component")]
    public Component? Component { get; init; }

    /// <summary>
    /// Gets the image variants used by the icon.
    /// </summary>
    [JsonPropertyName("images")]
    public Dictionary<string, string>? Images { get; init; }

    /// <summary>
    /// Gets tracking attributes associated with the icon.
    /// </summary>
    [JsonPropertyName("tracking_attributes")]
    public TrackingAttributes? TrackingAttributes { get; init; }
}

/// <summary>
/// Represents tracking metadata attached to Fusion content.
/// </summary>
public sealed class TrackingAttributes
{
    /// <summary>
    /// Gets the template variant identifier.
    /// </summary>
    [JsonPropertyName("template_variant_id")]
    public string? TemplateVariantId { get; init; }

    /// <summary>
    /// Gets the related entity identifiers.
    /// </summary>
    [JsonPropertyName("entity_ids")]
    public IReadOnlyList<string>? EntityIds { get; init; }
}

/// <summary>
/// Represents a Fusion page payload.
/// </summary>
public sealed class FusionPage
{
    /// <summary>
    /// Gets additional page fields not mapped to explicit properties.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; init; }
}

/// <summary>
/// Represents bootstrap data returned by the Fusion API.
/// </summary>
public sealed class BootstrapData
{
    /// <summary>
    /// Gets the default landing tab identifier.
    /// </summary>
    [JsonPropertyName("landing_tab_id")]
    public string? LandingTabId { get; init; }

    /// <summary>
    /// Gets the available tab payloads.
    /// </summary>
    [JsonPropertyName("tabs")]
    public IReadOnlyList<JsonElement>? Tabs { get; init; }

    /// <summary>
    /// Gets general message behavior configuration.
    /// </summary>
    [JsonPropertyName("general_message_behaviour")]
    public JsonElement? GeneralMessageBehaviour { get; init; }

    /// <summary>
    /// Gets Datadog configuration.
    /// </summary>
    [JsonPropertyName("datadog_config")]
    public JsonElement? DatadogConfig { get; init; }

    /// <summary>
    /// Gets Braze configuration.
    /// </summary>
    [JsonPropertyName("braze_config")]
    public JsonElement? BrazeConfig { get; init; }

    /// <summary>
    /// Gets in-app feature configuration.
    /// </summary>
    [JsonPropertyName("in_app_feature_config")]
    public JsonElement? InAppFeatureConfig { get; init; }

    /// <summary>
    /// Gets a value indicating whether the user is a first-time user.
    /// </summary>
    [JsonPropertyName("first_time_user")]
    public bool FirstTimeUser { get; init; }
}
