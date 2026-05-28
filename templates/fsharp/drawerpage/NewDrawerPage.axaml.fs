namespace AvaloniaAppTemplate.Namespace

open Avalonia
open Avalonia.Controls
open Avalonia.Markup.Xaml

type NewDrawerPage() as this =
    inherit DrawerPage()
    do this.InitializeComponent()

    member private this.InitializeComponent() =
        AvaloniaXamlLoader.Load(this)