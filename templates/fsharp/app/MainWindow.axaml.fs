namespace AvaloniaAppTemplate

open Avalonia
open Avalonia.Controls
open Avalonia.Markup.Xaml

type MainWindow () as self = 
    inherit Window ()

    do self.InitializeComponent()

    member private this.InitializeComponent() =
 #if DEBUG
        self.AttachDevTools()
 #endif
        AvaloniaXamlLoader.Load(this)
