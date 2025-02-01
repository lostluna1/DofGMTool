using DofGMTool.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;

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

    private void KeyboardAccelerator_Invoked(Microsoft.UI.Xaml.Input.KeyboardAccelerator sender, Microsoft.UI.Xaml.Input.KeyboardAcceleratorInvokedEventArgs args)
    {
        if (_textBlockDesc != null && _textBlockDescDtl != null)
        {
            // 交替显示 _textBlockDesc 和 _textBlockDescDtl
            if (_textBlockDesc.Visibility == Visibility.Visible)
            {
                _textBlockDesc.Visibility = Visibility.Collapsed;
                _textBlockDescDtl.Visibility = Visibility.Visible;
                _showDtlCommand.Text = "查看简要信息(F4)";

            }
            else
            {
                _textBlockDesc.Visibility = Visibility.Visible;
                _textBlockDescDtl.Visibility = Visibility.Collapsed;
                _showDtlCommand.Text = "查看详细说明(F4)";

            }
        }
        args.Handled = true;
    }

    public TextBlock? _textBlockDescDtl { get; set; }
    public TextBlock? _textBlockDesc { get; set; }

    public TextBlock? _showDtlCommand { get; set; }

    private void ItemToolTip_Opened(object sender, RoutedEventArgs e)
    {
        if (sender is ToolTip toolTip && toolTip.Content is FrameworkElement content)
        {
            var itemDescDTL = (TextBlock)content.FindName("ItemDescDTL");
            if (itemDescDTL != null)
            {
                _textBlockDescDtl = itemDescDTL;
            }
            var itemDesc = (TextBlock)content.FindName("ItemDesc");
            if (itemDesc != null)
            {
                _textBlockDesc = itemDesc;
            }

            var showDtlCommand = (TextBlock)content.FindName("ShowDtl");
            if (showDtlCommand != null)
            {
                _showDtlCommand = showDtlCommand;
            }
        }
    }

    private void Image_PointerEntered(object sender, PointerRoutedEventArgs e)
    {
        var image = sender as Image;
        var toolTip = ToolTipService.GetToolTip(image) as ToolTip;
        if (toolTip != null)
        {
            toolTip.IsOpen = true;
        }
    }

    private void Image_PointerExited(object sender, PointerRoutedEventArgs e)
    {
        var image = sender as Image;
        var toolTip = ToolTipService.GetToolTip(image) as ToolTip;
        if (toolTip != null)
        {
            toolTip.IsOpen = false;
        }
    }

}
