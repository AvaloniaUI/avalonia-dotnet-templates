namespace AvaloniaAppTemplate.ViewModels

#if (CommunityToolkitChosen)
open CommunityToolkit.Mvvm.ComponentModel;
#endif

type MainWindowViewModel() =
#if (CommunityToolkitChosen)
    inherit ObservableObject()
#else
    inherit ViewModelBase()
#endif

    member this.Greeting = "Welcome to Avalonia!"
