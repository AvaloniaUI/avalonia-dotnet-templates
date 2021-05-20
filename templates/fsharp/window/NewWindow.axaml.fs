namespace AvaloniaAppTemplate.Namespace

open Avalonia
open Avalonia.Controls
open Avalonia.Markup.Xaml

type NewWindow () as self = 
    inherit Window ()
//-:cnd:noEmit
#if DEBUG
    do self.AttachDevTools()
#endif
//+:cnd:noEmit
    do AvaloniaXamlLoader.Load self
