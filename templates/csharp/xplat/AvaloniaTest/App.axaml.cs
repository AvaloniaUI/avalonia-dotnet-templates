using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
#if (!DefaultMainPageChosen)
using Avalonia.Controls;
#endif
#if (CommunityToolkitChosen)
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
#endif
using Avalonia.Markup.Xaml;
using AvaloniaTest.ViewModels;
using AvaloniaTest.Views;

namespace AvaloniaTest;

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
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel()
            };
        }
        else if (ApplicationLifetime is IActivityApplicationLifetime singleViewFactoryApplicationLifetime)
        {
#if (DefaultMainPageChosen)
            singleViewFactoryApplicationLifetime.MainViewFactory = () => new MainView { DataContext = new MainViewModel() };
#else
            singleViewFactoryApplicationLifetime.MainViewFactory = () => new PageNavigationHost()
            {
                Page = new MainView { DataContext = new MainViewModel() }
            };
#endif
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
#if (DefaultMainPageChosen)
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel()
            };
#else
            singleViewPlatform.MainView = new PageNavigationHost()
            {
                Page = new MainView { DataContext = new MainViewModel() }
            };
#endif
        }

        base.OnFrameworkInitializationCompleted();
    }
}