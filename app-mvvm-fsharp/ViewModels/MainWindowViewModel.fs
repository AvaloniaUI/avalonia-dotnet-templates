namespace AvaloniaAppTemplate.ViewModels

open System
open System.Collections.Generic
open System.Text

type MainWindowViewModel () =
    inherit ViewModelBase ()

    member __.Greeting with get() = "Hello World!"
