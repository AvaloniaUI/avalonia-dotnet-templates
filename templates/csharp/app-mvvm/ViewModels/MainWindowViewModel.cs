namespace AvaloniaAppTemplate.ViewModels;

#if (CommunityToolkitChosen)
public partial class MainWindowViewModel : ViewModelBase
#else
public class MainWindowViewModel : ViewModelBase
#endif
{
    public string Greeting => "Welcome to Avalonia!";
}
