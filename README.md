# Marketing Site Template

A modern, full-stack template for building dynamic marketing sites using ASP.NET Core 9, Razor components, React 18, and Tailwind CSS. Features a unified component library serving both server-side rendered Razor components and client-side React components with shared styling.

## 🎯 Features

- **Unified Component Library**: Razor Class Library (Views) containing both server-rendered and React components
- **ASP.NET Core 9**: Modern .NET framework with latest features
- **React 18 + TypeScript**: Client-side interactive components with type safety
- **Tailwind CSS 3.4**: Unified styling across all components
- **Vite Bundler**: Lightning-fast development and optimized production builds
- **Component Testing**: Comprehensive test suites for both React (Vitest) and Razor (bunit) components
- **RCL Static Web Assets**: Proper ASP.NET Core static asset serving pattern
- **npm Build Automation**: Integrated npm build into MSBuild pipeline

## 📋 Tech Stack

| Layer | Technology | Version |
|-------|-----------|---------|
| **Backend** | ASP.NET Core | 9.0 |
| **Component Library** | Razor Class Library | 9.0 |
| **Frontend Framework** | React | 18.2 |
| **Language** | TypeScript | 5.3 |
| **Styling** | Tailwind CSS | 3.4 |
| **Bundler** | Vite | 7.3 |
| **Testing (React)** | Vitest + @testing-library/react | 0.34 / 14.0 |
| **Testing (Razor)** | bunit + XUnit | 1.31 / 2.6 |
| **Build Automation** | npm + MSBuild | - |

## 📁 Project Structure

```
MarketingSiteTemplate/
├── src/
│   ├── Views/                          # User interface library
│   │   ├── Server/                     # Server-rendered Razor components
│   │   ├── Client/                     # Client-rendered code
│   │   └── wwwroot/                    # Static assets (RCL pattern)
│   │       └── bundle/                 # Bundled output (excluded from version control)
│   ├── Site/                           # Publicly facing website application
|   |   ├── Components/                 # Razor components
│   │   |   ├── Pages/                  # Page level views
│   │   │   └── Shared/                 # Shared code between pages
│   │   ├── wwwroot/                    # Static assets
│   ├── CMS/                            # Content management system
│   │   ├── Pages/                      # Page level views
│   │   │   └── Shared/                 # Shared code between pages
│   │   ├── wwwroot/                    # Static assets
│   └── Storage/                        # Storage access repositories
├── test/                               # Test suite for the project
│   ├── ViewsTests/                     # Razor component tests (XUnit + bunit)
│   ├── ViewsClientTests/               # React component tests (Vitest)
│   ├── SiteTests/                      # Site application tests
│   └── CMSTests/                       # CMS application tests
├── agents/                             # Prompts and context for LLMs.
└── doc/                                # Additional documentation
```

## 🚀 Quick Start

### Prerequisites
- **.NET 9 SDK** or later
- **Node.js v22.12.0** or later
- **NPM 10.9.0** or later

### Installation

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd MarketingSiteTemplate
   ```

2. **Restore .NET dependencies**
   ```bash
   dotnet restore
   ```

3. **Install npm dependencies**
   ```bash
   npm install
   ```

### Development Workflow

The project uses an integrated development workflow combining npm (for React/TypeScript) and .NET (for Razor/C#).

**Recommended: Start both watchers in separate terminals**

**Terminal 1 - Watch for TypeScript/React changes:**
```bash
npm run watch
```
This watches for changes in `src/Views/Client/**` and automatically rebuilds the bundle.

**Terminal 2 - Watch for .NET changes:**
```bash
dotnet watch --project ./src/Site
```
This watches for changes in Razor files and C# code, rebuilding and reloading the Site application.

### Building

**Build everything:**
```bash
dotnet build
```

**Build just the Vite bundle:**
```bash
npm run build
```

The Views.csproj is configured with an `NpmBuild` target that automatically runs `npm run build` before the project builds, ensuring TypeScript/React components are always bundled.

### Testing

**Run all tests** (React + Razor):
```bash
npm run test
```

**React component tests only:**
```bash
npm run test:client              # Single run
npm run test:client:watch        # Watch mode
npm run test:client:ui           # Interactive UI
npm run test:client:coverage     # With coverage report
```

**Razor component tests only:**
```bash
npm run test:dotnet              # Single run
npm run test:dotnet:watch        # Watch mode
```

### Running the Application

**Development:**
```bash
dotnet run --project ./src/Site
```
Launches the Site application at `https://localhost:7229` (or configured port).

**With live reload:**
Combine with one or both watch commands in separate terminals for a full hot-reload experience.

## 🏗️ Architecture Overview

### Component Library (Views)

The **Views** Razor Class Library is the heart of the project, containing:

1. **Razor Components** (`Server/Components/`)
   - Reusable server-rendered components
   - Styled with Tailwind CSS
   - Can be used in any ASP.NET Core application

2. **React Components** (`Client/components/`)
   - Interactive client-side components
   - Built with React 18 + TypeScript
   - Bundled by Vite
   - Also styled with Tailwind CSS

3. **Static Assets** (`wwwroot/bundle/`)
   - Vite output directory
   - Served via RCL static web assets pattern
   - Accessible at `~/_content/Views/bundle/` in Razor templates
   - Accessible at `/_content/Views/bundle/` in React components

### CSS Styling

**Unified Tailwind CSS Configuration:**
- Single `tailwind.config.js` at project root
- Scans all component files:
  - `src/Views/Server/**/*.razor` (Razor components)
  - `src/Views/Client/**/*.{ts,tsx}` (React components)
  - `src/Site/Pages/**/*.{cshtml,html}` (Razor Pages)
- All components styled consistently with Tailwind utilities

### Build Pipeline

1. **Development:**
   - `npm run watch` → Vite watches React/TypeScript → outputs to `src/Views/wwwroot/bundle/`
   - `dotnet watch` → Detects changes in Razor/C# → rebuilds and reloads

2. **Production:**
   - `npm run build` → Vite bundles with optimizations
   - `dotnet build` → Includes npm build via MSBuild target
   - Final app ready for deployment

### Static Asset Serving (RCL Pattern)

Files in `src/Views/wwwroot/` are served via ASP.NET Core's RCL static web assets:

**In Razor Templates:**
```html
<link rel="stylesheet" href="~/_content/Views/bundle/index.css" />
```

**In React Components:**
```javascript
import cssBundle from '/_content/Views/bundle/index.css'
```

## 📦 Component Examples

### Razor Component (Server-Rendered)

**Card.razor:**
```razor
@namespace Views.Server.Components

<div class="bg-blue-50 rounded-lg shadow-md p-6 border border-blue-200">
    <h2 class="text-2xl font-bold text-blue-900 mb-2">@Title</h2>
    <p class="text-blue-700">@Content</p>
</div>

@code {
    [Parameter]
    public string Title { get; set; } = "Card Title";

    [Parameter]
    public string Content { get; set; } = "Card content goes here.";
}
```

**Usage in Razor Pages:**
```html
<div class="grid grid-cols-1 md:grid-cols-2 gap-4">
    <Views.Server.Components.Card Title="Feature 1" Content="Description..." />
    <Views.Server.Components.Card Title="Feature 2" Content="Description..." />
</div>
```

### React Component (Client-Side)

**Button.tsx:**
```typescript
import React from 'react'

interface ButtonProps {
  label: string
  variant?: 'primary' | 'secondary' | 'danger'
  onClick?: () => void
}

export const Button: React.FC<ButtonProps> = ({ 
  label, 
  variant = 'primary', 
  onClick 
}) => {
  const variants = {
    primary: 'bg-blue-600 hover:bg-blue-700 text-white',
    secondary: 'bg-gray-300 hover:bg-gray-400 text-gray-900',
    danger: 'bg-red-600 hover:bg-red-700 text-white'
  }

  return (
    <button 
      className={`px-4 py-2 rounded font-medium transition ${variants[variant]}`}
      onClick={onClick}
    >
      {label}
    </button>
  )
}
```

**Usage in React:**
```tsx
<Button label="Click Me" variant="primary" onClick={handleClick} />
```

## 🧪 Testing

The project includes comprehensive testing for both React and Razor components:

### React Tests (Vitest)
- **Framework:** Vitest 0.34.0
- **Assertion Library:** @testing-library/react 14.0.0
- **Location:** `test/ViewsClientTests/components/`
- **Coverage:** Button (5 tests), Stats (2 tests)

### Razor Tests (XUnit + bunit)
- **Framework:** XUnit 2.6.0
- **Component Testing:** bunit 1.31.3
- **Assertions:** FluentAssertions 6.12.0
- **Location:** `test/ViewsTests/Server/Components/`
- **Coverage:** Card (7 tests), Alert (6 tests), HelloWorld (8 tests)

### Running Tests

See the [testing guide](test/README.md) for detailed information on writing and running tests.

## 🔧 Development Tips

### Path Aliases

Both TypeScript and Vitest are configured with path aliases for cleaner imports:

```typescript
// Instead of:
import { Button } from '../../../Views/Client/components/Button'

// Use:
import { Button } from '@components/Button'
```

**Available aliases:**
- `@components` → `src/Views/Client/components/`
- `@pages` → `src/Views/Client/pages/`
- `@features` → `src/Views/Client/features/`
- `@styles` → `src/Views/Client/styles/`

### Code Formatting

**Format all code:**
```bash
npm run format
```

**Lint TypeScript:**
```bash
npm run lint
```

### Environment Variables

Create a `.env` file in the root directory for environment-specific settings:
```
VITE_API_URL=https://api.example.com
VITE_ENV=development
```

Access in React:
```typescript
const apiUrl = import.meta.env.VITE_API_URL
```

## 📚 Additional Documentation

- [Views Library README](src/Views/README.md) - Component library details
- [Testing Guide](test/README.md) - Comprehensive testing documentation
- [Test Completion Summary](agents/TEST_COMPLETION_SUMMARY.md) - Full test results and details
- [Razor Tests Documentation](agents/RAZOR_TESTS_COMPLETE.md) - Detailed Razor component tests

## 🚢 Deployment

### Prerequisites

- .NET 9 Runtime or self-contained deployment.

### Build for Production

```bash
# Full build (includes npm bundle)
dotnet build -c Release

# Or publish
dotnet publish src/Site -c Release -o ./publish
```

### Deployment Steps

1. Build the project in Release mode
2. The npm build is automatically included via MSBuild
3. Publish the `src/Site` project
4. Deploy the contents of the `publish` directory to your hosting

## 🤝 Contributing

1. Create a feature branch from `main`
2. Make your changes following the established patterns
3. Add tests for new functionality
4. Ensure all tests pass: `npm run test`
5. Format code: `npm run format`
6. Submit a pull request

## 📝 Project Configuration Files

- **vite.config.ts** - Vite bundler configuration with React support
- **vitest.config.ts** - Vitest test runner configuration
- **tsconfig.json** - TypeScript compiler options and path aliases
- **tailwind.config.js** - Tailwind CSS customization and content paths
- **postcss.config.js** - PostCSS plugins (Tailwind processing)
- **package.json** - Node.js dependencies and npm scripts
- **MarketingSiteTemplate.sln** - Visual Studio solution file

## 📄 License

MIT

## 🆘 Troubleshooting

**Issue: CSS not loading in development**
- Ensure `npm run watch` or `npm run dev` is running
- Clear browser cache (Ctrl+Shift+Delete)
- Check that Vite is outputting to `src/Views/wwwroot/bundle/`

**Issue: Components not appearing in Razor pages**
- Verify component namespace in `_ViewImports.cshtml`
- Check that the component is in the Views library
- Ensure the Views package reference is present

**Issue: Tests failing**
- Run `npm install` to ensure all dependencies are installed
- Run `dotnet restore` for .NET packages
- Check test output for specific error messages
- See [Testing Guide](test/README.md) for test-specific issues

## 📞 Support

For issues or questions:
1. Check the [Testing Guide](test/README.md) for test-related questions
2. Review [Views Library README](src/Views/README.md) for component questions
3. Check project documentation in `agents/` directory
