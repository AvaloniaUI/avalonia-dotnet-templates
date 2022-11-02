using System;
#if (!ReactiveUIToolkitChosen)
using System.ComponentModel;
#endif
using Avalonia.Controls;
using Avalonia.Controls.Templates;
#if (ReactiveUIToolkitChosen)
using AvaloniaAppTemplate.ViewModels;
#endif

namespace AvaloniaAppTemplate
{
    public class ViewLocator : IDataTemplate
    {
        public IControl Build(object data)
        {
            var name = data.GetType().FullName!.Replace("ViewModel", "View");
            var type = Type.GetType(name);

            if (type != null)
            {
                return (Control)Activator.CreateInstance(type)!;
            }
            
            return new TextBlock { Text = "Not Found: " + name };
        }

        public bool Match(object data)
        {

#if (ReactiveUIToolkitChosen)
            return data is ViewModelBase;
#else
            return data is INotifyPropertyChanged;
#endif
        }
    }
}