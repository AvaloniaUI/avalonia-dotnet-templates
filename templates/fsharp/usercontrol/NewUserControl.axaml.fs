namespace AvaloniaAppTemplate.Namespace

open Avalonia
open Avalonia.Controls
open Avalonia.Markup.Xaml

type NewUserControl () as self = 
    inherit UserControl ()

    do AvaloniaXamlLoader.Load self
