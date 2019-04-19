namespace AvaloniaAppTemplate.Views

open Avalonia
open Avalonia.Markup.Xaml
open Avalonia.Controls

type MainWindow() as this =
    inherit Window()

    let initializeComponent () =
        AvaloniaXamlLoader.Load this

    do
        initializeComponent ()
#if DEBUG
        this.AttachDevTools ()
#endif

