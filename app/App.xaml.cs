using Avalonia;
using Avalonia.Markup.Xaml;

namespace AvaloniaAppTemplate
{
    public class App : Application
    {
        public override void Initialize()
        {
            var x = this.GetType();

            AvaloniaXamlLoader.Load(this);
        }
   }
}