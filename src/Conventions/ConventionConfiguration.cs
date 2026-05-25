using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace IATec.Shared.Api.Conventions;

/// <summary>
/// Conventions for API responses
/// </summary>
public static class ConventionConfiguration
{
    /// <summary>
    /// Defines the expected response types for an operation that retrieves a single resource by identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the resource.</param>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    public static void GetById([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix)] Guid id)
    {
    }

    /// <summary>
    /// Defines the expected response types for an operation that lists all resources.
    /// </summary>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public static void List()
    {
    }

    /// <summary>
    /// Defines the expected response types for an operation that creates a new resource.
    /// </summary>
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public static void Create()
    {
    }

    /// <summary>
    /// Defines the expected response types for an operation that updates an existing resource.
    /// </summary>
    /// <param name="id">The unique identifier of the resource to update.</param>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public static void Update([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix)] int id)
    {
    }

    /// <summary>
    /// Defines the expected response types for an operation that deletes a resource.
    /// </summary>
    /// <param name="id">The unique identifier of the resource to delete.</param>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public static void Delete([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix)] Guid id)
    {
    }
}
