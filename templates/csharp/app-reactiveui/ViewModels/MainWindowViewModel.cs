using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Abstractions;
using ReactiveUI.Validation.Contexts;
using ReactiveUI.Validation.Extensions;
using Splat;

namespace AvaloniaAppTemplate.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IValidatableViewModel
    {
        public MainWindowViewModel()
        {
            this.ValidationRule(
                viewModel => viewModel.Name,
                name => !string.IsNullOrWhiteSpace(name),
                "You must specify a valid name");
            
            GreetingMessage = this.WhenAnyValue(x => x.Name).Select(name => $"{name}, Welcome to Avalonia!");
        }
        [Reactive] public string Name { get; set; } = string.Empty;
        public IObservable<string> GreetingMessage { get; }

        public ValidationContext ValidationContext { get; } = new ValidationContext();
    }
}
