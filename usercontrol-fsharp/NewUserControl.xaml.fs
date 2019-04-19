namespace AvaloniaAppTemplate.Namespace

open Avalonia
open Avalonia.Controls
open Avalonia.Markup.Xaml


type NewUserControl() as this =
    inherit UserControl()

    let initializeComponent () =
        AvaloniaXamlLoader.Load this

    do
        initializeComponent ()
