# Koala Modernization - Cross-Platform .NET Support

This document describes the modernization of the Koala projects to support the latest .NET versions and cross-platform development.

## Changes Made

### Project Structure Modernization

1. **Converted to SDK-style project files**: All projects (Koala.vbproj, KoalaResults.csproj, KoalaUT.vbproj) have been modernized from the legacy format to the new SDK-style format.

2. **Multi-targeting support**: Projects now target both:
   - `net48` (.NET Framework 4.8) - for compatibility with existing Rhino 6/7 installations
   - `net6.0-windows` (.NET 6 Windows) - for future compatibility with modern .NET and potential cross-platform scenarios

3. **PackageReference migration**: Moved from packages.config to PackageReference format for better dependency management.

### NuGet Package Updates

- **For .NET Framework 4.8 targets**:
  - RhinoCommon: 6.34.21034.7001 (stable, proven compatibility)
  - Grasshopper: 6.34.21034.7001

- **For .NET 6.0-windows targets**:
  - RhinoCommon: 8.23.25251.13001 (latest stable for Rhino 8)
  - Grasshopper: 8.23.25251.13001
  - System.Drawing.Common: 8.0.10 (for cross-platform graphics support)

### Cross-Platform Considerations

#### Output Paths
The projects now support both Windows and macOS/Linux paths:
- **Windows**: `$(APPDATA)\Grasshopper\Libraries\`
- **macOS/Linux**: `$(HOME)/.config/Grasshopper/Libraries/`

#### Rhino Executable Paths
Debug startup programs are configured for both platforms:
- **Windows (.NET Framework)**: `C:\Program Files\Rhino 6\System\Rhino.exe`
- **Windows (.NET 6)**: `C:\Program Files\Rhino 8\System\Rhino.exe`
- **macOS**: `/Applications/RhinoWIP.app/Contents/MacOS/Rhino`

## Building the Solution

### Prerequisites

**For Windows development:**
- Visual Studio 2022 with .NET Framework 4.8 and .NET 6.0 SDK
- Rhino 6/7 or Rhino 8 installed
- .NET Framework 4.8 Developer Pack
- .NET 6.0 Windows Desktop Runtime

**For macOS development (when available):**
- .NET 6.0 SDK
- Rhino for Mac (when Grasshopper support becomes available)

### Build Commands

```bash
# Restore packages
dotnet restore

# Build all target frameworks
dotnet build

# Build specific target framework
dotnet build -f net48
dotnet build -f net6.0-windows

# Build for release
dotnet build -c Release
```

## Current Limitations and Future Considerations

### RhinoCommon/Grasshopper Ecosystem Status

As of 2025, the RhinoCommon and Grasshopper packages are primarily designed for Windows and .NET Framework. While the projects are now structured for multi-targeting:

1. **Current Reality**: RhinoCommon 8.x packages still target .NET Framework, not modern .NET
2. **Windows Dependency**: The packages require Windows Forms and Windows-specific APIs
3. **Future Ready**: The project structure is prepared for when McNeel releases true cross-platform packages

### Cross-Platform Strategy

The modernization provides multiple benefits:

1. **Immediate**: Better tooling, modern project format, improved dependency management
2. **Short-term**: Ready for Rhino 8 with .NET Framework compatibility
3. **Long-term**: Prepared for true cross-platform RhinoCommon when available

### macOS Compatibility

While true macOS compatibility awaits upstream support from McNeel, the projects are structured to support it:

- Cross-platform file paths
- Conditional compilation symbols
- Modern .NET SDK usage
- Prepared for future RhinoCommon packages with macOS support

## Testing

The test project (KoalaUT) has been updated with:
- Modern MSTest packages (3.6.3)
- Multi-targeting support
- Cross-platform path support

Run tests with:
```bash
dotnet test
```

## Development Workflow

1. **For current development**: Use the `net48` target for maximum compatibility
2. **For future-proofing**: Test with `net6.0-windows` target when possible
3. **Cross-platform testing**: The structure is ready for when RhinoCommon supports it

## Migration Notes

- Original project files are backed up as `.bak` files
- All packages.config files have been removed
- Legacy MSBuild imports have been replaced with modern PackageReference
- Assembly version handling is now automatic via SDK
- Resource file handling is simplified in the new format

## Recommendations

1. **Immediate adoption**: Use `net48` builds for production
2. **Testing**: Regularly test `net6.0-windows` builds as the ecosystem evolves
3. **Monitor updates**: Watch for McNeel announcements about cross-platform RhinoCommon
4. **Incremental migration**: Projects can be used immediately with the new structure

This modernization ensures Koala is ready for the future while maintaining current compatibility.