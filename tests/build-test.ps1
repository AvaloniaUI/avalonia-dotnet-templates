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
        [Parameter(Position=1,Mandatory=1)][string]$name
    )

    # Create the project
    Exec { dotnet new $template -o output/$name }

    # Instantiate each item template in the project
    Exec { dotnet new avalonia.resource -o output/$name -n NewResourceDictionary }
    Exec { dotnet new avalonia.styles -o output/$name -n NewStyles }
    Exec { dotnet new avalonia.usercontrol -o output/$name -na $name -n NewUserControl }
    Exec { dotnet new avalonia.window -o output/$name -na $name -n NewWindow }

    # Build
    Exec { dotnet build output/$name }
}

Test-Template "avalonia.app" "AvaloniaApp"
Test-Template "avalonia.mvvm" "AvaloniaMvvm"