using DofGMTool.Models;
using DofGMTool.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using pvfLoaderXinyu;
using System.Text;
using Windows.Storage.Pickers;
using WinRT.Interop;

namespace DofGMTool.Views;

public sealed partial class InventoryManagePage : Page
{
    public InventoryManageViewModel ViewModel
    {
        get;
    }

    private string? pvfFilename;

    public InventoryManagePage()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        ViewModel = App.GetService<InventoryManageViewModel>();
        InitializeComponent();
    }

    private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is HyperlinkButton button && button.Tag is Equipments equipment)
        {
            ViewModel.SelectedInventoryItem = equipment;
            DeleteItem();
        }

    }

    private async void DeleteItem()
    {
        if (ViewModel.SelectedInventoryItem != null && ViewModel.InventoryItems != null)
        {
            await ViewModel.Delete(ViewModel.SelectedInventoryItem.Id);
            ViewModel.InventoryItems.Remove(ViewModel.SelectedInventoryItem);
        }
    }

    /// <summary>
    /// Load pvf file
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        var filePicker = new FileOpenPicker();
        InitializeWithWindow.Initialize(filePicker, WindowNative.GetWindowHandle(App.MainWindow));
        filePicker.ViewMode = PickerViewMode.Thumbnail;
        filePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
        filePicker.FileTypeFilter.Add(".pvf");

        Windows.Storage.StorageFile file = await filePicker.PickSingleFileAsync();
        if (file != null)
        {
            pvfFilename = file.Path;
            using var pvf = new PvfFile(pvfFilename);
            await ViewModel.LoadPvfCommandAsync(pvf);
            //GC.Collect();
            //GC.WaitForPendingFinalizers();
            //GC.Collect();
        }
    }

    private void PagerControl_SelectedIndexChanged(WinUICommunity.PagerControl sender, WinUICommunity.PagerControlSelectedIndexChangedEventArgs args)
    {
        ViewModel.SelectedPageIndex = args.NewPageIndex + 1;
    }

    private void ToolTip_KeyUp(object sender, Microsoft.UI.Xaml.Input.KeyRoutedEventArgs e)
    {

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

    public TextBlock _textBlockDescDtl { get; set; }
    public TextBlock _textBlockDesc { get; set; }

    public TextBlock _showDtlCommand { get; set; }

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


}


