namespace AvaloniaAppTemplate.ViewModels

#if (CommunityToolkitChosen)
open CommunityToolkit.Mvvm.ComponentModel
#elif (ReactiveUIToolkitChosen)
open ReactiveUI
#endif

type ViewModelBase() =
#if (CommunityToolkitChosen)
    inherit ObservableObject()
#elif (ReactiveUIToolkitChosen)
    inherit ReactiveObject()
#endif
