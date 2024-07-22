using System.Runtime.Versioning;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Browser;
#if (ReactiveUIToolkitChosen)
using Avalonia.ReactiveUI;
#endif
using AvaloniaTest;

internal sealed partial class Program
{
    private static Task Main(string[] args) => BuildAvaloniaApp()
            .WithInterFont()
#if (ReactiveUIToolkitChosen)
            .UseReactiveUI()
#endif
            .StartBrowserAppAsync("out");

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>();
}