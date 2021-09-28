namespace AvaloniaAppTemplate

open Avalonia
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.Markup.Xaml

type App() =
    inherit Application()

    override self.Initialize() =
            AvaloniaXamlLoader.Load(self)

    override self.OnFrameworkInitializationCompleted() =
        match self.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime as desktop ->
             desktop.MainWindow <- MainWindow()
        | _ -> ()

        base.OnFrameworkInitializationCompleted()
