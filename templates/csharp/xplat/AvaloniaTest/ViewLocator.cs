using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using AvaloniaTest.ViewModels;

namespace AvaloniaTest;

public class ViewLocator : IDataTemplate
{
#if (AvaloniaStableChosen)
    public IControl Build(object param)
#else
    public Control? Build(object param)
#endif
    {
		if (param is null)
			return null;

		var name = param.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
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