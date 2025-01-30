#if (CommunityToolkitChosen)
using CommunityToolkit.Mvvm.ComponentModel;
#endif

namespace AvaloniaTest._1.ViewModels;

#if (CommunityToolkitChosen)
public partial class MainViewModel : ViewModelBase
#else
public class MainViewModel : ViewModelBase
#endif
{
#if (CommunityToolkitChosen)
    [ObservableProperty]
    private string _greeting = "Welcome to Avalonia!";
#else
    public string Greeting { get; } = "Welcome to Avalonia!";
#endif
}
