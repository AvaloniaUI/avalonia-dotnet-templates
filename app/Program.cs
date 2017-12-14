using System;
using Avalonia;

namespace AvaloniaAppTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            AppBuilder.Configure<App>()
                .UsePlatformDetect()
                //.LogToDebug()
                .Start<MainWindow>();
        }

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>().UsePlatformDetect();
    }
}
