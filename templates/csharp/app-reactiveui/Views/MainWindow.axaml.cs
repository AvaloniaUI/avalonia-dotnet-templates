using System.Reactive.Disposables;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using AvaloniaAppTemplate.ViewModels;
using ReactiveUI;

namespace AvaloniaAppTemplate.Views
{
    public class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
//-:cnd:noEmit
#if DEBUG
            this.AttachDevTools();
#endif
//+:cnd:noEmit
        }
        
        public TextBlock GreetingTextBlock => this.FindControl<TextBlock>("GreetingTextBlock");
        private void InitializeComponent()
        {
            this.WhenActivated(disposables =>
            {
                this.OneWayBind(this.ViewModel, x => x.Greeting, x=>x.GreetingTextBlock.Text).DisposeWith(disposables);
            });

            AvaloniaXamlLoader.Load(this);

        }
    }
}