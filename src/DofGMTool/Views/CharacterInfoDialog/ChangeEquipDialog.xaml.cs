using DofGMTool.Helpers;
using DofGMTool.Models;
using DofGMTool.ViewModels;
using Microsoft.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using System.Diagnostics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DofGMTool.Views;
/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class ChangeEquipmentDialog : ContentDialog
{
    public CharacterManageViewModel ViewModel
    {
        get;
    }
    public ChangeEquipmentDialog(CharacterManageViewModel characterManageViewModel)
    {
        this.InitializeComponent();
        ViewModel = characterManageViewModel;
        DataContext = ViewModel;
    }

    private void OnControlsSearchBoxQuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
    {
        Debug.WriteLine(111);
        if (this.Equipments != null && this.Equipments.Count > 0)
        {
            sender.ItemsSource = this.Equipments;
            sender.IsSuggestionListOpen = true; // 确保建议列表展开
        }
        else
        {
            sender.IsSuggestionListOpen = false; // 如果没有建议，关闭建议列表
        }

    }

    private void AutoSuggestBoxSuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
    {
        if (args.SelectedItem is Equipments selected)
        {
            if (ulong.TryParse(selected.ItemId, out ulong itemId))
            {
                ViewModel.newEquipId = itemId;
            }
            else
            {
                // Handle the case where the ItemId is not a valid ulong
                Debug.WriteLine("Invalid ItemId: " + selected.ItemId);
            }
        }
    }
    public ObservableCollection<Equipments> Equipments = [];
    private async void OnControlsSearchBoxTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
    {
        if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
        {
            string query = sender.Text.ToLower();
            (ObservableCollection<Equipments> Equipments, int TotalCount) result = await ViewModel._inventoryManageService.GetEquipmentDataPaged(1, 200, null, query, null);
            NPKHelper.GetBitMaps(result.Equipments);
            //var equip = ViewModel._inventoryManageService.GetEquipmentDataPaged();
            //List<NavigationMenuItem> allMenuItems = await GetAllMenuItems();
            ObservableCollection<Equipments> allEquipment = result.Equipments;//ViewModel.AllEquipments;
            //foreach (NavigationMenuItem item in allMenuItems)
            //{
            //    if (!string.IsNullOrEmpty(item.NavigateTo))
            //        item.NavigateTo = item.NavigateTo.Split("MES.Client.ViewModels.")[1];
            //}
            this.Equipments = allEquipment;
            sender.ItemsSource = allEquipment;


        }
    }
}
