#if (CommunityToolkitChosen)
using CommunityToolkit.Mvvm.ComponentModel;
#endif

namespace AvaloniaAppTemplate.ViewModels;

#if (CommunityToolkitChosen)
public class MainWindowViewModel : ObservableObject
#else
public class MainWindowViewModel : ViewModelBase
#endif
{
    public string Greeting => "Welcome to Avalonia!";
}
