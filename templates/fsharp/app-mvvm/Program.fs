namespace AvaloniaAppTemplate

open System
open Avalonia
#if (ReactiveUIToolkitChosen)
open ReactiveUI.Avalonia
#endif

module Program =

    [<CompiledName "BuildAvaloniaApp">] 
    let buildAvaloniaApp () = 
        AppBuilder
            .Configure<App>()
            .WithInterFont()
//-:cnd:noEmit
#if DEBUG
            .WithDeveloperTools()
#endif
//+:cnd:noEmit
            .LogToTrace(areas = Array.empty)
#if (ReactiveUIToolkitChosen)
            .UseReactiveUI(fun _ -> ())
#endif

    [<EntryPoint; STAThread>]
    let main argv =
        buildAvaloniaApp().StartWithClassicDesktopLifetime(argv)
