# Development Guide

This document explains how the Avalonia `dotnet new` templates are structured, how to build and test them locally, and how to add new templates or parameters. If you only want to *use* the templates, see the [README.md](README.md) instead.

This guide covers the Avalonia-specific conventions. For a step-by-step walkthrough, see the [dotnet template tutorial](https://learn.microsoft.com/en-us/dotnet/core/tutorials/cli-templates-create-project-template); for the full `template.json` schema and options, see the [.NET custom templates reference](https://learn.microsoft.com/en-us/dotnet/core/tools/custom-templates) and the [dotnet/templating samples](https://github.com/dotnet/templating/wiki/Available-templates-for-dotnet-new).

## How the templates work

Everything ships as a single NuGet package, `Avalonia.Templates`, defined by [`Avalonia.Templates.csproj`](Avalonia.Templates.csproj). The `.csproj` doesn't compile any code, it only packs everything under `templates/` into the package.

Each template lives in its own folder under `templates/` and is described by a `.template.config/` directory:

| File | Purpose                                                 |
|------|---------------------------------------------------------|
| `template.json` | The template definition, including parameters (symbols). |
| `dotnetcli.host.json` | Maps parameters to their **CLI** arguments.             |
| `ide.host.json` | Maps parameters to their **IDE** settings.              |

C# and F# variants are kept as separate templates under `templates/csharp/` and `templates/fsharp/`, but share the same short name (e.g. `avalonia.app`) and are told apart by their language tag.

## Building and installing locally

To try your changes, pack the templates and install them from the local package:

```powershell
./install-dev-templates.ps1
```

This uninstalls any existing `Avalonia.Templates`, runs `dotnet pack`, and installs the freshly built `.nupkg`.

## Testing

Templates are tested by generating projects from them and building the results.
The test script is [`tests/build-test.ps1`](tests/build-test.ps1). Run it from the `tests` folder:

```powershell
cd tests
./build-test.ps1
```

It creates every application template with different combinations of parameters and builds each one to make sure it compiles.
A build binary log is written to `binlog/test.binlog`.

When you add a new template or parameter, add matching lines to `build-test.ps1` so it gets built in CI.

## Adding a new template

Add a new template under `templates/csharp/<your-template>/` (and `templates/fsharp/...` for an F# variant), with a unique `identity` and `shortName` in `template.json`, and update the CLI/IDE files if it takes parameters (see below).
The existing templates are the best reference.

Finally, add build coverage in `tests/build-test.ps1` and document it in [README.md](README.md).

## Adding a new parameter

A parameter is a *symbol* in `template.json`, given a CLI name in `dotnetcli.host.json` and an IDE label in `ide.host.json`.
**Make sure to update all three files**. Without the CLI and IDE entries, the parameter won't be usable from the command line or shown in IDEs.

Add test coverage in `tests/build-test.ps1` and document the parameter in [README.md](README.md).
