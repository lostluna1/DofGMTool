using DofGMTool.ViewModels;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DofGMTool.Views;
/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class PowerupEquip : ContentDialog
{
    public CharacterManageViewModel ViewModel { get; set; }
    public PowerupEquip(CharacterManageViewModel characterManageViewModel)
    {
        this.InitializeComponent();
        ViewModel = characterManageViewModel;
        DataContext = ViewModel;
    }
}
