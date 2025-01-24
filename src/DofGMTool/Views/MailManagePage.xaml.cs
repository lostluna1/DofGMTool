using DofGMTool.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace DofGMTool.Views;

public sealed partial class MailManagePage : Page
{
    public MailManageViewModel ViewModel
    {
        get;
    }

    public MailManagePage()
    {
        ViewModel = App.GetService<MailManageViewModel>();
        InitializeComponent();
    }
}
