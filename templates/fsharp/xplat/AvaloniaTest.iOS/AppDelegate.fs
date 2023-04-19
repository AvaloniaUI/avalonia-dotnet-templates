namespace AvaloniaTest.iOS
open Foundation
open Avalonia.iOS
open Avalonia.Fonts.Inter
open Avalonia.ReactiveUI

// The UIApplicationDelegate for the application. This class is responsible for launching the 
// User Interface of the application, as well as listening (and optionally responding) to 
// application events from iOS.
type [<Register("AppDelegate")>] AppDelegate() =
    inherit AvaloniaAppDelegate<AvaloniaTest.App>()

    override _.CustomizeAppBuilder(builder) =
        base.CustomizeAppBuilder(builder)
            .WithInterFont()
            .UseReactiveUI()