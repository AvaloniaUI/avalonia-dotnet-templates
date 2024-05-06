#if (CommunityToolkitChosen)
using CommunityToolkit.Mvvm.ComponentModel;
#endif

namespace AvaloniaTest.ViewModels;

#if (CommunityToolkitChosen)
public partial class MainWindowViewModel : ViewModelBase
#else
public class MainWindowViewModel : ViewModelBase
#endif
{
#if (CommunityToolkitChosen)
    [ObservableProperty]
    private string _greeting = "Welcome to Avalonia!";
#else
#pragma warning disable CA1822 // Mark members as static
    public string Greeting => "Welcome to Avalonia!";
#pragma warning restore CA1822 // Mark members as static
#endif
}
