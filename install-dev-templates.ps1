dotnet new uninstall Avalonia.Templates
Remove-Item bin/**/*.nupkg

dotnet pack
# Search Directory
$directoryPath = ".\bin\Release"

$latestNupkgFile = Get-ChildItem -Path $directoryPath -Recurse -Filter "*.nupkg" |
                   Where-Object { -not $_.PSIsContainer } |
                   Sort-Object LastWriteTime -Descending |
                   Select-Object -First 1

if ($latestNupkgFile) {
  $latestNupkgPath = $latestNupkgFile.FullName
  dotnet new install $latestNupkgPath
}