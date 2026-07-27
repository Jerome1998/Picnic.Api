using Picnic.Api.Internal;
using Picnic.Api.Models.Catalog;
using Picnic.Api.Models.Fusion;
using Picnic.Api.Services.Interfaces;
using System.Text.Json;

namespace Picnic.Api.Services;

internal sealed class CatalogService(PicnicHttpClient httpClient) : ICatalogService
{
    public async Task<IReadOnlyList<SellingUnit>> SearchAsync(string query,
        CancellationToken cancellationToken = default)
    {
        var response = await httpClient.GetAsync(
            $"/pages/search-page-results?search_term={Uri.EscapeDataString(query)}", includePicnicHeaders: true,
            cancellationToken: cancellationToken);
        return ExtractSellingUnits(response.Json);
    }

    public async Task<IReadOnlyList<SearchSuggestion>> GetSuggestionsAsync(string query,
        CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync($"/suggest?search_term={Uri.EscapeDataString(query)}",
            cancellationToken: cancellationToken)).DeserializeOrThrow<IReadOnlyList<SearchSuggestion>>();

    public async Task<FusionPage> GetProductDetailsPageAsync(string productId,
        CancellationToken cancellationToken = default)
        => (await httpClient.GetAsync(
            $"/pages/product-details-page-root?id={Uri.EscapeDataString(productId)}&show_category_action=true&show_remove_from_purchases_page_action=true",
            includePicnicHeaders: true, cancellationToken: cancellationToken)).DeserializeOrThrow<FusionPage>();

    public Task<byte[]> GetImageAsync(string imageId, ImageSize size, CancellationToken cancellationToken = default)
        => httpClient.GetBytesAsync(httpClient.BuildImageUrl(imageId, MapImageSize(size)), cancellationToken);

    private static string MapImageSize(ImageSize size) => size switch
    {
        ImageSize.Tiny => "tiny",
        ImageSize.Small => "small",
        ImageSize.Medium => "medium",
        ImageSize.Large => "large",
        ImageSize.ExtraLarge => "extra-large",
        _ => throw new ArgumentOutOfRangeException(nameof(size), size, "Unsupported image size.")
    };

    private static IReadOnlyList<SellingUnit> ExtractSellingUnits(JsonElement root)
    {
        var results = new List<SellingUnit>();
        Traverse(root, results);
        return results;
    }

    private static void Traverse(JsonElement element, List<SellingUnit> collector)
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.Object:
                foreach (var property in element.EnumerateObject())
                {
                    if (property.NameEquals("sellingUnit") && property.Value.ValueKind == JsonValueKind.Object)
                    {
                        var unit = property.Value.Deserialize<SellingUnit>();
                        if (unit is not null)
                        {
                            collector.Add(unit);
                        }
                    }

                    Traverse(property.Value, collector);
                }

                break;

            case JsonValueKind.Array:
                foreach (var item in element.EnumerateArray())
                {
                    Traverse(item, collector);
                }

                break;
        }
    }
}
