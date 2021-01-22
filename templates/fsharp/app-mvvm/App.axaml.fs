namespace AvaloniaAppTemplate

open Avalonia
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.Markup.Xaml
open AvaloniaAppTemplate.ViewModels
open AvaloniaAppTemplate.Views

type App() as self =
    inherit Application()

    do AvaloniaXamlLoader.Load self

    override self.OnFrameworkInitializationCompleted() =
        match self.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime as desktop ->
             desktop.MainWindow <- new MainWindow(DataContext=MainWindowViewModel())
        | _ -> ()

        base.OnFrameworkInitializationCompleted()
