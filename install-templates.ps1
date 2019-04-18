$hasDotnet = Get-Command "dotnet" -ErrorAction SilentlyContinue

if($hasDotnet) {
    $input = (Read-Host "Do you want to Install .NET Core CLI templates for Avalonia? [Y]es / [N]o?").ToLower()
    if($input -eq "y" -or $input -eq "yes") {
        Write-Progress -Activity "Install Avalonia Templates" -PercentComplete 0 -Status "Uninstalling old Avalonia templates..."
        dotnet new -u (Get-Location) | Out-Null
        Write-Progress -Activity "Install Avalonia Templates" -PercentComplete 50 -Status "Installing new Avalonia templates..."
        dotnet new -i .              | Out-Null
        Write-Progress -Activity "Install Avalonia Templates" -Completed
        Write-Host "Installing Finished. Use ``dotnet new`` to use templates." -ForegroundColor Green
    }
    else {
        Write-Host "Operation cancelled by user." -ForegroundColor DarkGray
    }
}
else {
    Write-Host ".NET Core CLI (dotnet) is not installed or is not in the path." -ForegroundColor Red
}