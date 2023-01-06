using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
#if (CommunityToolkitChosen)
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
#endif
using Avalonia.Markup.Xaml;
using AvaloniaAppTemplate.ViewModels;
using AvaloniaAppTemplate.Views;

namespace AvaloniaAppTemplate;

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
            ExpressionObserver.DataValidators.RemoveAll(x => x is DataAnnotationsValidationPlugin);
#endif
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}