namespace AvaloniaTest.Android

open Android.App
open Android.Content.PM
open Avalonia
open Avalonia.Android
#if (ReactiveUIToolkitChosen)
open ReactiveUI.Avalonia
#endif
open AvaloniaTest

    [<Application>]
type Application(javaReference: nativeint, transfer: Android.Runtime.JniHandleOwnership) = 
    inherit AvaloniaAndroidApplication<App>(javaReference, transfer)

     override _.CustomizeAppBuilder(builder) =
        base.CustomizeAppBuilder(builder)
            .WithInterFont()
#if (ReactiveUIToolkitChosen)
            .UseReactiveUI(fun _ -> ())
#endif