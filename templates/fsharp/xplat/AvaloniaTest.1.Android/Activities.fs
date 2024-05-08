namespace AvaloniaTest.Android

open Android.App
open Android.Content.PM
open Avalonia
open Avalonia.ReactiveUI
open Avalonia.Android
open AvaloniaTest._1

[<Activity(
    Label = "AvaloniaTest._1.Android",
    Theme = "@style/MyTheme.NoActionBar",
    Icon = "@drawable/icon",
    MainLauncher = true,
    ConfigurationChanges = (ConfigChanges.Orientation ||| ConfigChanges.ScreenSize ||| ConfigChanges.UiMode))>]
type MainActivity() =
    inherit AvaloniaMainActivity<App>()

    override _.CustomizeAppBuilder(builder) =
        base.CustomizeAppBuilder(builder)
            .WithInterFont()
            .UseReactiveUI()
