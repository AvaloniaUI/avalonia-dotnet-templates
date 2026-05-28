namespace AvaloniaAppTemplate.Namespace

open Avalonia
open Avalonia.Controls
open Avalonia.Markup.Xaml

type NewContentPage() as this =
    inherit ContentPage()
    do this.InitializeComponent()

    member private this.InitializeComponent() =
        AvaloniaXamlLoader.Load(this)