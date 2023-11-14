using Avalonia.Controls.Primitives;

namespace AvaloniaAppTemplate.Namespace;

public class NewTemplatedControl : TemplatedControl
{
    protected override Type StyleKeyOverride => 
        typeof(Avalonia.Labs.Controls.ContentDialog);
}