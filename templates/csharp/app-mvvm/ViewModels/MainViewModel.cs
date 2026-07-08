#if (CommunityToolkitChosen)
using CommunityToolkit.Mvvm.ComponentModel;
#elif (ReactiveUIToolkitChosen)
using ReactiveUI;
#endif

namespace AvaloniaAppTemplate.ViewModels;

#if (CommunityToolkitChosen)
public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
#if (UsePartialProperties)
    public partial string Greeting { get; set; } = "Welcome to Avalonia!";
#else
    private string _greeting = "Welcome to Avalonia!";
#endif
}
#elif (ReactiveUIToolkitChosen)
public class MainViewModel : ViewModelBase
{
    private string _greeting = "Welcome to Avalonia!";

    public string Greeting
    {
        get => _greeting;
        set => this.RaiseAndSetIfChanged(ref _greeting, value);
    }
}
#endif
