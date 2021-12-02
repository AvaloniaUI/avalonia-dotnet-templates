using Avalonia.ReactiveUI;
using Avalonia.Web.Blazor;

namespace AvaloniaTest.Web;

public partial class App
{
    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        
        WebAppBuilder.Configure<LiveDemo.App>()
            .UseReactiveUI()
            .SetupWithSingleViewLifetime();
    }
}