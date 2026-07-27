using System.Text.Json;

namespace Picnic.Api.Models;

/// <summary>
/// Represents a raw API response payload and provides deserialization helpers.
/// </summary>
/// <param name="Json">The raw JSON payload returned by the API.</param>
public sealed record PicnicApiResponse(JsonElement Json)
{
    /// <summary>
    /// Deserializes the response JSON into the requested type.
    /// </summary>
    /// <typeparam name="T">The target type to deserialize to.</typeparam>
    /// <returns>The deserialized value, or <see langword="null"/> when deserialization fails.</returns>
    public T? Deserialize<T>() => this.Json.Deserialize<T>();

    /// <summary>
    /// Deserializes the response JSON into the requested type or throws when it cannot be deserialized.
    /// </summary>
    /// <typeparam name="T">The target type to deserialize to.</typeparam>
    /// <returns>The deserialized value.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the response cannot be deserialized into <typeparamref name="T"/>.</exception>
    public T DeserializeOrThrow<T>()
    {
        var value = this.Deserialize<T>();
        return value is null
            ? throw new InvalidOperationException($"Unable to deserialize Picnic response into {typeof(T).Name}.")
            : value;
    }
}
