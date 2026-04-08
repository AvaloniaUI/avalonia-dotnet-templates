#if (CommunityToolkitChosen)
using CommunityToolkit.Mvvm.ComponentModel;
#endif

namespace AvaloniaTest.ViewModels;

#if (CommunityToolkitChosen)
public partial class HomeViewModel : ViewModelBase
#else
public class HomeViewModel : ViewModelBase
#endif
{
#if (CommunityToolkitChosen)
    [ObservableProperty]
    private string _greeting = "Welcome to Avalonia!";
#else
    public string Greeting { get; } = "Welcome to Avalonia!";
#endif
}
