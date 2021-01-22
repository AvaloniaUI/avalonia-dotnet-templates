dotnet new avalonia.app -o vstemplate/AvaloniaApplicationTemplate -n SAFEPROJECTNAME
dotnet new avalonia.mvvm -o vstemplate/AvaloniaMvvmApplicationTemplate -n SAFEPROJECTNAME
dotnet new avalonia.usercontrol -o vstemplate/AvaloniaUserControlTemplate -na ROOTNAMESPACE -n SAFEITEMROOTNAME
dotnet new avalonia.window -o vstemplate/AvaloniaWindowTemplate -na ROOTNAMESPACE -n SAFEITEMROOTNAME

# Rename filenames:
# SAFEPROJECTNAME.csproj to ProjectTemplate.csproj
Get-ChildItem -Path vstemplate -File -Filter SAFEPROJECTNAME.csproj -Recurse | `
  ForEach-Object { Rename-Item -Path $_.PSPath -NewName ProjectTemplate.csproj }

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