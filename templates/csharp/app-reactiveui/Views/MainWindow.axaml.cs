using System.Reactive.Disposables;
using System.Threading;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using AvaloniaAppTemplate.ViewModels;
using ReactiveUI;
using ReactiveUI.Validation.Extensions;

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
        
        private TextBlock Greeting => this.FindControl<TextBlock>("Greeting");
        private TextBlock NameValidation => this.FindControl<TextBlock>("NameValidation");
        private TextBox Name => this.FindControl<TextBox>("Name");

        private void InitializeComponent()
        {
            this.WhenActivated(disposables =>
            {
                this.Bind(ViewModel, 
                        x=>x.Name, 
                        x=>x.Name.Text)
                    .DisposeWith(disposables);
                
                this.BindValidation(ViewModel, 
                        x => x.Name, 
                            x => x.NameValidation.Text)
                    .DisposeWith(disposables);

                this.WhenAnyObservable(x => x.ViewModel.GreetingMessage)
                    .BindTo(this, x => x.Greeting.Text)
                    .DisposeWith(disposables);

                this.Bind(ViewModel, 
                        x=>x.ValidationContext.IsValid, 
                        x=>x.Greeting.IsVisible)
                    .DisposeWith(disposables);
            });

            AvaloniaXamlLoader.Load(this);

        }
    }
}