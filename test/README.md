# Test Suite

Comprehensive tests for all projects in the solution.

## Projects

- **ViewsTests**: XUnit tests for Razor components and server-side logic
- **ViewsClientTests**: Vitest tests for React/TypeScript components
- **SiteTests**: XUnit tests for the Site application
- **CMSTests**: XUnit tests for the CMS application

## Running Tests

### All Tests
```bash
npm run test
```

### .NET Tests Only
```bash
npm run test:dotnet
```

### React Tests Only
```bash
npm run test:client
```

### React Tests with UI
```bash
npm run test:client:ui
```

### React Tests with Coverage
```bash
npm run test:client:coverage
```

### Watch Mode (React)
```bash
npm run test:client:watch
```

### Watch Mode (.NET)
```bash
npm run test:dotnet:watch
```

## Test Structure

Tests are organized to mirror the source structure:
- `./ViewsTests/Server/` → Tests for `src/Views/Server/`
- `./ViewsClientTests/components/` → Tests for `src/Views/Client/components/`
- `./SiteTests/Pages/` → Tests for `src/Site/Pages/`

## Best Practices

### XUnit
- One test file per source file
- Test names follow pattern: `MethodName_Scenario_ExpectedResult`
- Use `Fact` for simple cases, `Theory` with `InlineData` for parameterized tests
- Mock external dependencies with Moq

### Vitest
- One test file per React component
- Use descriptive `describe` blocks
- Test user interactions, not implementation details
- Use `@testing-library/react` for component testing
- Use path aliases (`@components/`, `@pages/`, etc.) for imports

## Path Aliases

Tests can use the same path aliases as the main application:
- `@components` → `src/Views/Client/components`
- `@pages` → `src/Views/Client/pages`
- `@features` → `src/Views/Client/features`
- `@styles` → `src/Views/Client/styles`

Example:
```typescript
import { Button } from '@components/Button'
import { render } from '@testing-library/react'
```
