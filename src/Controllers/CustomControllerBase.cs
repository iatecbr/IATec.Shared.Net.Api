using System.Net;
using FluentResults;
using IATec.Shared.Api.Response;
using IATec.Shared.Domain.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IATec.Shared.Api.Controllers;

/// <summary>
/// Provides a customizable base controller that standardizes action results
/// based on FluentResults <see cref="Result"/> states.
/// </summary>
public class CustomControllerBase : ControllerBase
{
    /// <summary>
    /// Converts a generic FluentResults <see cref="Result{T}"/> into a standardized <see cref="ActionResult"/>.
    /// </summary>
    /// <typeparam name="T">The type of the value inside the result.</typeparam>
    /// <param name="result">The FluentResults result to process.</param>
    /// <param name="location">Optional URI location for created resources.</param>
    /// <returns>An <see cref="ActionResult"/> with the appropriate HTTP status code and response body.</returns>
    [NonAction]
    protected ActionResult CustomResult<T>(Result<T> result, string? location = null)
    {
        if (result.IsCreatedSuccess())
            return Created(location, result.SuccessCustomResponse(HttpStatusCode.Created));

        if (result.IsNoContentSuccess() || result.IsEmptyResult())
            return NoContent();

        if (result.IsResourceNotFoundError())
            return NotFound(result.FailCustomResponse(HttpStatusCode.NotFound));

        if (result.IsServiceUnavailableError())
            return StatusCode(StatusCodes.Status503ServiceUnavailable, result.FailCustomResponse(HttpStatusCode.ServiceUnavailable));
        if (result.IsInternalServerError())
            return StatusCode(StatusCodes.Status500InternalServerError,
                result.FailCustomResponse(HttpStatusCode.InternalServerError));

        if (result.IsConflictError())
            return Conflict(result.FailCustomResponse(HttpStatusCode.Conflict));

        if (result.IsBadRequestError() || result.IsFailed)
            return BadRequest(result.FailCustomResponse(HttpStatusCode.BadRequest));

        return Ok(result.SuccessCustomResponse(HttpStatusCode.OK));
    }

    /// <summary>
    /// Converts a non-generic FluentResults <see cref="Result"/> into a standardized <see cref="ActionResult"/>.
    /// </summary>
    /// <param name="result">The FluentResults result to process.</param>
    /// <param name="location">Optional URI location for created resources.</param>
    /// <returns>An <see cref="ActionResult"/> with the appropriate HTTP status code and response body.</returns>
    protected ActionResult CustomResult(Result result, string? location = null)
    {
        if (result.IsCreatedSuccess())
            return Created(location, CustomResponseExtensions.SuccessCustomResponse(HttpStatusCode.Created));

        if (result.IsNoContentSuccess())
            return NoContent();

        if (result.IsResourceNotFoundError())
            return NotFound(result.FailCustomResponse(HttpStatusCode.NotFound));

        if (result.IsServiceUnavailableError())
            return StatusCode(StatusCodes.Status503ServiceUnavailable, result.FailCustomResponse(HttpStatusCode.ServiceUnavailable));

        if (result.IsInternalServerError())
            return StatusCode(StatusCodes.Status500InternalServerError, result.FailCustomResponse(HttpStatusCode.InternalServerError));

        if (result.IsConflictError())
            return Conflict(result.FailCustomResponse(HttpStatusCode.Conflict));

        if (result.IsBadRequestError() || result.IsFailed)
            return BadRequest(result.FailCustomResponse(HttpStatusCode.BadRequest));

        return Ok(CustomResponseExtensions.SuccessCustomResponse(HttpStatusCode.OK));
    }
}
