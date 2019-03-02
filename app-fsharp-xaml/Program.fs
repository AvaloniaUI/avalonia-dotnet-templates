namespace AvaloniaAppTemplate

open Avalonia
open Avalonia.Logging.Serilog
open Avalonia.Controls
open Avalonia.Markup.Xaml

type MainWindow() as this =
    inherit Window()

    do
        AvaloniaXamlLoader.Load(this)
        
type App() =
    inherit Application()
    
    override this.Initialize () =
        let x = this.GetType()
        AvaloniaXamlLoader.Load(this)
 
module Program =

    [<EntryPoint>]
    let main argv =
        AppBuilder
            .Configure<App>()
            .UsePlatformDetect()
            .LogToDebug()
            .Start<MainWindow>()
        0