using System.Text.Json;
using System.Text.Json.Serialization;

namespace Picnic.Api.Models.Fusion;

public sealed class Component
{
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; init; }
}

public sealed class Icon
{
    [JsonPropertyName("pml_version")]
    public string? PmlVersion { get; init; }

    [JsonPropertyName("component")]
    public Component? Component { get; init; }

    [JsonPropertyName("images")]
    public Dictionary<string, string>? Images { get; init; }

    [JsonPropertyName("tracking_attributes")]
    public TrackingAttributes? TrackingAttributes { get; init; }
}

public sealed class TrackingAttributes
{
    [JsonPropertyName("template_variant_id")]
    public string? TemplateVariantId { get; init; }

    [JsonPropertyName("entity_ids")]
    public IReadOnlyList<string>? EntityIds { get; init; }
}

public sealed class FusionPage
{
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; init; }
}

public sealed class BootstrapData
{
    [JsonPropertyName("landing_tab_id")]
    public string? LandingTabId { get; init; }

    [JsonPropertyName("tabs")]
    public IReadOnlyList<JsonElement>? Tabs { get; init; }

    [JsonPropertyName("general_message_behaviour")]
    public JsonElement? GeneralMessageBehaviour { get; init; }

    [JsonPropertyName("datadog_config")]
    public JsonElement? DatadogConfig { get; init; }

    [JsonPropertyName("braze_config")]
    public JsonElement? BrazeConfig { get; init; }

    [JsonPropertyName("in_app_feature_config")]
    public JsonElement? InAppFeatureConfig { get; init; }

    [JsonPropertyName("first_time_user")]
    public bool FirstTimeUser { get; init; }
}
