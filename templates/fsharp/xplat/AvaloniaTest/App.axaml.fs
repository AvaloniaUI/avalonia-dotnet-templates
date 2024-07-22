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

    override this.OnFrameworkInitializationCompleted() =

#if (CommunityToolkitChosen)
        // Line below is needed to remove Avalonia data validation.
        // Without this line you will get duplicate validations from both Avalonia and CT
        BindingPlugins.DataValidators.RemoveAt(0)
#endif

        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime as desktopLifetime ->
            desktopLifetime.MainWindow <- MainWindow(DataContext = MainViewModel())
        | :? ISingleViewApplicationLifetime as singleViewLifetime ->
            singleViewLifetime.MainView <- MainView(DataContext = MainViewModel())
        | _ -> ()

        base.OnFrameworkInitializationCompleted()
