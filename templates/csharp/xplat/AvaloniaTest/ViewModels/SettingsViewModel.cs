#if (CommunityToolkitChosen)
using CommunityToolkit.Mvvm.ComponentModel;
#elif (ReactiveUIToolkitChosen)
using ReactiveUI;
#endif

namespace AvaloniaTest.ViewModels;

#if (CommunityToolkitChosen)
public partial class SettingsViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial string Greeting { get; set; } = "This is Settings";
}
#elif (ReactiveUIToolkitChosen)
public class SettingsViewModel : ViewModelBase
{
    private string _greeting = "This is Settings";

    public string Greeting
    {
        get => _greeting;
        set => this.RaiseAndSetIfChanged(ref _greeting, value);
    }
}
#endif
