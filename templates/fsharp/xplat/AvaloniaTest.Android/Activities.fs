namespace AvaloniaTest.Android
open Android.App
open Android.Content
open Android.Content.PM
type Application = Android.App.Application

open Avalonia.Android
open AvaloniaTest

[<Activity(
    Label = "AvaloniaTest.Android",
    Theme = "@style/MyTheme.NoActionBar",
    Icon = "@drawable/icon",
    LaunchMode = LaunchMode.SingleInstance,
    ConfigurationChanges = (ConfigChanges.Orientation ||| ConfigChanges.ScreenSize))>]
type MainActivity() =
    inherit AvaloniaActivity<App>()

    override _.CustomizeAppBuilder(builder) =
        base.CustomizeAppBuilder(builder);

[<Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)>]
type SplashActivity() =
    inherit Activity()

    override x.OnResume() =
        base.OnResume()
        x.StartActivity(new Intent(Application.Context, typeof<MainActivity>))
