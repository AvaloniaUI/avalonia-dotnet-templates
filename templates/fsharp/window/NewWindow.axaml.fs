namespace AvaloniaAppTemplate.Namespace

open Avalonia
open Avalonia.Controls
open Avalonia.Markup.Xaml

type NewWindow () as self = 
    inherit Window ()

    do self.InitializeComponent()

    member private this.InitializeComponent() =
//-:cnd:noEmit
#if DEBUG
        self.AttachDevTools()
#endif
//+:cnd:noEmit
        AvaloniaXamlLoader.Load(this)
