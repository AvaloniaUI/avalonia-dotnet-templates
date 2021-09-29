namespace AvaloniaAppTemplate

open Avalonia
open Avalonia.Controls
open Avalonia.Markup.Xaml

type MainWindow () as self = 
    inherit Window ()

    do self.InitializeComponent()

    member private this.InitializeComponent() =
//-:cnd:noEmit
#if DEBUG
        self.AttachDevTools()
#endif
//+:cnd:noEmit
        AvaloniaXamlLoader.Load(this)
