namespace AvaloniaAppTemplate.Namespace

open Avalonia
open Avalonia.Controls
open Avalonia.Markup.Xaml

type NewTabbedPage() as this =
    inherit TabbedPage()
    do this.InitializeComponent()

    member private this.InitializeComponent() =
        AvaloniaXamlLoader.Load(this)