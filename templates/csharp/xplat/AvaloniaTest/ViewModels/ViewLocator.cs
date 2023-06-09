using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;

namespace AvaloniaTest.ViewModels;

[StaticViewLocator]
public partial class ViewLocator : IDataTemplate
{
	public Control Build(object? data)
	{
		if (data == null) throw new ArgumentNullException(nameof(data));
		var type = data.GetType();
		if (s_views.TryGetValue(type, out var func))
		{
			return func.Invoke();
		}
		throw new Exception($"Unable to create view for type: {type}");
	}

	public bool Match(object? data)
	{
		return data is ViewModelBase;
	}
}


