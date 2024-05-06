open System.Runtime.Versioning
open Avalonia
open Avalonia.Browser
#if (ReactiveUIToolkitChosen)
open Avalonia.ReactiveUI
#endif
open AvaloniaTest

module Program =
    [<assembly: SupportedOSPlatform("browser")>]
    do ()

    [<CompiledName "BuildAvaloniaApp">] 
    let buildAvaloniaApp () = 
        AppBuilder
            .Configure<App>()

    [<EntryPoint>]
    let main argv =
        task {
            do! (buildAvaloniaApp()
            .WithInterFont()
#if (ReactiveUIToolkitChosen)
            .UseReactiveUI()
#endif
            .StartBrowserAppAsync("out"))
        }
        |> ignore
        0