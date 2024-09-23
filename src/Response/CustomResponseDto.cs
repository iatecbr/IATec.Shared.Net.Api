namespace IATec.Shared.Api.Response;

public sealed record CustomResponseDto(
    bool Success,
    int StatusCode,
    object? Data,
    List<string> Messages,
    DateTimeOffset DateTimeUtc);