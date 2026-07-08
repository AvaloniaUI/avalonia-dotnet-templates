#if (CommunityToolkitChosen)
using CommunityToolkit.Mvvm.ComponentModel;
#elif (ReactiveUIToolkitChosen)
using ReactiveUI;
#endif

namespace AvaloniaTest.ViewModels;

#if (CommunityToolkitChosen)
public partial class HomeViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial string Greeting { get; set; } = "Welcome to Avalonia!";
}
#elif (ReactiveUIToolkitChosen)
public class HomeViewModel : ViewModelBase
{
    private string _greeting = "Welcome to Avalonia!";

    public string Greeting
    {
        get => _greeting;
        set => this.RaiseAndSetIfChanged(ref _greeting, value);
    }
}
#endif
