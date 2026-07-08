namespace AvaloniaAppTemplate.ViewModels

#if (ReactiveUIToolkitChosen)
open ReactiveUI
#endif

type MainViewModel() =
    inherit ViewModelBase()

    let mutable greeting = "Welcome to Avalonia!"

    member this.Greeting
        with get () = greeting
#if (CommunityToolkitChosen)
        and set value = this.SetProperty(&greeting, value) |> ignore
#elif (ReactiveUIToolkitChosen)
        and set value = this.RaiseAndSetIfChanged(&greeting, value) |> ignore
#endif
