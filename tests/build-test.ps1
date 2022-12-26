Set-StrictMode -Version latest
$ErrorActionPreference = "Stop"

# Taken from psake https://github.com/psake/psake
<#
.SYNOPSIS
  This is a helper function that runs a scriptblock and checks the PS variable $lastexitcode
  to see if an error occcured. If an error is detected then an exception is thrown.
  This function allows you to run command-line programs without having to
  explicitly check the $lastexitcode variable.
.EXAMPLE
  exec { svn info $repository_trunk } "Error executing SVN. Please verify SVN command-line client is installed"
#>
function Exec
{
    [CmdletBinding()]
    param(
        [Parameter(Position=0,Mandatory=1)][scriptblock]$cmd,
        [Parameter(Position=1,Mandatory=0)][string]$errorMessage = ("Error executing command {0}" -f $cmd)
    )
    & $cmd
    if ($lastexitcode -ne 0) {
        throw ("Exec: " + $errorMessage)
    }
}

function Test-Template {
    param (
        [Parameter(Position=0,Mandatory=1)][string]$template,
        [Parameter(Position=1,Mandatory=1)][string]$name,
        [Parameter(Position=2,Mandatory=1)][string]$lang,
        [Parameter(Position=3,Mandatory=1)][string]$parameterName,
        [Parameter(Position=4,Mandatory=1)][string]$value,
        [Parameter(Position=5,Mandatory=0)][string]$bl
    )

    $outDir = [IO.Path]::GetFullPath([IO.Path]::Combine($pwd, "..", "output"))
    $folderName = $name + $parameterName + $value
    
    # Remove dots and - from folderName because in sln it will cause errors when building project
    $folderName = $folderName -replace "[.-]"
    
    # Create the project
    Exec { dotnet new $template -o $outDir/$lang/$folderName -$parameterName $value -lang $lang }

    # Instantiate each item template in the project
    Exec { dotnet new avalonia.resource -o $outDir/$lang/$folderName -n NewResourceDictionary }
    Exec { dotnet new avalonia.styles -o $outDir/$lang/$folderName -n NewStyles }
    Exec { dotnet new avalonia.usercontrol -o $outDir/$lang/$folderName -n NewUserControl -lang $lang }
    Exec { dotnet new avalonia.window -o $outDir/$lang/$folderName -n NewWindow -lang $lang }
    If($lang -eq "F#")
    {
        $fsprojPath = [IO.Path]::Combine($outDir, $lang, $folderName, $folderName + '.fsproj')

        [xml]$doc = Get-Content $fsprojPath
        $item = $doc.CreateElement('Compile')
        $item.SetAttribute('Include', 'NewUserControl.axaml.fs')
        $doc.Project.ItemGroup[0].PrependChild($item)
        $item = $doc.CreateElement('Compile')
        $item.SetAttribute('Include', 'NewWindow.axaml.fs')
        $doc.Project.ItemGroup[0].PrependChild($item)
        $doc.Save($fsprojPath)
    }

    # Build
    Exec { dotnet build $outDir/$lang/$folderName -bl:$bl }
}

function Create-And-Build {
    param (
        [Parameter(Position=0,Mandatory=1)][string]$template,
        [Parameter(Position=1,Mandatory=1)][string]$name,
        [Parameter(Position=2,Mandatory=1)][string]$lang,
        [Parameter(Position=3,Mandatory=1)][string]$parameterName,
        [Parameter(Position=4,Mandatory=1)][string]$value,
        [Parameter(Position=5,Mandatory=0)][string]$bl
    )
    
    $folderName = $name + $parameterName + $value
    
    # Remove dots and - from folderName because in sln it will cause errors when building project
    $folderName = $folderName -replace "[.-]"
    
    # Create the project
    Exec { dotnet new $template -o output/$lang/$folderName -$parameterName $value -lang $lang }

    # Build
    Exec { dotnet build output/$lang/$folderName -bl:$bl }
}

if (Test-Path "output") {
    Remove-Item -Recurse output
}

$binlog = [IO.Path]::GetFullPath([IO.Path]::Combine($pwd, "..", "binlog", "test.binlog"))

Test-Template "avalonia.app" "AvaloniaApp" "C#" "f" "net6.0" $binlog
Test-Template "avalonia.app" "AvaloniaApp" "C#" "f" "net7.0" $binlog
Test-Template "avalonia.app" "AvaloniaApp" "C#" "av" "0.10.18" $binlog
Test-Template "avalonia.app" "AvaloniaApp" "C#" "av" "11.0.0-preview4" $binlog

# Build the project only twice with all item templates,once with .net6.0 tfm and once with .net7.0 tfm for C# and F#
Create-And-Build "avalonia.mvvm" "AvaloniaMvvm" "C#" "f" "net6.0" $binlog
Create-And-Build "avalonia.mvvm" "AvaloniaMvvm" "C#" "f" "net7.0" $binlog
Test-Template "avalonia.mvvm" "AvaloniaMvvm" "C#" "av" "0.10.18" $binlog
Test-Template "avalonia.mvvm" "AvaloniaMvvm" "C#" "av" "11.0.0-preview4" $binlog
Test-Template "avalonia.mvvm" "AvaloniaMvvm" "C#" "m" "ReactiveUI" $binlog
Test-Template "avalonia.mvvm" "AvaloniaMvvm" "C#" "m" "CommunityToolkit" $binlog

Test-Template "avalonia.xplat" "AvaloniaXplat" "C#" "f" "net7.0" $binlog

Test-Template "avalonia.app" "AvaloniaApp" "F#" "f" "net6.0" $binlog
Test-Template "avalonia.app" "AvaloniaApp" "F#" "f" "net7.0" $binlog
Test-Template "avalonia.app" "AvaloniaApp" "F#" "av" "0.10.18" $binlog
Test-Template "avalonia.app" "AvaloniaApp" "F#" "av" "11.0.0-preview4" $binlog

Create-And-Build "avalonia.mvvm" "AvaloniaMvvm" "F#" "f" "net6.0" $binlog
Create-And-Build "avalonia.mvvm" "AvaloniaMvvm" "F#" "f" "net7.0" $binlog
Test-Template "avalonia.mvvm" "AvaloniaMvvm" "F#" "av" "0.10.18" $binlog
Test-Template "avalonia.mvvm" "AvaloniaMvvm" "F#" "av" "11.0.0-preview4" $binlog

Test-Template "avalonia.xplat" "AvaloniaXplat" "F#" "f" "net7.0" $binlog
