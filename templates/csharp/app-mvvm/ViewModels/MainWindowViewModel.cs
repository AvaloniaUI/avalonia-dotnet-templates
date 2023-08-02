namespace AvaloniaAppTemplate.ViewModels;

#if (CommunityToolkitChosen)
public partial class MainWindowViewModel : ViewModelBase
#else
public class MainWindowViewModel : ViewModelBase
#endif
{
#pragma warning disable CA1822 // Mark members as static
	public string Greeting => "Welcome to Avalonia!";
#pragma warning restore CA1822 // Mark members as static
}
