using System.Net;
using FluentResults;

namespace IATec.Shared.Api.Response;

/// <summary>
/// Provides extension methods to convert FluentResults <see cref="Result"/> instances into <see cref="CustomResponseDto"/>.
/// </summary>
public static class CustomResponseExtensions
{
    /// <summary>
    /// Creates a failure <see cref="CustomResponseDto"/> from a generic FluentResults <see cref="Result{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="result">The failed result.</param>
    /// <param name="httpStatusCode">The HTTP status code to include in the response.</param>
    /// <returns>A <see cref="CustomResponseDto"/> describing the failure.</returns>
    public static CustomResponseDto FailCustomResponse<T>(this Result<T> result, HttpStatusCode httpStatusCode) =>
        BuildCustomResponse(false, httpStatusCode, null, BuildErrorMessageList(result.Errors));

    /// <summary>
    /// Creates a failure <see cref="CustomResponseDto"/> from a non-generic FluentResults <see cref="Result"/>.
    /// </summary>
    /// <param name="result">The failed result.</param>
    /// <param name="httpStatusCode">The HTTP status code to include in the response.</param>
    /// <returns>A <see cref="CustomResponseDto"/> describing the failure.</returns>
    public static CustomResponseDto FailCustomResponse(this Result result, HttpStatusCode httpStatusCode) =>
        BuildCustomResponse(false, httpStatusCode, null, BuildErrorMessageList(result.Errors));

    /// <summary>
    /// Creates a successful <see cref="CustomResponseDto"/> from a generic FluentResults <see cref="Result{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="result">The successful result containing the value.</param>
    /// <param name="httpStatusCode">The HTTP status code to include in the response.</param>
    /// <returns>A <see cref="CustomResponseDto"/> describing the success.</returns>
    public static CustomResponseDto SuccessCustomResponse<T>(this Result<T> result, HttpStatusCode httpStatusCode) =>
        BuildCustomResponse(true, httpStatusCode, result.Value, []);

    /// <summary>
    /// Creates a successful <see cref="CustomResponseDto"/> without a value.
    /// </summary>
    /// <param name="httpStatusCode">The HTTP status code to include in the response.</param>
    /// <returns>A <see cref="CustomResponseDto"/> describing the success.</returns>
    public static CustomResponseDto SuccessCustomResponse(HttpStatusCode httpStatusCode) =>
        BuildCustomResponse(true, httpStatusCode, null, []);

    /// <summary>
    /// Builds a <see cref="CustomResponseDto"/> with the provided parameters.
    /// </summary>
    /// <param name="success">Indicates whether the operation was successful.</param>
    /// <param name="statusCode">The HTTP status code.</param>
    /// <param name="data">Optional data payload.</param>
    /// <param name="errors">A list of error messages.</param>
    /// <returns>A new <see cref="CustomResponseDto"/> instance.</returns>
    private static CustomResponseDto BuildCustomResponse(bool success, HttpStatusCode statusCode, object? data,
        List<string> errors) => new(success, (int)statusCode, data, errors, DateTimeOffset.UtcNow);

    /// <summary>
    /// Extracts error messages from a FluentResults error list.
    /// </summary>
    /// <param name="resultErrorList">The list of errors from FluentResults.</param>
    /// <returns>A list of error message strings. Returns an empty list if the input is null.</returns>
    private static List<string> BuildErrorMessageList(IReadOnlyList<IError> resultErrorList)
    {
        if (resultErrorList == null || resultErrorList.Count == 0)
            return new List<string>();

        return resultErrorList.Select(error => error.Message).ToList();
    }
}
