using DofGMTool.Contracts.Services;
using DofGMTool.ViewModels;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Windows.Graphics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DofGMTool.Views;
/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public partial class LoginWindow : Window
{
    public LoginWindowViewModel ViewModel
    {
        get;
    }

    public LoginWindow()
    {
        InitializeComponent();
        this.ExtendsContentIntoTitleBar = true;
        ViewModel = App.GetService<LoginWindowViewModel>();

        if (Content is FrameworkElement frameworkElement)
        {
            frameworkElement.DataContext = ViewModel; // ÉèÖÃ DataContext
        }
        var appWindow = GetAppWindowForCurrentWindow();
        if (appWindow != null)
        {
            appWindow.Resize(new SizeInt32(570, 380));
            CenterWindow(appWindow);
        }
        ViewModel.LoginSucceeded += OnLoginSucceeded; // ¶©ÔÄÊÂ¼þ
    }
    private void CenterWindow(AppWindow appWindow)
    {
        var displayArea = DisplayArea.GetFromWindowId(appWindow.Id, DisplayAreaFallback.Primary);
        var centerPosition = new PointInt32(
            (displayArea.WorkArea.Width - appWindow.Size.Width) / 2,
            (displayArea.WorkArea.Height - appWindow.Size.Height) / 2
        );
        appWindow.Move(centerPosition);
    }

    private AppWindow? GetAppWindowForCurrentWindow()
    {
        var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
        var myWndId = Win32Interop.GetWindowIdFromWindow(hWnd);
        return AppWindow.GetFromWindowId(myWndId);
    }
    private void OnLoginSucceeded(object? sender, EventArgs e)
    {
        App.GetService<IActivationService>().ActivateAsync(e);
        Close();
    }


}

