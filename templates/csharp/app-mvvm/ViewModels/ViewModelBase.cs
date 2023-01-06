#if (CommunityToolkitChosen)
using CommunityToolkit.Mvvm.ComponentModel;
#elif (ReactiveUIToolkitChosen)
using ReactiveUI;
#endif

namespace AvaloniaAppTemplate.ViewModels;

#if (CommunityToolkitChosen)
public class ViewModelBase : ObservableObject
#elif (ReactiveUIToolkitChosen)
public class ViewModelBase : ReactiveObject
#endif
{
}
