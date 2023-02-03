open System.Runtime.Versioning
open Avalonia
open Avalonia.Browser
open Avalonia.ReactiveUI

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
        buildAvaloniaApp()
            .UseReactiveUI()
            .SetupBrowserApp("out")
            |> ignore
        0
