# Repository guidance

Before starting any task in this repository, read [`DEVELOPMENT.md`](DEVELOPMENT.md).
It explains how the templates are structured and how to build, test, and extend them.

Key conventions:
- Templates live under `templates/csharp/` and `templates/fsharp/`, described by a `.template.config/` folder.
- A parameter must be added in all three files: `template.json` (symbol), `dotnetcli.host.json` (CLI), and `ide.host.json` (IDE).
- Add build coverage for new templates or parameters in `tests/build-test.ps1`, and document user-facing changes in `readme.md`.
