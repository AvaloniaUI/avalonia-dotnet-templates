namespace AvaloniaAppTemplate.Namespace

open Avalonia
open Avalonia.Controls
open Avalonia.Markup.Xaml

type NewWindow () as this = 
    inherit Window ()

    do this.InitializeComponent()

    member private this.InitializeComponent() =
//-:cnd:noEmit
#if DEBUG
        this.AttachDevTools()
#endif
//+:cnd:noEmit
        AvaloniaXamlLoader.Load(this)
