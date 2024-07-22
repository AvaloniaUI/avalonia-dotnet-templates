#if (CommunityToolkitChosen)
using CommunityToolkit.Mvvm.ComponentModel;
#elif (ReactiveUIToolkitChosen)
using ReactiveUI;
#endif

namespace AvaloniaTest.ViewModels;

#if (CommunityToolkitChosen)
public abstract class ViewModelBase : ObservableObject
#elif (ReactiveUIToolkitChosen)
public abstract class ViewModelBase : ReactiveObject
#endif
{
}
