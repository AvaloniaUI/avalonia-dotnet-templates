using Android.App;
using Android.Runtime;
using Avalonia;
using Avalonia.Android;
#if (ReactiveUIToolkitChosen)
using ReactiveUI.Avalonia;
#endif

namespace AvaloniaTest.Android
{
    [Application]
    public class Application : AvaloniaAndroidApplication<App>
    {
        protected Application(nint javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
        {
            return base.CustomizeAppBuilder(builder)
#if (CommunityToolkitChosen)
            .WithInterFont();
#else
            .WithInterFont()
            .UseReactiveUI(_ => { });
#endif
        }
    }
}
