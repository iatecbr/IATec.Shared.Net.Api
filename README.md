# IATec.Shared.Api

Shared library for .NET API projects at IATec. It provides standardized controllers, response conventions, and FluentResults integration to accelerate development across teams.

## Features

- **CustomControllerBase**: Standardized base controller that translates FluentResults states into proper HTTP responses (Created, NoContent, NotFound, BadRequest, ServiceUnavailable, InternalServerError, OK).
- **CustomResponseDto**: Uniform API response envelope with `Success`, `StatusCode`, `Data`, `Messages`, and `DateTimeUtc`.
- **CustomResponseExtensions**: Extension methods to map FluentResults `Result` and `Result<T>` to `CustomResponseDto`.
- **ConventionConfiguration**: API Explorer conventions for common CRUD operations (`GetById`, `List`, `Create`, `Update`, `Delete`) with default `ProducesResponseType` attributes.

## Installation

Install the NuGet package:

```bash
dotnet add package IATec.Shared.Api
```

## Requirements

- .NET 8.0, .NET 9.0 or .NET 10.0
- `IATec.Shared.Domain` >= `2.0.0`
- `FluentResults` >= `4.0.0`

## Usage

### Using the base controller

```csharp
using IATec.Shared.Api.Controllers;
using FluentResults;

public class ProductsController : CustomControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet("{id:guid}")]
    public ActionResult GetById(Guid id)
    {
        var result = _service.GetById(id);
        return CustomResult(result);
    }

    [HttpPost]
    public ActionResult Create([FromBody] ProductDto dto)
    {
        var result = _service.Create(dto);
        return CustomResult(result, $"/products/{result.Value.Id}");
    }
}
```

### Using response extensions manually

```csharp
using IATec.Shared.Api.Response;
using FluentResults;

Result<int> result = Result.Ok(42);
CustomResponseDto response = result.SuccessCustomResponse(HttpStatusCode.OK);
```

## Conventions

Methods returning `Task` should have the `Async` suffix (e.g., `GetByIdAsync`). This library exposes synchronous helpers because `ActionResult` generation itself is synchronous, but consumer controllers should follow the standard async naming when applicable.

## Changelog

See [CHANGELOG.md](CHANGELOG.md) for the version history.

## Contributing

This package is maintained by the **IATec | Solution | Platform Team**. For issues or contributions, please use the [GitHub repository](https://github.com/iatecbr/IATec.Shared.Net.Api).

## License

See [LICENSE](https://github.com/iatecbr/IATec.Shared.Net.Api/blob/main/LICENSE) for details.
