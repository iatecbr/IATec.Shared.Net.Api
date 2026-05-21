namespace IATec.Shared.Api.Response;

/// <summary>
/// Represents a standardized API response payload.
/// </summary>
/// <param name="Success">Indicates whether the operation was successful.</param>
/// <param name="StatusCode">The HTTP status code of the response.</param>
/// <param name="Data">Optional data returned by the operation.</param>
/// <param name="Messages">A list of messages describing the result.</param>
/// <param name="DateTimeUtc">The UTC date and time when the response was generated.</param>
public sealed record CustomResponseDto(
    bool Success,
    int StatusCode,
    object? Data,
    List<string> Messages,
    DateTimeOffset DateTimeUtc);
