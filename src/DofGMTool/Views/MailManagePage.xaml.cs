using CommunityToolkit.WinUI;
using DofGMTool.Models;
using DofGMTool.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace DofGMTool.Views;

public sealed partial class MailManagePage : Page
{
    public MailManageViewModel ViewModel { get; }

    private MailType currentMailType = MailType.Equipment;

    public MailManagePage()
    {
        ViewModel = App.GetService<MailManageViewModel>();
        InitializeComponent();

    }
    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        await ViewModel.LoadMailHistory();
    }
    private async void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
    {
        if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
        {
            await ViewModel.FilterData(currentMailType, sender.Text);
        }
    }

    private async void SelectorBarSegmentedSelectionChanged(SelectorBar sender, SelectorBarSelectionChangedEventArgs args)
    {
        //var currentMailType = MailType.Equipment;
        SelectorBarItem selectedItem = sender.SelectedItem;
        bool a = false;
        if (selectedItem != null)
        {
            //ViewModel.SelectedEquip = null;
            //ViewModel.MailModel = null;

            switch (selectedItem.Text)
            {
                case "装备":
                    ItemIdTextBlock.IsEnabled = true;
                    ViewModel.SelectedMailType = MailType.Equipment;
                    currentMailType = MailType.Equipment;
                    ViewModel.IsPartsetTab = false;
                    ViewModel.IsEquipTab = true;
                    ViewModel.IsNotPartsetTab = true;
                    break;
                case "装扮":
                    ItemIdTextBlock.IsEnabled = true;
                    ViewModel.SelectedMailType = MailType.Avatar;
                    currentMailType = MailType.Avatar;
                    ViewModel.IsPartsetTab = false;
                    ViewModel.IsNotPartsetTab = true;
                    ViewModel.IsEquipTab = false;
                    break;
                case "宠物":
                    ItemIdTextBlock.IsEnabled = true;
                    ViewModel.SelectedMailType = MailType.Creature;
                    currentMailType = MailType.Creature;
                    ViewModel.IsPartsetTab = false;
                    ViewModel.IsEquipTab = false;
                    ViewModel.IsNotPartsetTab = true;
                    break;
                case "消耗品/材料":
                    ItemIdTextBlock.IsEnabled = true;
                    ViewModel.SelectedMailType = MailType.Stackable;
                    currentMailType = MailType.Stackable;
                    ViewModel.IsPartsetTab = false;
                    ViewModel.IsEquipTab = false;
                    ViewModel.IsNotPartsetTab = true;
                    break;
                case "套装":
                    ViewModel.SelectedMailType = MailType.Partset;
                    //currentMailType = MailType.Stackable;
                    a = true;
                    ViewModel.IsEquipTab = true;
                    ViewModel.IsPartsetTab = true;
                    ViewModel.IsNotPartsetTab = false;
                    ViewModel.TempDatas.Clear();
                    ItemIdTextBlock.Text = "发送套装时无需选择装备Id";
                    ItemIdTextBlock.IsEnabled = false;
                    break;
            }
        }
        if (!a)
        {
            await ViewModel.FilterData(currentMailType, string.Empty);
        }
    }

    private async void PartsetAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
    {
        if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
        {
            await ViewModel.LoadPartsetNames(sender.Text);
        }
    }

    private async void PartsetAutoSuggestBoxSuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
    {
        if (args.SelectedItem is EquipmentPartset selected)
        {
            await ViewModel.LoadPartsetData(selected.Id, selected.PartsetName);
            EquipmentsListView.SelectedIndex = 1;
            //ViewModel.SendMailCommand.NotifyCanExecuteChanged();

        }
    }

    private void InvertedListView_RightTapped(object sender, Microsoft.UI.Xaml.Input.RightTappedRoutedEventArgs e)
    {
        if (sender is ListView listView)
        {
            if ((e.OriginalSource as FrameworkElement)?.DataContext is Message clickedItem)
            {
                listView.SelectedItem = clickedItem;
            }
        }
    }
}


