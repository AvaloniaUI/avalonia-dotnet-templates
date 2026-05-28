namespace AvaloniaAppTemplate.Namespace

open Avalonia
open Avalonia.Controls
open Avalonia.Markup.Xaml

type NewNavigationPage() as this =
    inherit NavigationPage()
    do this.InitializeComponent()

    member private this.InitializeComponent() =
        AvaloniaXamlLoader.Load(this)