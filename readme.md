[![downloads](https://img.shields.io/nuget/dt/avalonia.templates)](https://www.nuget.org/packages/Avalonia.Templates/)
[![Current stable version](https://img.shields.io/nuget/v/Avalonia.Templates.svg)](https://www.nuget.org/packages/Avalonia.Templates/)
# Avalonia Templates for `dotnet new`

For more information about `dotnet new` templates see [here](https://blogs.msdn.microsoft.com/dotnet/2017/04/02/how-to-create-your-own-templates-for-dotnet-new/).

## Installing the templates

Run from a command line:

```powershell
dotnet new install Avalonia.Templates
```

The templates should now be available in `dotnet new list`:

```
Template Name                        Short Name                 Language  Tags
-----------------------------------  -------------------------  --------  -----------------------------------------
Avalonia .NET App                    avalonia.app               [C#],F#   Desktop/Xaml/Avalonia/Windows/Linux/macOS
Avalonia .NET MVVM App               avalonia.mvvm              [C#],F#   Desktop/Xaml/Avalonia/Windows/Linux/macOS
Avalonia Cross Platform Application  avalonia.xplat             [C#],F#   Desktop/Xaml/Avalonia/Web/Mobile
Avalonia Resource Dictionary         avalonia.resource                    Desktop/Xaml/Avalonia/Windows/Linux/macOS
Avalonia Styles                      avalonia.styles                      Desktop/Xaml/Avalonia/Windows/Linux/macOS
Avalonia TemplatedControl            avalonia.templatedcontrol  [C#],F#   Desktop/Xaml/Avalonia/Windows/Linux/macOS
Avalonia UserControl                 avalonia.usercontrol       [C#],F#   Desktop/Xaml/Avalonia/Windows/Linux/macOS
Avalonia Window                      avalonia.window            [C#],F#   Desktop/Xaml/Avalonia/Windows/Linux/macOS
```

**Note:**

By default dotnet CLI would create a **C#** template,if you want to create **F#** template you will need to add ```-lang F#``` to the end of the command.

# Creating a new Application

To create a new barebones application called `MyApp` in its own subdirectory, run:

```
dotnet new avalonia.app -o MyApp
```

| Parameter | Description | Options | Default |
|-----------|-------------|---------|---------|
| `-f`, `--framework` | The target framework for the project. | `net10.0`, `net9.0`, `net8.0` | `net10.0` |
| `-av`, `--avalonia-version` | The target version of Avalonia NuGet packages. | | `12.0.1` |
| `-cb`, `--compiled-bindings` | Enable CompiledBindings by default (11.0+). See [documentation](https://docs.avaloniaui.net/docs/data-binding/compiledbindings). | `true`, `false` | `true` |
| `--no-restore` | If specified, skips the automatic restore of the project on create. | | |

## Creating a new MVVM Application

MVVM is the recommended pattern for creating Avalonia applications. The MVVM application template
uses [ReactiveUI](https://reactiveui.net/) to ease building applications with complex interactions.

To create a new MVVM application called `MyApp` in its own subdirectory, run:

```
dotnet new avalonia.mvvm -o MyApp
```

| Parameter | Description | Options | Default |
|-----------|-------------|---------|---------|
| `-f`, `--framework` | The target framework for the project. | `net10.0`, `net9.0`, `net8.0` | `net10.0` |
| `-av`, `--avalonia-version` | The target version of Avalonia NuGet packages. | | `12.0.1` |
| `-cb`, `--compiled-bindings` | Enable CompiledBindings by default (11.0+). See [documentation](https://docs.avaloniaui.net/docs/data-binding/compiledbindings). | `true`, `false` | `true` |
| `-m`, `--mvvm` | MVVM toolkit to use in the template. | `ReactiveUI`, `CommunityToolkit` | `ReactiveUI` |
| `-rvl`, `--remove-view-locator` | Remove the default ViewLocator. Useful for code trimming scenarios as the default ViewLocator is not trimming-friendly. | `true`, `false` | `false` |
| `--no-restore` | If specified, skips the automatic restore of the project on create. | | |

## Creating a new Cross-Platform application

To create a new Cross-Platform application in its own subdirectory, run:

```
dotnet new avalonia.xplat 
```

This template creates an application that works on Desktop, Browser and Mobile (iOS & Android). Only available with 11.0 preview versions and newer.

| Parameter | Description | Options | Default |
|-----------|-------------|---------|---------|
| `-av`, `--avalonia-version` | The target version of Avalonia NuGet packages. | | `12.0.1` |
| `-cb`, `--compiled-bindings` | Enable CompiledBindings by default. See [documentation](https://docs.avaloniaui.net/docs/data-binding/compiledbindings). | `true`, `false` | `true` |
| `-m`, `--mvvm` | MVVM toolkit to use in the template. | `ReactiveUI`, `CommunityToolkit` | `ReactiveUI` |
| `-rvl`, `--remove-view-locator` | Remove the default ViewLocator. Useful for code trimming scenarios as the default ViewLocator is not trimming-friendly. | `true`, `false` | `false` |
| `-cpm` | Use Central Package Management (CPM). If disabled, `Directory.Build.props` will be created with the shared Avalonia version. | `true`, `false` | `true` |

## Creating a new Window

To create a new `Window` called `MyNewWindow`, in the namespace `MyApp` run:

```
dotnet new avalonia.window -na MyApp -n MyNewWindow
```

## Creating a new UserControl

To create a new `UserControl` called `MyNewView`, in the namespace `MyApp` run:

```
dotnet new avalonia.usercontrol -na MyApp -n MyNewView
```

## Creating a new Styles list

To create a new `Styles` list called `MyStyles`, run:

```
dotnet new avalonia.styles -n MyStyles
```

## Creating a new ResourceDictionary

To create a new `ResourceDictionary` called `MyResources`, run:

```
dotnet new avalonia.resource -n MyResources
```
