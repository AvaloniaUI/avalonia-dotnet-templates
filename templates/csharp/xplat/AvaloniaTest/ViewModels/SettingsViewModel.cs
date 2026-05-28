#if (CommunityToolkitChosen)
using CommunityToolkit.Mvvm.ComponentModel;
#endif

namespace AvaloniaTest.ViewModels;

#if (CommunityToolkitChosen)
public partial class SettingsViewModel : ViewModelBase
#else
public class SettingsViewModel : ViewModelBase
#endif
{
#if (CommunityToolkitChosen)
    [ObservableProperty]
    private string _greeting = "This is Settings";
#else
    public string Greeting { get; } = "This is Settings";
#endif
}
