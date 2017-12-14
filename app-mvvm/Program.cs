using System;
using Avalonia;
using AvaloniaAppTemplate.ViewModels;
using AvaloniaAppTemplate.Views;

namespace AvaloniaAppTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildAvaloniaApp().Start<MainWindow>(() => new MainWindowViewModel());
        }

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>().UsePlatformDetect().UseReactiveUI();
    }
}
