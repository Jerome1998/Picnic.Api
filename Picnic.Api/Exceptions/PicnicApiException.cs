namespace Picnic.Api.Exceptions;

/// <summary>
/// Represents an error returned by the Picnic API.
/// </summary>
/// <param name="message">The exception message.</param>
/// <param name="statusCode">The optional HTTP status code returned by the API.</param>
public sealed class PicnicApiException(string message, int? statusCode = null) : Exception(message)
{
    /// <summary>
    /// Gets the HTTP status code associated with the API error, when available.
    /// </summary>
    public int? StatusCode { get; } = statusCode;
}
