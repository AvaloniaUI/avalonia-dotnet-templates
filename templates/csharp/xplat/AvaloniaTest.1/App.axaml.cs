using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
#if (CommunityToolkitChosen)
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
#endif
using Avalonia.Markup.Xaml;
using AvaloniaTest._1.ViewModels;
using AvaloniaTest._1.Views;

namespace AvaloniaTest._1;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
#if (CommunityToolkitChosen)
            // Line below is needed to remove Avalonia data validation.
            // Without this line you will get duplicate validations from both Avalonia and CT
            BindingPlugins.DataValidators.RemoveAt(0);
#endif
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel()
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}