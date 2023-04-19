namespace AvaloniaAppTemplate

open System
open Avalonia
#if (!AvaloniaStableChosen)
open Avalonia.Fonts.Inter
#endif

module Program =

    [<CompiledName "BuildAvaloniaApp">] 
    let buildAvaloniaApp () = 
        AppBuilder
            .Configure<App>()
            .UsePlatformDetect()
#if (!AvaloniaStableChosen)
            .WithInterFont()
#endif
            .LogToTrace(areas = Array.empty)

    [<EntryPoint; STAThread>]
    let main argv =
        buildAvaloniaApp().StartWithClassicDesktopLifetime(argv)
