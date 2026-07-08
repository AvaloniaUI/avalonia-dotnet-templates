# Enable common parameters e.g. -Verbose
[CmdletBinding()]
param(
    # Number of template builds to run concurrently. Each build is limited to a
    # single MSBuild node (-m:1), so script-level parallelism does the work
    # instead of every build fanning out and oversubscribing the CPU.
    [int]$ThrottleLimit = [Environment]::ProcessorCount,

    # Extra NuGet feed to restore from. Used to test the templates against packages
    # that aren't on nuget.org yet (e.g. an Avalonia nightly feed).
    [string]$NuGetSource
)

Set-StrictMode -Version latest
$ErrorActionPreference = "Stop"

$env:DOTNET_CLI_TELEMETRY_OPTOUT = "1"
$env:DOTNET_NOLOGO = "1"

# All paths are resolved relative to the repo root (the parent of /tests) so the
# script behaves the same no matter what the current directory is.
$repoRoot  = [IO.Path]::GetFullPath([IO.Path]::Combine($PSScriptRoot, ".."))
$outDir    = [IO.Path]::Combine($repoRoot, "output")
$binlogDir = [IO.Path]::Combine($repoRoot, "binlog")

function New-Case($template, $name, $lang, $param, $value, [switch]$Items) {
    [pscustomobject]@{
        Template = $template
        Name     = $name
        Lang     = $lang
        Param    = $param
        Value    = $value
        Items    = [bool]$Items
    }
}

# -HasCodeBehind marks item templates that emit language-specific code-behind
# (a .axaml.<cs|fs> next to the .axaml). Those are the ones that take -lang, and
# the ones whose code-behind F# has to add to the .fsproj by hand. Pure-XAML
# item templates (resource dictionary, styles) have neither.
function New-ItemCase($template, $name, [switch]$HasCodeBehind) {
    [pscustomobject]@{
        Template      = $template
        Name          = $name
        HasCodeBehind = [bool]$HasCodeBehind
    }
}

$builds = @(
    New-Case "avalonia.app"   "AvaloniaApp"   "C#" "f"   "net10.0"
    New-Case "avalonia.app"   "AvaloniaApp"   "C#" "av"  "12.0.5"

    New-Case "avalonia.mvvm"  "AvaloniaMvvm"  "C#" "f"   "net10.0" -Items
    New-Case "avalonia.mvvm"  "AvaloniaMvvm"  "C#" "f"   "net8.0"
    New-Case "avalonia.mvvm"  "AvaloniaMvvm"  "C#" "av"  "12.0.5"
    New-Case "avalonia.mvvm"  "AvaloniaMvvm"  "C#" "m"   "ReactiveUI"
    New-Case "avalonia.mvvm"  "AvaloniaMvvm"  "C#" "m"   "CommunityToolkit"
    New-Case "avalonia.mvvm"  "AvaloniaMvvm"  "C#" "rvl" "true"
    New-Case "avalonia.mvvm"  "AvaloniaMvvm"  "C#" "rvl" "false"

    New-Case "avalonia.xplat" "AvaloniaXplat" "C#" "f"   "net10.0"
    New-Case "avalonia.xplat" "AvaloniaXplat" "C#" "cpm" "true"
    New-Case "avalonia.xplat" "AvaloniaXplat" "C#" "cpm" "false"
    New-Case "avalonia.xplat" "AvaloniaXplat" "C#" "av"  "12.0.5"
    New-Case "avalonia.xplat" "AvaloniaXplat" "C#" "m"   "ReactiveUI"
    New-Case "avalonia.xplat" "AvaloniaXplat" "C#" "m"   "CommunityToolkit"
    New-Case "avalonia.xplat" "AvaloniaXplat" "C#" "rvl" "true"
    New-Case "avalonia.xplat" "AvaloniaXplat" "C#" "rvl" "false"
    New-Case "avalonia.xplat" "AvaloniaXplat" "C#" "page" "ContentPage"
    New-Case "avalonia.xplat" "AvaloniaXplat" "C#" "page" "TabbedPage"
    New-Case "avalonia.xplat" "AvaloniaXplat" "C#" "page" "DrawerPage"
    New-Case "avalonia.xplat" "AvaloniaXplat" "C#" "page" "NavigationPage"

    New-Case "avalonia.app"   "AvaloniaApp"   "F#" "f"   "net10.0"
    New-Case "avalonia.app"   "AvaloniaApp"   "F#" "av"  "12.0.5"

    New-Case "avalonia.mvvm"  "AvaloniaMvvm"  "F#" "f"   "net10.0" -Items
    New-Case "avalonia.mvvm"  "AvaloniaMvvm"  "F#" "f"   "net8.0"
    New-Case "avalonia.mvvm"  "AvaloniaMvvm"  "F#" "av"  "12.0.5"
    New-Case "avalonia.mvvm"  "AvaloniaMvvm"  "F#" "m"   "ReactiveUI"
    New-Case "avalonia.mvvm"  "AvaloniaMvvm"  "F#" "m"   "CommunityToolkit"
    New-Case "avalonia.mvvm"  "AvaloniaMvvm"  "F#" "rvl" "true"
    New-Case "avalonia.mvvm"  "AvaloniaMvvm"  "F#" "rvl" "false"

    New-Case "avalonia.xplat" "AvaloniaXplat" "F#" "f"   "net10.0"
    New-Case "avalonia.xplat" "AvaloniaXplat" "F#" "av"  "12.0.5"
    New-Case "avalonia.xplat" "AvaloniaXplat" "F#" "m"   "ReactiveUI"
    New-Case "avalonia.xplat" "AvaloniaXplat" "F#" "m"   "CommunityToolkit"
    New-Case "avalonia.xplat" "AvaloniaXplat" "F#" "rvl" "true"
    New-Case "avalonia.xplat" "AvaloniaXplat" "F#" "rvl" "false"
)

$itemTemplates = @(
    New-ItemCase "avalonia.resource"         "NewResourceDictionary"
    New-ItemCase "avalonia.styles"           "NewStyles"
    New-ItemCase "avalonia.usercontrol"      "NewUserControl"      -HasCodeBehind
    New-ItemCase "avalonia.window"           "NewWindow"           -HasCodeBehind
    New-ItemCase "avalonia.templatedcontrol" "NewTemplatedControl" -HasCodeBehind
    New-ItemCase "avalonia.contentpage"      "NewContentPage"      -HasCodeBehind
    New-ItemCase "avalonia.drawerpage"       "NewDrawerPage"       -HasCodeBehind
    New-ItemCase "avalonia.navigationpage"   "NewNavigationPage"   -HasCodeBehind
    New-ItemCase "avalonia.tabbedpage"       "NewTabbedPage"       -HasCodeBehind
)

Write-Output "Clearing outputs from possible previous runs"
foreach ($dir in @($outDir, $binlogDir)) {
    if (Test-Path $dir) { Remove-Item -Recurse -Force $dir }
}
New-Item -ItemType Directory -Force -Path $outDir | Out-Null
New-Item -ItemType Directory -Force -Path $binlogDir | Out-Null

$nuGetConfigFile = [IO.Path]::Combine($outDir, "nuget.config")
Copy-Item -Path ([IO.Path]::Combine($repoRoot, "nuget.config")) -Destination $nuGetConfigFile

if ($NuGetSource) {
    Write-Output "Adding NuGet source $NuGetSource"
    $nuGetSourceName = "avalonia-templates-build-test"
    # Drop a previous registration first: `dotnet nuget add source` fails if the
    # name is already taken, which would break a second run of the script.
    & dotnet nuget remove source $nuGetSourceName --configfile "$nuGetConfigFile" 2>&1 | Out-Null
    & dotnet nuget add source $NuGetSource --name $nuGetSourceName --configfile "$nuGetConfigFile" 2>&1 | Out-Host
    if ($LASTEXITCODE -ne 0) { throw "dotnet nuget add source $NuGetSource exited with $LASTEXITCODE" }
}

Write-Output "Warming NuGet cache"
$warmDir = [IO.Path]::Combine($outDir, "_warm")
try {
    & dotnet new avalonia.xplat -o $warmDir -lang "C#" 2>&1 | Out-Host
    & dotnet restore $warmDir 2>&1 | Out-Host
}
catch {
    Write-Output "WARNING: NuGet warm-up failed (continuing): $_"
}
finally {
    Remove-Item -Recurse -Force -ErrorAction SilentlyContinue $warmDir
}

Write-Output "Building $($builds.Count) template variants (throttle: $ThrottleLimit)"

$results = $builds | ForEach-Object -ThrottleLimit $ThrottleLimit -Parallel {
    Set-StrictMode -Version latest
    $ErrorActionPreference = "Stop"

    $b             = $_
    $outDir        = $using:outDir
    $binlogDir     = $using:binlogDir
    $itemTemplates = $using:itemTemplates

    # Remove dots and - from folderName; in a sln they cause build errors.
    $folderName = ($b.Name + $b.Param + $b.Value) -replace "[.-]"
    $projDir    = [IO.Path]::Combine($outDir, $b.Lang, $folderName)
    $langTag    = $b.Lang -replace "#", "sharp"
    $binlog     = [IO.Path]::Combine($binlogDir, "${langTag}_${folderName}.binlog")

    # Run dotnet, route its output to the host and fail on a non-zero exit code.
    function Invoke-Dotnet([string[]]$dotnetArgs) {
        & dotnet @dotnetArgs 2>&1 | ForEach-Object { Write-Host $_ }
        if ($LASTEXITCODE -ne 0) {
            throw "dotnet $($dotnetArgs -join ' ') exited with $LASTEXITCODE"
        }
    }

    $sw = [Diagnostics.Stopwatch]::StartNew()
    try {
        # Create the project.
        Invoke-Dotnet @("new", $b.Template, "-o", $projDir, "-$($b.Param)", $b.Value, "-lang", $b.Lang)

        # Instantiate each item template into the project.
        if ($b.Items) {
            foreach ($item in $itemTemplates) {
                $newArgs = @("new", $item.Template, "-o", $projDir, "-n", $item.Name)
                if ($item.HasCodeBehind) { $newArgs += @("-lang", $b.Lang) }
                Invoke-Dotnet $newArgs
            }

            if ($b.Lang -eq "F#") {
                # F# needs the item templates' code-behind added to the project,
                $fsprojPath = [IO.Path]::Combine($projDir, $folderName + ".fsproj")
                [xml]$doc = Get-Content $fsprojPath
                foreach ($item in ($itemTemplates | Where-Object HasCodeBehind)) {
                    $node = $doc.CreateElement("Compile")
                    $node.SetAttribute("Include", "$($item.Name).axaml.fs")
                    $doc.Project.ItemGroup[0].PrependChild($node) | Out-Null
                }
                $doc.Save($fsprojPath)
            }
        }

        # Test build. Only run -t:Compile target to validate that this project is valid.
        # We do not run full build that might involve slow packaging on android or browser targets. 
        Invoke-Dotnet @("build", "-t:Compile", $projDir, "-m:1", "-bl:$binlog")

        Remove-Item -Recurse -Force -ErrorAction SilentlyContinue $projDir

        [pscustomobject]@{ Lang = $b.Lang; Name = $folderName; Success = $true;  Message = ""; Seconds = $sw.Elapsed.TotalSeconds }
    }
    catch {
        [pscustomobject]@{ Lang = $b.Lang; Name = $folderName; Success = $false; Message = "$_"; Seconds = $sw.Elapsed.TotalSeconds }
    }
}

# Report and fail the run if any build failed.
Write-Output "`n================ Results ================"
foreach ($r in ($results | Sort-Object Seconds -Descending)) {
    $status = if ($r.Success) { "PASS" } else { "FAIL" }
    Write-Output ("{0}  {1,7:N1}s  {2,-3} {3}" -f $status, $r.Seconds, $r.Lang, $r.Name)
    if (-not $r.Success) { Write-Output "      $($r.Message)" }
}

$failed = @($results | Where-Object { -not $_.Success })
if ($failed.Count -gt 0) {
    throw "$($failed.Count) of $($results.Count) template build(s) failed."
}
Write-Output "All $($results.Count) template builds succeeded."
