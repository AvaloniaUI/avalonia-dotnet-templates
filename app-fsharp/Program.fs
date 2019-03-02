open Avalonia
open Avalonia.Logging.Serilog
open Avalonia.Controls
open Avalonia.Styling
open Avalonia.Markup.Xaml.Styling
open System
open Avalonia.Layout

[<AutoOpen>]
module AvaloniaExtensions =

    type Styles with
        member this.Load (source: string) = 
            let style = new StyleInclude(null)
            style.Source <- new Uri(source)
            this.Add(style)

type MainWindow() =
    inherit Window()

    do
        base.Title <- "Avalonia"
        base.Height <- 600.0
        base.Width <- 800.0

        base.Content <- TextBlock (
            Text = "Hello World",
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center
            )

type App() =
    inherit Application()
    
    override this.Initialize () =
        this.Styles.Load "resm:Avalonia.Themes.Default.DefaultTheme.xaml?assembly=Avalonia.Themes.Default"
        this.Styles.Load "resm:Avalonia.Themes.Default.Accents.BaseLight.xaml?assembly=Avalonia.Themes.Default"

[<EntryPoint>]
let main argv =
    AppBuilder
        .Configure<App>()
        .UsePlatformDetect()
        .LogToDebug()
        .Start<MainWindow>()
    0