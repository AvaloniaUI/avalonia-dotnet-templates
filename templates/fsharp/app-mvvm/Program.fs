namespace AvaloniaAppTemplate

open System
open Avalonia
#if (ReactiveUIToolkitChosen)
open Avalonia.ReactiveUI
#endif
open AvaloniaAppTemplate

module Program =

    [<CompiledName "BuildAvaloniaApp">] 
    let buildAvaloniaApp () = 
        AppBuilder
            .Configure<App>()
            .UsePlatformDetect()
            .LogToTrace(areas = Array.empty)
#if (ReactiveUIToolkitChosen)
            .UseReactiveUI()
#endif

    [<EntryPoint; STAThread>]
    let main argv =
        buildAvaloniaApp().StartWithClassicDesktopLifetime(argv)
