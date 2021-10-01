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

    # Create the project
    Exec { dotnet new $template -o output/$lang/$name -lang $lang }

    # Instantiate each item template in the project
    Exec { dotnet new avalonia.resource -o output/$lang/$name -n NewResourceDictionary }
    Exec { dotnet new avalonia.styles -o output/$lang/$name -n NewStyles }
    Exec { dotnet new avalonia.usercontrol -o output/$lang/$name -na $name -n NewUserControl -lang $lang }
    If($lang -eq "F#")
    {
        [xml]$doc = Get-Content ./output/$lang/$name.fsproj
        $item = $doc.CreateElement('Compile')
        $item.SetAttribute('Include', 'NewUserControl.axaml.fs')

        $doc.Project.ItemGroup.AppendChild($item)
        $doc.Save([IO.Path]::GetFullPath("./output/$lang/$name.fsproj"))
    }
   # Exec { dotnet new avalonia.window -o output/$lang/$name -na $name -n NewWindow -lang $lang }

    # Build
    Exec { dotnet build -warnaserror output/$lang/$name }
}

if (Test-Path "output") {
    Remove-Item -Recurse output
}

Test-Template "avalonia.app" "AvaloniaApp" "C#"
Test-Template "avalonia.mvvm" "AvaloniaMvvm" "C#"
Test-Template "avalonia.app" "AvaloniaApp" "F#"
Test-Template "avalonia.mvvm" "AvaloniaMvvm" "F#"