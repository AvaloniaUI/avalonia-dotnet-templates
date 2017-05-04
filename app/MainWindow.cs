using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaAppTemplate
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}