using CommunityToolkit.Mvvm.ComponentModel;

using DofGMTool.Contracts.Services;
using DofGMTool.Models;
using DofGMTool.Views;

using Microsoft.UI.Xaml.Navigation;
using System.Collections.ObjectModel;

namespace DofGMTool.ViewModels;

public partial class ShellViewModel : ObservableRecipient
{
    public CharacterManageViewModel CharacInfoViewModel
    {
        get;
    }
    public IFreeSql<MySqlFlag> _taiwan_cain;
    [ObservableProperty]
    public partial ObservableCollection<CharacInfo> CharacInfos { get; set; } = [];

    [ObservableProperty]
    private bool isBackEnabled;

    [ObservableProperty]
    private object? selected;

    public INavigationService NavigationService
    {
        get;
    }

    public INavigationViewService NavigationViewService
    {
        get;
    }
    [ObservableProperty]
    public partial CharacInfo? SelectedCharacInfo { get; set; }

    [ObservableProperty]
    public partial GlobalVariables? _GlobalVariables { get; set; } = GlobalVariables.Instance;
    public ShellViewModel( INavigationService navigationService, INavigationViewService navigationViewService, IFreeSql<MySqlFlag> taiwan_cain, CharacterManageViewModel characInfoViewModel)
    {

        NavigationService = navigationService;
        NavigationService.Navigated += OnNavigated;
        NavigationViewService = navigationViewService;
        _taiwan_cain = taiwan_cain;
        CharacInfos = new ObservableCollection<CharacInfo>(_taiwan_cain.Select<CharacInfo>().ToList());
        CharacInfoViewModel = characInfoViewModel;
    }

    partial void OnSelectedCharacInfoChanged(CharacInfo? value)
    {
        if (value == null || _GlobalVariables==null)
        {
           return;
        }
        SelectedCharacInfo = value;
        _GlobalVariables.GlobalCurrentCharacInfo = value;
        CharacInfoViewModel.LoadCurrentCharacinfo();
    }
    private void OnNavigated(object sender, NavigationEventArgs e)
    {
        IsBackEnabled = NavigationService.CanGoBack;

        if (e.SourcePageType == typeof(SettingsPage))
        {
            Selected = NavigationViewService.SettingsItem;
            return;
        }

        Microsoft.UI.Xaml.Controls.NavigationViewItem? selectedItem = NavigationViewService.GetSelectedItem(e.SourcePageType);
        if (selectedItem != null)
        {
            Selected = selectedItem;
        }
    }
}
