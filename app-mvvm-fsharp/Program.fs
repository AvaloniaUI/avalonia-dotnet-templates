﻿namespace AvaloniaAppTemplate

open System
open Avalonia
open Avalonia.Logging.Serilog
open AvaloniaAppTemplate.ViewModels
open AvaloniaAppTemplate.Views

module Program =

    // Avalonia configuration, don't remove; also used by visual designer.
    [<CompiledName "BuildAvaloniaApp">]
    let buildAvaloniaApp() =
        AppBuilder
            .Configure<App>()
            .UsePlatformDetect()
            .LogToDebug()
            .UseReactiveUI()

    // Your application's entry point.
    [<CompiledName "AppMain">]
    let appMain (app: Application) (args: string[]) =
        let window = MainWindow (DataContext = MainWindowViewModel ())
        app.Run(window)

    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [<EntryPoint>]
    [<CompiledName "Main">]
    let main(args: string[]) =
        buildAvaloniaApp().Start(appMain, args)
        0
