namespace AvaloniaAppTemplate

open Avalonia
open Avalonia.Controls.ApplicationLifetimes
#if (CommunityToolkitChosen)
open Avalonia.Data.Core
open Avalonia.Data.Core.Plugins
#endif
open Avalonia.Markup.Xaml
open AvaloniaAppTemplate.ViewModels
open AvaloniaAppTemplate.Views

type App() =
    inherit Application()

    override this.Initialize() =
            AvaloniaXamlLoader.Load(this)

    override this.OnFrameworkInitializationCompleted() =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime as desktop ->
             desktop.MainWindow <- MainWindow(DataContext = MainViewModel())
        | _ -> ()

        base.OnFrameworkInitializationCompleted()
