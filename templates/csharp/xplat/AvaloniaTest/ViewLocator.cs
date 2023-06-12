using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using AvaloniaTest.ViewModels;

namespace AvaloniaTest;

public class ViewLocator : IDataTemplate
{
#if (AvaloniaStableChosen)
    public IControl Build(object data)
#else
    public Control Build(object data)
#endif
    {
        if (data is null)
            return null;

        var name = data.GetType().FullName!.Replace("ViewModel", "View");
        var type = Type.GetType(name);

        if (type != null)
        {
            return (Control)Activator.CreateInstance(type)!;
        }
        
        return new TextBlock { Text = name };
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}