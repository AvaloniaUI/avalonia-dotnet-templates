namespace AvaloniaTest.Desktop
open System
open Avalonia
open AvaloniaTest

module Program =
    let BuildAvaloniaApp() =
        AppBuilder
            .Configure<App>()
            .UsePlatformDetect()


    [<EntryPoint; STAThread>]
    let main argv =
        BuildAvaloniaApp().StartWithClassicDesktopLifetime(argv) |> ignore
        0
