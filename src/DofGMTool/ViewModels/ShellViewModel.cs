﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using DofGMTool.Contracts.Services;
using DofGMTool.Helpers;
using DofGMTool.Messages;
using DofGMTool.Models;
using DofGMTool.Views;
using Microsoft.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace DofGMTool.ViewModels;

public partial class ShellViewModel : ObservableRecipient
{


    [ObservableProperty]
    public partial Accounts? SeletedAccount { get; set; }

    [ObservableProperty]
    public partial ObservableCollection<Accounts> AccountInfos { get; set; } = new ObservableCollection<Accounts>();

    [ObservableProperty]
    public partial ObservableCollection<CharacInfo> CharacInfos { get; set; } = new ObservableCollection<CharacInfo>();

    [ObservableProperty]
    public partial CharacInfo? SelectedCharacInfo { get; set; }

    [ObservableProperty]
    public partial ObservableCollection<ConnectionInfo>? Connections { get; set; } = new ObservableCollection<ConnectionInfo>();

    [ObservableProperty]
    public partial ConnectionInfo? SelectedConnection { get; set; }

    [ObservableProperty]
    public partial bool IsBackEnabled { get; set; }

    [ObservableProperty]
    public partial object? Selected { get; set; }

    public INavigationService NavigationService { get; }
    public INavigationViewService NavigationViewService { get; }

    partial void OnSeletedAccountChanged(Accounts? value)
    {
        if (value == null)
        {
            return;
        }
        var _taiwan_cain = DatabaseHelper.TaiwanCain;
        CharacInfos = new ObservableCollection<CharacInfo>(_taiwan_cain.Select<CharacInfo>().Where(w => w.MId == value.UID && w.DeleteFlag != 1).ToList());
        GlobalVariables.Instance.Accounts = value;
    }

    [ObservableProperty]
    public partial GlobalVariables? _GlobalVariables { get; set; } = GlobalVariables.Instance;

    public ShellViewModel(INavigationService navigationService,
        INavigationViewService navigationViewService)
    {
        NavigationService = navigationService;
        NavigationService.Navigated += OnNavigated;
        NavigationViewService = navigationViewService;
        Initialize();
        
        //var d_taiwan = DatabaseHelper.DTaiwan;
        //d_taiwan.CodeFirst.SyncStructure<Accounts>();
        //CharacInfoViewModel = characInfoViewModel;
    }

    /// <summary>
    /// 接收另一个视图模型的消息并设置连接信息
    /// </summary>
    public void Initialize()
    {
        // 注册消息接收器
        WeakReferenceMessenger.Default.Register<ConnectionsUpdatedMessage>(this, async (r, m) =>
        {
            // 加载连接信息
            Connections = await ConnectionHelper.LoadConnectionsAsync();
        });
    }

    [ObservableProperty]
    public partial bool IsConnecting { get; set; } = true;
    partial void OnSelectedConnectionChanged(ConnectionInfo? value)
    {
        //IsConnecting = true;
        if (value == null)
        {
            return;
        }
        GlobalVariables.Instance.ConnectionInfo = value;

        try
        {
            DatabaseHelper.ResetConnections();
            var d_taiwan = DatabaseHelper.DTaiwan;
            d_taiwan.CodeFirst.SyncStructure<Accounts>();
            IsConnecting = false;
            AccountInfos = new ObservableCollection<Accounts>(d_taiwan.Select<Accounts>().ToList());
        }
        catch (Exception ex)
        {
            IsConnecting = false;
            _ = Logger.Instance.WriteLogAsync($"OnSelectedConnectionChanged : {ex}", "connectionLog.txt");
            throw new Exception($"{GlobalVariables.Instance.ConnectionInfo.Name} : 连接失败，请检查连接信息",ex);
        }
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
        //CharacInfoViewModel.LoadCurrentCharacinfo();

        //// 重定向到(刷新)角色管理页面(暂时这样做,目前没找到较好的根据标题栏角色选项变更刷新页面的实现方法
        //// 要根据标题栏选中的角色信息刷新对应的界面的话只能挨个在这里判断了
        //if (CanGoToCharacInfoPage == true)
        //{
        //    NavigationService.NavigateTo(typeof(MainViewModel).FullName!);
        //    NavigationService.NavigateTo(typeof(CharacterManageViewModel).FullName!);
        //}
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


