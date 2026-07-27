namespace Picnic.Api.Exceptions;

/// <summary>
/// Represents an authentication-specific error from the Picnic API.
/// </summary>
/// <param name="message">The exception message.</param>
public sealed class PicnicAuthException(string message) : Exception(message);
