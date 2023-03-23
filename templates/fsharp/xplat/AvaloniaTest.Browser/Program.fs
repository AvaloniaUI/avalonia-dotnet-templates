open System.Runtime.Versioning
open System.Threading.Tasks
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
            .StartBrowserAppAsync("out")
            .Result
        0
