#if (CommunityToolkitChosen)
using CommunityToolkit.Mvvm.ComponentModel;
#elif (ReactiveUIToolkitChosen)
using ReactiveUI;
#endif

namespace AvaloniaTest._1.ViewModels;

#if (CommunityToolkitChosen)
public abstract class ViewModelBase : ObservableObject
#elif (ReactiveUIToolkitChosen)
public abstract class ViewModelBase : ReactiveObject
#endif
{
}
