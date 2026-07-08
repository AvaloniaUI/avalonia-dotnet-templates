namespace AvaloniaTest.Desktop
open System
open Avalonia
#if (ReactiveUIToolkitChosen)
open ReactiveUI.Avalonia
#endif
open AvaloniaTest

module Program =

    [<CompiledName "BuildAvaloniaApp">] 
    let buildAvaloniaApp () = 
        AppBuilder
            .Configure<App>()
            .UsePlatformDetect()
//-:cnd:noEmit
#if DEBUG
            .WithDeveloperTools()
#endif
//+:cnd:noEmit
            .WithInterFont()
            .LogToTrace(areas = Array.empty)
#if (ReactiveUIToolkitChosen)
            .UseReactiveUI(fun _ -> ())
#endif

    [<EntryPoint; STAThread>]
    let main argv =
        buildAvaloniaApp().StartWithClassicDesktopLifetime(argv)
