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
}


