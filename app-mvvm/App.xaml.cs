using Avalonia;
using Avalonia.Markup.Xaml;

namespace AvaloniaAppTemplate
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
   }
}