namespace AvaloniaAppTemplate.Namespace

open Avalonia
open Avalonia.Controls
open Avalonia.Markup.Xaml

type NewWindow() as this =
    inherit Window()

    let initializeComponent () =
        AvaloniaXamlLoader.Load this

    do
        initializeComponent()
#if DEBUG
        this.AttachDevTools()
#endif