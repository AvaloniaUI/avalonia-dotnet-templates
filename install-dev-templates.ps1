dotnet new uninstall Avalonia.Templates
Remove-Item bin/**/*.nupkg
$result = dotnet pack | select-string "Successfully created package '(.*)'" -AllMatches
$package = $result.Matches.Groups[1]
dotnet new install $package