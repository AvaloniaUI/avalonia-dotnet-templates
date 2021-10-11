dotnet new avalonia.app -o vstemplate/AvaloniaApplicationTemplate -n SAFEPROJECTNAME
dotnet new avalonia.mvvm -o vstemplate/AvaloniaMvvmApplicationTemplate -n SAFEPROJECTNAME
dotnet new avalonia.usercontrol -o vstemplate/AvaloniaUserControlTemplate -na ROOTNAMESPACE -n SAFEITEMROOTNAME
dotnet new avalonia.window -o vstemplate/AvaloniaWindowTemplate -na ROOTNAMESPACE -n SAFEITEMROOTNAME
dotnet new avalonia.app -o vstemplate/FsAvaloniaApplicationTemplate -n SAFEPROJECTNAME -lang F#
dotnet new avalonia.mvvm -o vstemplate/FsAvaloniaMvvmApplicationTemplate -n SAFEPROJECTNAME -lang F#
dotnet new avalonia.usercontrol -o vstemplate/FsAvaloniaUserControlTemplate -na ROOTNAMESPACE -n SAFEITEMROOTNAME -lang F#
dotnet new avalonia.window -o vstemplate/FsAvaloniaWindowTemplate -na ROOTNAMESPACE -n SAFEITEMROOTNAME -lang F#

# Rename filenames:
# SAFEPROJECTNAME.csproj to ProjectTemplate.csproj
Get-ChildItem -Path vstemplate -File -Filter SAFEPROJECTNAME.csproj -Recurse | `
  ForEach-Object { Rename-Item -Path $_.PSPath -NewName ProjectTemplate.csproj }
  
# Rename filenames:
# SAFEPROJECTNAME.fsproj to ProjectTemplate.fsproj
Get-ChildItem -Path vstemplate -File -Filter SAFEPROJECTNAME.fsproj -Recurse | `
  ForEach-Object { Rename-Item -Path $_.PSPath -NewName ProjectTemplate.fsproj }

# Rename file contents:
# SAFEPROJECTNAME to $safeprojectname$
# ROOTNAMESPACE to $rootnamespace$
# SAFEITEMROOTNAME to $safeitemrootname$
Get-ChildItem -Path vstemplate -File -Recurse -Exclude *.ico | `
  ForEach-Object { 
    (Get-Content $_.PSPath) | ForEach-Object { `
      $_ -replace("SAFEPROJECTNAME", '$safeprojectname$') `
         -replace("ROOTNAMESPACE", '$rootnamespace$') `
         -replace("SAFEITEMROOTNAME", '$safeitemrootname$') `
    }  | Set-Content $_.PSPath
  }

# Rename specific files
mv vstemplate/AvaloniaUserControlTemplate\SAFEITEMROOTNAME.axaml vstemplate/AvaloniaUserControlTemplate\UserControl.axaml
mv vstemplate/AvaloniaUserControlTemplate\SAFEITEMROOTNAME.axaml.cs vstemplate/AvaloniaUserControlTemplate\UserControl.axaml.cs
mv vstemplate/AvaloniaWindowTemplate\SAFEITEMROOTNAME.axaml vstemplate/AvaloniaWindowTemplate\Window.axaml
mv vstemplate/AvaloniaWindowTemplate\SAFEITEMROOTNAME.axaml.cs vstemplate/AvaloniaWindowTemplate\Window.axaml.cs
mv vstemplate/FsAvaloniaUserControlTemplate\SAFEITEMROOTNAME.axaml vstemplate/FsAvaloniaUserControlTemplate\UserControl.axaml
mv vstemplate/FsAvaloniaUserControlTemplate\SAFEITEMROOTNAME.axaml.fs vstemplate/FsAvaloniaUserControlTemplate\UserControl.axaml.fs
mv vstemplate/FsAvaloniaWindowTemplate\SAFEITEMROOTNAME.axaml vstemplate/FsAvaloniaWindowTemplate\Window.axaml
mv vstemplate/FsAvaloniaWindowTemplate\SAFEITEMROOTNAME.axaml.fs vstemplate/FsAvaloniaWindowTemplate\Window.axaml.fs