
using Avalonia;
using Avalonia.Controls;
#if (DrawerMainPageChosen || NavigationMainPageChosen)
using AvaloniaTest.ViewModels;
using System;
#endif

namespace AvaloniaTest.Views;

#if (ContentMainPageChosen)
public partial class MainView : ContentPage
#elif (TabbedMainPageChosen)
public partial class MainView : TabbedPage
#elif (DrawerMainPageChosen)
public partial class MainView : DrawerPage
#elif (NavigationMainPageChosen)
public partial class MainView : NavigationPage
#else
public partial class MainView : UserControl
#endif
{
    public MainView()
    {
        InitializeComponent();
    }
#if (DrawerMainPageChosen)

    protected override async void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);

        UpdatePage(DrawerList.SelectedIndex);
    }

    private async void DrawerList_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (ContentPage != null && sender is ListBox listbox)
        {
            var index = listbox.SelectedIndex;
            UpdatePage(index);
        }
    }

    private void UpdatePage(int index)
    {
        ViewModelBase page = index switch
        {
            0 => new HomeViewModel(),
            1 => new SettingsViewModel(),
            _ => throw new NotImplementedException()
        };

        if (page != null)
            ContentPage.Content = page;

        IsOpen = false;
    }
#elif (NavigationMainPageChosen)

    protected override async void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);

        if (CurrentPage == null)
            await PushAsync(new HomeView()
            {
                DataContext = new HomeViewModel()
            });
    }
#endif
}