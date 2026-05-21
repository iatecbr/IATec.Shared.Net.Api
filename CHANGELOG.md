# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.2.0] - 2026-05-21

### ADDED
- XML documentation (summaries) for all public classes and methods.
- Complete `README.md` with usage examples and installation instructions.
- `CHANGELOG.md` to track historical changes across versions.

### CHANGED
- **Bumped** `IATec.Shared.Domain` from `1.2.0` to `2.0.0`.
- Improved internal null-safety by guarding `BuildErrorMessageList` against null or empty input lists and returning an empty list instead.

## [1.1.0] - 2026-01-12

### CHANGED
- Updated target frameworks to include .NET 10.
- **Bumped** `FluentResults` from `3.16.0` to `4.0.0`.
- **Bumped** `IATec.Shared.Domain` from `0.10.0` to `1.2.0`.
- Replaced `Microsoft.AspNetCore.Mvc` package reference with `Microsoft.AspNetCore.App` framework reference.

### FIXED
- Fixed pipeline YAML configuration.

## [1.0.0] - 2025-08-11

### ADDED
- Introduced `CustomResponseDto`, `CustomResponseExtensions`, and `CustomControllerBase` for standardized API responses.
- Added `ConventionConfiguration` with API Explorer response conventions for common CRUD operations.
- Mapped FluentResults states to HTTP status codes: `Created`, `NoContent`, `NotFound`, `BadRequest`, `ServiceUnavailable`, and `InternalServerError`.

### FIXED
- Removed duplicated `Delete` mapping in controller base.
- Removed duplicated `Update` mapping in controller base.
- Fixed general code formatting issues.

## [0.1.0] - 2024-09-19

### ADDED
- Project initialization with basic solution structure.
- Base dependencies:
  - `FluentResults` `3.16.0`
  - `IATec.Shared.Domain` `0.2.0`
  - `Microsoft.AspNetCore.Mvc` `2.2.0`
