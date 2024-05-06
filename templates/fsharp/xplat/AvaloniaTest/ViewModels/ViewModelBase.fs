namespace AvaloniaTest.ViewModels

#if (CommunityToolkitChosen)
open CommunityToolkit.Mvvm.ComponentModel
#elif (ReactiveUIToolkitChosen)
open ReactiveUI
#endif

[<AbstractClass>]
type ViewModelBase() =
#if (CommunityToolkitChosen)
    inherit ObservableObject()
#elif (ReactiveUIToolkitChosen)
    inherit ReactiveObject()
#endif
