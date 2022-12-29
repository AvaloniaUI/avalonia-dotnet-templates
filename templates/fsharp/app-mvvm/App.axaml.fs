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

#if (CommunityToolkitChosen)
        // Line below is needed to remove Avalonia data validation.
        // Without this line you will get duplicate validations from both Avalonia and CT
        ExpressionObserver.DataValidators.RemoveAll(fun x -> x :? DataAnnotationsValidationPlugin) |> ignore
#endif

        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime as desktop ->
             desktop.MainWindow <- MainWindow(DataContext = MainWindowViewModel())
        | _ -> ()

        base.OnFrameworkInitializationCompleted()
