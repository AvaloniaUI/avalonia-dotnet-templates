using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI.Fody.Helpers;

namespace AvaloniaAppTemplate.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        [Reactive] public string Greeting { get; set; } = "Welcome to Avalonia!";
    }
}
