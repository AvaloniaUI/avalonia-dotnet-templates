namespace AvaloniaTest.iOS
open Foundation
open Avalonia
open Avalonia.iOS
#if (ReactiveUIToolkitChosen)
open Avalonia.ReactiveUI
#endif

// The UIApplicationDelegate for the application. This class is responsible for launching the 
// User Interface of the application, as well as listening (and optionally responding) to 
// application events from iOS.
type [<Register("AppDelegate")>] AppDelegate() =
    inherit AvaloniaAppDelegate<AvaloniaTest.App>()

    override _.CustomizeAppBuilder(builder) =
        base.CustomizeAppBuilder(builder)
            .WithInterFont()
#if (ReactiveUIToolkitChosen)
            .UseReactiveUI()
#endif