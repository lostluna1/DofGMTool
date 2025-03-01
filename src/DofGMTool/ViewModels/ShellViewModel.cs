using CommunityToolkit.Mvvm.ComponentModel;
using DofGMTool.Constant;
using DofGMTool.Contracts.Services;
using DofGMTool.Helpers;
using DofGMTool.Models;
using DofGMTool.Views;
using Microsoft.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace DofGMTool.ViewModels;

public partial class ShellViewModel : ObservableRecipient
{
    public CharacterManageViewModel CharacInfoViewModel
    {
        get;
    }
    public IFreeSql<MySqlFlag> _taiwan_cain;
    public IFreeSql<MySqlFlag> d_taiwan;
    //public IDatabaseService _databaseService;
    [ObservableProperty]
    public partial Accounts? SeletedAccount { get; set; }

    [ObservableProperty]
    public partial ObservableCollection<Accounts> AccountInfos { get; set; } = [];

    [ObservableProperty]
    public partial ObservableCollection<CharacInfo> CharacInfos { get; set; } = [];

    [ObservableProperty]
    public partial CharacInfo? SelectedCharacInfo { get; set; }


    [ObservableProperty]
    public partial bool IsBackEnabled { get; set; }

    [ObservableProperty]
    public partial object? Selected { get; set; }
    public INavigationService NavigationService
    {
        get;
    }

    public INavigationViewService NavigationViewService
    {
        get;
    }

    partial void OnSeletedAccountChanging(Accounts? value)
    {
        if (value == null)
        {
            return;
        }

        CharacInfos = new ObservableCollection<CharacInfo>(_taiwan_cain.Select<CharacInfo>().Where(w => w.MId == value.UID && w.DeleteFlag != 1).ToList());
        GlobalVariables.Instance.Accounts = value;
    }




    [ObservableProperty]
    public partial GlobalVariables? _GlobalVariables { get; set; } = GlobalVariables.Instance;
    public ShellViewModel(INavigationService navigationService,
        INavigationViewService navigationViewService, CharacterManageViewModel characInfoViewModel)
    {
        DatabaseHelper databaseService = DatabaseHelper.Instance;
        NavigationService = navigationService;
        NavigationService.Navigated += OnNavigated;
        NavigationViewService = navigationViewService;
        _taiwan_cain = databaseService.GetMySqlConnection(DBNames.TaiwanCain);
        d_taiwan = databaseService.GetMySqlConnection(DBNames.D_Taiwan);

        AccountInfos = new ObservableCollection<Accounts>(d_taiwan.Select<Accounts>().ToList());

        CharacInfoViewModel = characInfoViewModel;
    }

    partial void OnSelectedCharacInfoChanged(CharacInfo? value)
    {
        if (value == null || _GlobalVariables == null)
        {
            return;
        }
        SelectedCharacInfo = value;
        _GlobalVariables.GlobalCurrentCharacInfo = value;

        // 调用角色信息视图模型的加载当前角色信息方法(重载页面数据)
        CharacInfoViewModel.LoadCurrentCharacinfo();

        // 重定向到(刷新)角色管理页面(暂时这样做,目前没找到较好的根据标题栏角色选项变更刷新页面的实现方法
        // 要根据标题栏选中的角色信息刷新对应的界面的话只能挨个在这里判断了
        if (CanGoToCharacInfoPage == true)
        {
            NavigationService.NavigateTo(typeof(MainViewModel).FullName!);
            NavigationService.NavigateTo(typeof(CharacterManageViewModel).FullName!);
        }

    }

    public bool CanGoToCharacInfoPage { get; set; } = false;

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
            CanGoToCharacInfoPage = selectedItem.Content.ToString() == "角色管理";
            Debug.WriteLine(selectedItem.Content);
        }
    }
}
