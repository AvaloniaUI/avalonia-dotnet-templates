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
        [Parameter(Position=2,Mandatory=1)][string]$lang
    )

    $outDir = [IO.Path]::GetFullPath([IO.Path]::Combine($pwd, "..", "output"))

    # Create the project
    Exec { dotnet new $template -o $outDir/$lang/$name -lang $lang }

    # Instantiate each item template in the project
    Exec { dotnet new avalonia.resource -o $outDir/$lang/$name -n NewResourceDictionary }
    Exec { dotnet new avalonia.styles -o $outDir/$lang/$name -n NewStyles }
    Exec { dotnet new avalonia.usercontrol -o $outDir/$lang/$name -n NewUserControl -lang $lang }
    Exec { dotnet new avalonia.window -o $outDir/$lang/$name -n NewWindow -lang $lang }
    If($lang -eq "F#")
    {
        $fsprojPath = [IO.Path]::Combine($outDir, $lang, $name, $name + '.fsproj')

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
    Exec { dotnet build $outDir/$lang/$name }
}

function Create-And-Build {
    param (
        [Parameter(Position=0,Mandatory=1)][string]$template,
        [Parameter(Position=1,Mandatory=1)][string]$name,
        [Parameter(Position=2,Mandatory=1)][string]$lang
    )

    # Create the project
    Exec { dotnet new $template -o output/$lang/$name -lang $lang }

    # Build
    Exec { dotnet build output/$lang/$name }
}

if (Test-Path "output") {
    Remove-Item -Recurse output
}


Test-Template "avalonia.app" "AvaloniaApp" "C#"
Create-And-Build "avalonia.mvvm" "AvaloniaMvvm" "C#"
Create-And-Build "avalonia.xplat" "AvaloniaXplat" "C#"
Test-Template "avalonia.app" "AvaloniaApp" "F#"
Create-And-Build "avalonia.mvvm" "AvaloniaMvvm" "F#"
Create-And-Build "avalonia.xplat" "AvaloniaXplat" "F#"