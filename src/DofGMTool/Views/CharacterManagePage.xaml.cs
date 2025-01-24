using DofGMTool.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace DofGMTool.Views;

public sealed partial class CharacterManagePage : Page
{
    public CharacterManageViewModel ViewModel
    {
        get;
    }

    public CharacterManagePage()
    {
        ViewModel = App.GetService<CharacterManageViewModel>();
        InitializeComponent();
    }
}
