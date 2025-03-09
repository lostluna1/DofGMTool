using DofGMTool.ViewModels;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DofGMTool.Views;

public sealed partial class ConnectionInfoDialog : ContentDialog
{
    public SettingsViewModel ViewModel
    {
        get;
    }
    public ConnectionInfoDialog(SettingsViewModel settingsViewModel)
    {
        this.InitializeComponent();
        ViewModel = settingsViewModel;
        DataContext = ViewModel;
    }
}
