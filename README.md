# Koala

Koala is a Grasshopper component to connect Grasshopper with SCIA Engineer for parametric/generative design.

It takes Grasshopper geometry and produces a SCIA Engineer XML with the corresponding data.

[![](https://resources.scia.net/en/garage/images/grasshopperkoala_thumb_0_100.png)](https://resources.scia.net/en/garage/images/grasshopperkoala.png)

### Supports

* Straight segments, circle arcs, lines and polylines with beam rotations and layers
* Flat or curved and circular surfaces
* Complex plane surfaces, including complex openings
* Hinges
* Node supports, edge supports
* Line loads, free loads on surfaces
* Mesh size definition
* Batch-mode: ability to run an analysis and get results through "esa\_xml.exe"
* And more…

See our webinar below how to use Koala in your projects https://youtu.be/RY-K4LVAiWw

If you miss something you can vote for feature or add new -> https://github.com/jarabroz/Koala/discussions/categories/ideas

[![Board Status](https://dev.azure.com/jarabroz/1c37fca5-d711-4c44-b967-83b47e2631b4/2d85ad6f-58b6-4132-9a00-c2a6ae77d146/_apis/work/boardbadge/ac2c8eaf-0309-4d0a-aaaa-9aa28e58fc92?columnOptions=1)](https://dev.azure.com/jarabroz/1c37fca5-d711-4c44-b967-83b47e2631b4/_boards/board/t/2d85ad6f-58b6-4132-9a00-c2a6ae77d146/Microsoft.FeatureCategory/)

[![Build Status](https://jarabroz.visualstudio.com/Koala/_apis/build/status/jarabroz.Koala?branchName=master)](https://jarabroz.visualstudio.com/Koala/_build/latest?definitionId=1&branchName=master)

## Building from Source

### Prerequisites

#### All Platforms
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Git

#### For Windows Development
- Visual Studio 2022 with .NET desktop development workload, or
- Visual Studio Code with C# Dev Kit extension
- Rhino 8 (for testing and debugging)

#### For macOS Development  
- [.NET 8.0 SDK for macOS](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio Code with C# Dev Kit extension, or
- Visual Studio for Mac 2022
- Rhino for Mac 8 (for testing, when supported)

### Building on macOS

The codebase has been updated to use .NET 8 and modern SDK-style project files. Currently, the following projects can be built on macOS:

1. **KoalaResults** - Fully compatible with .NET 8 on macOS
2. **KoalaUT** (Test project) - Fully compatible with .NET 8 on macOS
3. **Koala** (Main project) - Requires Windows-specific components due to Grasshopper dependencies

#### Clone and Build

```bash
# Clone the repository
git clone https://github.com/sanderboer/Koala.git
cd Koala

# Build cross-platform components (KoalaResults and tests)
dotnet build KoalaResults/KoalaResults.csproj
dotnet build KoalaUT/KoalaUT.vbproj

# Run tests
dotnet test KoalaUT/KoalaUT.vbproj
```

#### Building the Complete Solution

The main Koala project currently requires Windows-specific APIs due to Grasshopper's dependency on Windows Forms and GDI+. On macOS, you can:

1. **Build what's compatible now**: The KoalaResults project builds successfully
2. **Prepare for future cross-platform support**: The project structure is ready for when Rhino/Grasshopper fully support .NET Core on macOS

### Building on Windows

```bash
# Clone the repository  
git clone https://github.com/sanderboer/Koala.git
cd Koala

# Restore packages and build all projects
dotnet restore
dotnet build

# Or build the entire solution
dotnet build Koala.sln
```

### Project Structure Changes

The project has been modernized with:

- **Updated to .NET 8**: All projects target .NET 8 instead of .NET Framework
- **Modern SDK-style projects**: Simplified project files using the new SDK format
- **PackageReference**: Updated from legacy packages.config to PackageReference
- **Rhino.Inside**: Uses the latest Rhino.Inside packages that support .NET Core
- **Cross-platform ready**: Structure prepared for full cross-platform support

### Cross-Platform Limitations

Currently, some limitations exist for full macOS support:

1. **Grasshopper Dependencies**: The main Koala project uses Grasshopper components that depend on Windows Forms
2. **Rhino for Mac**: Rhino for Mac doesn't yet have complete .NET Core plugin support comparable to Windows
3. **Platform-Specific APIs**: Some Windows-specific file paths and registry access

### Future Cross-Platform Support

The codebase is structured to support full cross-platform development when:
- Rhino for Mac gains complete .NET Core plugin support  
- Grasshopper components become fully cross-platform compatible
- Platform-specific code is abstracted behind interfaces

### Development Environment Setup

#### macOS with Visual Studio Code

```bash
# Install .NET 8 SDK
brew install --cask dotnet-sdk

# Install VS Code with C# extension
brew install --cask visual-studio-code
code --install-extension ms-dotnettools.csdevkit
```

#### macOS with Visual Studio for Mac

1. Download and install Visual Studio for Mac 2022
2. Ensure .NET 8 workload is installed
3. Open the solution file

### Contributing

When contributing to cross-platform compatibility:

1. Test builds on both Windows and macOS when possible
2. Use conditional compilation for platform-specific code
3. Prefer cross-platform APIs when available
4. Document any platform-specific requirements

## 


