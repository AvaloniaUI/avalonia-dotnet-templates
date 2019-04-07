# Avalonia Templates for `dotnet new`

For more information about `dotnet new` templates see [here](https://blogs.msdn.microsoft.com/dotnet/2017/04/02/how-to-create-your-own-templates-for-dotnet-new/).

## Installing the templates

Clone this repository and run:

```
dotnet new --install [path-to-repository]
```

The templates should now be available in `dotnet`:

```
Templates                   Short Name         Language        Tags
--------------------------------------------------------------------------
Console Application         console              [C#], F#      Common/Console
Class library               classlib             [C#], F#      Common/Library
Unit Test Project           mstest               [C#], F#      Test/MSTest
xUnit Test Project          xunit                [C#], F#      Test/xUnit
ASP.NET Core Empty          web                  [C#]          Web/Empty
ASP.NET Core Web App        mvc                  [C#], F#      Web/MVC
ASP.NET Core Web API        webapi               [C#]          Web/WebAPI
Avalonia .NET Core App      avalonia.app         [C#]          ui/xaml
Avalonia .NET Core MVVM App avalonia.mvvm        [C#]          ui/xaml
Avalonia UserControl        avalonia.usercontrol [C#]          ui/xaml
Avalonia Window             avalonia.window      [C#]          ui/xaml
Solution File               sln                                Solution
```

# Creating a new MVVM Application

MVVM is the recommended pattern for creating Avalonia applications. The MVVM application template
uses [ReactiveUI](https://reactiveui.net/) to ease building applications with complex interactions.

To create a new MVVM application called `MyApp` in its own subdirectory, run:

```
dotnet new avalonia.mvvm -o MyApp
```

# Creating a new Application

To create a new barebones application called `MyApp` in its own subdirectory, run:

```
dotnet new avalonia.app -o MyApp
```

# Creating a new Window

To create a new application called `MyNewWindow`, in the namespace `MyApp` run:

```
dotnet new avalonia.window -na MyApp -n MyNewWindow
```

# Creating a new UserControl

To create a new `UserControl` called `MyNewView`, in the namespace `MyApp` run:

```
dotnet new avalonia.window -na MyApp -n MyNewView
```
