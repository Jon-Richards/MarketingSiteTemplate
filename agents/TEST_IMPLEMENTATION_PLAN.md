# Test Suite Implementation Plan

## Overview

Add comprehensive test coverage for all projects in the `./src` directory with:
- **XUnit** for .NET projects (Views, Site, CMS)
- **Vitest** for TypeScript (Views Client components)

## Test Directory Structure

```
MarketingSiteTemplate/                 # Project root
├── vitest.config.ts                   # Vitest config (shared with Vite)
├── tsconfig.json                      # Shared TypeScript config
├── package.json                       # Root package with all test scripts
│
└── test/
    ├── ViewsTests/                    # Razor components + Server logic
    │   ├── ViewsTests.csproj          # XUnit test project
    │   ├── Server/
    │   │   ├── Components/
    │   │   │   ├── CardComponentTests.cs
    │   │   │   ├── AlertComponentTests.cs
    │   │   │   └── HelloWorldComponentTests.cs
    │   │   └── ...
    │   └── Usings.cs
    ├── ViewsClientTests/              # React component tests (test code only)
    │   ├── setup.ts                   # Test setup & globals
    │   └── components/
    │       ├── Button.test.tsx
    │       └── Stats.test.tsx
    ├── SiteTests/
    │   ├── SiteTests.csproj           # XUnit test project
    │   ├── Pages/
    │   │   ├── IndexPageTests.cs
    │   │   ├── PrivacyPageTests.cs
    │   │   └── ...
    │   └── Usings.cs
    ├── CMSTests/
    │   ├── CMSTests.csproj            # XUnit test project
    │   └── ...
    └── README.md                      # Test setup and running guide
```

**Note:** Client-side test configuration (vitest.config.ts, tsconfig.json, package.json) is centralized at the project root alongside Vite build configuration.

## Phase 1: Setup XUnit Projects

### 1.1 Create ViewsTests Project

**File: test/ViewsTests/ViewsTests.csproj**
```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
    <IsTestProject>true</IsTestProject>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.8.0" />
    <PackageReference Include="xunit" Version="2.6.0" />
    <PackageReference Include="xunit.runner.visualstudio" Version="2.5.0" />
    <PackageReference Include="Microsoft.AspNetCore.Mvc.Testing" Version="9.0.0" />
    <PackageReference Include="Moq" Version="4.20.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="../../src/Views/Views.csproj" />
  </ItemGroup>
</Project>
```

**File: test/ViewsTests/Usings.cs**
```csharp
global using Xunit;
global using Moq;
```

**Initial Test File: test/ViewsTests/Server/Components/CardComponentTests.cs**
```csharp
namespace ViewsTests.Server.Components;

public class CardComponentTests
{
    [Fact]
    public void CardComponent_WithValidParameters_RendersProperly()
    {
        // Arrange
        var title = "Test Title";
        var content = "Test Content";

        // Act
        // Assert (Implement after understanding Razor testing approach)
    }
}
```

### 1.2 Create SiteTests Project

**File: test/SiteTests/SiteTests.csproj**
```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
    <IsTestProject>true</IsTestProject>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.8.0" />
    <PackageReference Include="xunit" Version="2.6.0" />
    <PackageReference Include="xunit.runner.visualstudio" Version="2.5.0" />
    <PackageReference Include="Microsoft.AspNetCore.Mvc.Testing" Version="9.0.0" />
    <PackageReference Include="Moq" Version="4.20.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="../../src/Site/Site.csproj" />
    <ProjectReference Include="../../src/Views/Views.csproj" />
  </ItemGroup>
</Project>
```

### 1.3 Create CMSTests Project

**File: test/CMSTests/CMSTests.csproj**
```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
    <IsTestProject>true</IsTestProject>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.8.0" />
    <PackageReference Include="xunit" Version="2.6.0" />
    <PackageReference Include="xunit.runner.visualstudio" Version="2.5.0" />
    <PackageReference Include="Microsoft.AspNetCore.Mvc.Testing" Version="9.0.0" />
    <PackageReference Include="Moq" Version="4.20.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="../../src/CMS/CMS.csproj" />
  </ItemGroup>
</Project>
```

## Phase 2: Setup Vitest for React Components

### 2.1 Add Vitest Configuration to Root

**File: vitest.config.ts** (at project root, alongside vite.config.ts)
```typescript
import { defineConfig } from 'vitest/config'
import react from '@vitejs/plugin-react'
import path from 'path'

export default defineConfig({
  plugins: [react()],
  test: {
    globals: true,
    environment: 'jsdom',
    setupFiles: ['test/ViewsClientTests/setup.ts'],
    coverage: {
      reporter: ['text', 'json', 'html'],
      exclude: ['node_modules/', 'dist/', 'test/']
    },
    include: ['test/ViewsClientTests/**/*.test.{ts,tsx}']
  },
  resolve: {
    alias: {
      '@components': path.resolve(__dirname, './src/Views/Client/components'),
      '@pages': path.resolve(__dirname, './src/Views/Client/pages'),
      '@features': path.resolve(__dirname, './src/Views/Client/features'),
      '@styles': path.resolve(__dirname, './src/Views/Client/styles'),
    },
  },
})
```

**Path Aliases for Tests:**

Tests can use the same path aliases defined in tsconfig.json and vitest.config.ts:
- `@components` → `src/Views/Client/components`
- `@pages` → `src/Views/Client/pages`
- `@features` → `src/Views/Client/features`
- `@styles` → `src/Views/Client/styles`

Example:
```typescript
// Instead of: import { Button } from '../../../src/Views/Client/components/Button'
import { Button } from '@components/Button'
```

**Updates to package.json** (at project root)

Add these devDependencies:
```json
"devDependencies": {
  "@testing-library/react": "^14.0.0",
  "@testing-library/jest-dom": "^6.1.4",
  "@testing-library/user-event": "^14.5.0",
  "@vitest/ui": "^0.34.0",
  "jsdom": "^22.1.0",
  "vitest": "^0.34.0"
}
```

Note: `react`, `typescript`, and `@vitejs/plugin-react` are already in package.json

**File: test/ViewsClientTests/setup.ts** (test-specific setup)
```typescript
import { expect, afterEach } from 'vitest'
import { cleanup } from '@testing-library/react'
import '@testing-library/jest-dom'

// Cleanup after each test
afterEach(() => {
  cleanup()
})
```

### 2.2 Create Sample React Component Tests

**File: test/ViewsClientTests/components/Button.test.tsx**
```typescript
import { describe, it, expect, vi } from 'vitest'
import { render, screen } from '@testing-library/react'
import userEvent from '@testing-library/user-event'
import { Button } from '@components/Button'

describe('Button Component', () => {
  it('renders with label prop', () => {
    render(<Button label="Click Me" />)
    expect(screen.getByRole('button', { name: /click me/i })).toBeInTheDocument()
  })

  it('renders with primary variant by default', () => {
    render(<Button label="Primary" />)
    const button = screen.getByRole('button', { name: /primary/i })
    expect(button).toHaveClass('bg-blue-600')
  })

  it('renders with secondary variant', () => {
    render(<Button label="Secondary" variant="secondary" />)
    const button = screen.getByRole('button', { name: /secondary/i })
    expect(button).toHaveClass('bg-gray-300')
  })

  it('renders with danger variant', () => {
    render(<Button label="Delete" variant="danger" />)
    const button = screen.getByRole('button', { name: /delete/i })
    expect(button).toHaveClass('bg-red-600')
  })

  it('handles click events', async () => {
    const user = userEvent.setup()
    const handleClick = vi.fn()
    
    render(<Button label="Click me" onClick={handleClick} />)
    
    await user.click(screen.getByRole('button', { name: /click me/i }))
    expect(handleClick).toHaveBeenCalledTimes(1)
  })
})
```

**File: test/ViewsClientTests/components/Stats.test.tsx**
```typescript
import { describe, it, expect } from 'vitest'
import { render, screen } from '@testing-library/react'
import { Stats } from '@components/Stats'

describe('Stats Component', () => {
  it('renders count and label', () => {
    render(<Stats count={42} label="Users" />)
    expect(screen.getByText('42')).toBeInTheDocument()
    expect(screen.getByText('Users')).toBeInTheDocument()
  })

  it('applies gradient styling', () => {
    const { container } = render(<Stats count={10} label="Items" />)
    const div = container.querySelector('[class*="gradient"]')
    expect(div).toBeInTheDocument()
  })
})
```

## Phase 3: Integration & Configuration

### 3.1 Update Root Directory Structure

**Move index.html deprecation note** - Already done (see README)

### 3.2 Add Test Running Scripts to Root package.json

```json
{
  "scripts": {
    "test": "npm run test:client && npm run test:dotnet",
    "test:client": "vitest",
    "test:client:ui": "vitest --ui",
    "test:client:coverage": "vitest --coverage",
    "test:client:watch": "vitest --watch",
    "test:dotnet": "dotnet test",
    "test:dotnet:watch": "dotnet watch --project test/SiteTests test"
  }
}
```

Note: Vitest commands run from the root, using `vitest.config.ts` and `tsconfig.json` in the root directory.

### 3.3 Create test/README.md

```markdown
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

### Watch Mode (.NET)
```bash
npm run test:watch
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
```

## Phase 4: Documentation Updates

### 4.1 Update Views README

Add section about testing:
```markdown
## Testing

### Unit Tests for Razor Components
```bash
dotnet test test/ViewsTests
```

### Unit Tests for React Components
```bash
npm run test:client
```

Run all tests:
```bash
npm run test
```

See [test/README.md](../../test/README.md) for detailed testing guide.
```

## Implementation Steps

1. **Phase 1 - XUnit Setup** (1-2 hours)
   - Create ViewsTests.csproj
   - Create SiteTests.csproj  
   - Create CMSTests.csproj
   - Add sample test files

2. **Phase 2 - Vitest Setup** (1-2 hours)
   - Create ViewsClientTests structure
   - Configure vitest.config.ts and tsconfig.json
   - Create setup.ts and package.json
   - Add sample React component tests

3. **Phase 3 - Integration** (30 mins)
   - Update root package.json with test scripts
   - Create test/README.md

4. **Phase 4 - Documentation** (30 mins)
   - Update Views README with testing section
   - Add testing guidelines

## Testing Technologies

| Aspect | Technology | Version |
|--------|-----------|---------|
| .NET Test Framework | XUnit | 2.6.0 |
| Mocking (C#) | Moq | 4.20.0 |
| React Testing | @testing-library/react | 14.0.0 |
| TypeScript Testing | Vitest | 0.34.0 |
| Test Environment | jsdom | 22.1.0 |
| Coverage | vitest coverage | integrated |

## Success Criteria

- ✅ All test projects build successfully
- ✅ Sample tests pass for Razor components
- ✅ Sample tests pass for React components
- ✅ npm run test executes both suites
- ✅ dotnet test discovers all XUnit tests
- ✅ npm run test:client:ui opens test UI
- ✅ Documentation is clear and complete

## Future Enhancements

- Add CI/CD integration (GitHub Actions)
- Add code coverage thresholds
- Add E2E tests with Playwright
- Add performance benchmarks
- Add mutation testing with Stryker
