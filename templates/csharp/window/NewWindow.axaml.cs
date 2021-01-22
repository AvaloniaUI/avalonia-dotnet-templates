using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaAppTemplate.Namespace
{
    public class NewWindow : Window
    {
        public NewWindow()
        {
            InitializeComponent();
//-:cnd:noEmit
#if DEBUG
            this.AttachDevTools();
#endif
//+:cnd:noEmit
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}