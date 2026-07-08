namespace AvaloniaAppTemplate.ViewModels;

#if (CommunityToolkitChosen)
public partial class MainViewModel : ViewModelBase
#else
public class MainViewModel : ViewModelBase
#endif
{
    public string Greeting { get; } = "Welcome to Avalonia!";
}
