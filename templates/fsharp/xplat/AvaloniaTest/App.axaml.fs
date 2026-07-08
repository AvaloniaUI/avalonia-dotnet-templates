namespace AvaloniaTest

open Avalonia
open Avalonia.Controls.ApplicationLifetimes
#if (CommunityToolkitChosen)
open Avalonia.Data.Core
open Avalonia.Data.Core.Plugins
#endif
open Avalonia.Markup.Xaml
open AvaloniaTest.ViewModels
open AvaloniaTest.Views

type App() =
    inherit Application()

    override this.Initialize() =
            AvaloniaXamlLoader.Load(this)
//-:cnd:noEmit
#if DEBUG
            this.AttachDeveloperTools() |> ignore
#endif
//+:cnd:noEmit

    override this.OnFrameworkInitializationCompleted() =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime as desktopLifetime ->
            desktopLifetime.MainWindow <- MainWindow(DataContext = MainViewModel())
        | :? IActivityApplicationLifetime as singleViewFactoryApplicationLifetime ->
            singleViewFactoryApplicationLifetime.MainViewFactory <- fun () -> MainView(DataContext = MainViewModel())
        | :? ISingleViewApplicationLifetime as singleViewLifetime ->
            singleViewLifetime.MainView <- MainView(DataContext = MainViewModel())
        | _ -> ()

        base.OnFrameworkInitializationCompleted()
