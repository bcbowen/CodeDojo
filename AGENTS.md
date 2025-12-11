# Agent Guidelines for CodeDojo

## Build/Lint/Test Commands

### Python
- **Test all**: `pytest`
- **Test single file**: `pytest path/to/test_file.py`
- **Test single function**: `pytest path/to/test_file.py::test_function_name`

### TypeScript
- **Build**: `npm run build` (compiles TS and bundles with Vite)
- **Dev server**: `npm run dev` (starts Vite dev server)

### Go
- **Test all**: `go test ./...`
- **Test single package**: `go test ./path/to/package`

### C#
- **Test in LINQPad**: Run tests via LINQPad interface with xUnit

## Code Style Guidelines

### Python
- Use type hints for function parameters and return values
- snake_case for variables/functions, PascalCase for classes
- pytest for testing with parametrized tests
- Import organization: standard library, third-party, local modules

### C#
- PascalCase for classes, methods, properties
- camelCase for local variables and parameters
- xUnit for testing with [Theory] and [InlineData]
- Use LINQPad for quick prototyping and testing

### TypeScript
- Strict mode enabled with comprehensive type checking
- ES modules with import/export syntax
- Use const/let, avoid var
- Interface names with PascalCase

### Go
- Standard gofmt formatting
- Table-driven tests with struct slices
- Error handling with explicit returns
- Package naming follows directory structure

### General
- No comments unless absolutely necessary
- Follow existing patterns in each language subdirectory
- Use appropriate testing frameworks for each language