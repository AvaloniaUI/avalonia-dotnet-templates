#if (!ReactiveUIToolkitChosen)
using CommunityToolkit.Mvvm.ComponentModel;
#endif

namespace AvaloniaAppTemplate.ViewModels;

#if (!ReactiveUIToolkitChosen)
public class MainWindowViewModel : ObservableObject
#else
public class MainWindowViewModel : ViewModelBase
#endif
{
    public string Greeting => "Welcome to Avalonia!";
}
