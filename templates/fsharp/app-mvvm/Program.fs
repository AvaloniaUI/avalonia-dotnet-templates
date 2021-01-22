namespace AvaloniaAppTemplate

open System
open Avalonia
open Avalonia.ReactiveUI
open AvaloniaAppTemplate

module Program =

    [<CompiledName "BuildAvaloniaApp">] 
    let buildAvaloniaApp () = 
        AppBuilder
            .Configure<App>()
            .UsePlatformDetect()
            .LogToTrace(areas = Array.empty)
            .UseReactiveUI()

    [<STAThread>][<EntryPoint>]
    let main argv =
        buildAvaloniaApp().StartWithClassicDesktopLifetime(argv)
