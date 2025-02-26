﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DofGMTool.Contracts.Services;
using DofGMTool.Enums;
using DofGMTool.Helpers;
using DofGMTool.Models;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using System.Collections.ObjectModel;

namespace DofGMTool.ViewModels;

public partial class MailManageViewModel : ObservableRecipient
{
    public ISendMailService SendMailService { get; }
    public IFreeSql<SqliteFlag> _sqlite;

    [ObservableProperty]
    public partial ObservableCollection<Message> Message { get; set; } = new();

    [ObservableProperty]
    public partial Message? SelectedMessage { get; set; }

    [ObservableProperty]
    public partial MailModel? MailModel { get; set; } = new();

    [ObservableProperty]
    public partial Equipments? SelectedEquip { get; set; }

    [ObservableProperty]
    public partial EquipmentData? EquipmentsData { get; set; }

    [ObservableProperty]
    public partial ObservableCollection<EquipmentPartset> EquipmentPartsets { get; set; } = new();

    [ObservableProperty]
    public partial ObservableCollection<Equipments> TempDatas { get; set; } = new();

    [ObservableProperty]
    public partial ObservableCollection<Equipments> Equipments { get; set; } = new();

    [ObservableProperty]
    public partial ObservableCollection<Equipments> Avatars { get; set; } = new();

    [ObservableProperty]
    public partial ObservableCollection<Equipments> Creatures { get; set; } = new();

    [ObservableProperty]
    public partial MailType SelectedMailType { get; set; } = MailType.Equipment;

    public IEnumerable<IncreaseType> IncreaseTypes => Enum.GetValues(typeof(IncreaseType)).Cast<IncreaseType>();

    [ObservableProperty]
    public partial bool IsEquipTab { get; set; } = true;

    [ObservableProperty]
    public partial bool IsPartsetTab { get; set; } = true;

    [ObservableProperty]
    public partial bool IsNotPartsetTab { get; set; } = true;

    public MailManageViewModel(ISendMailService sendMailService, IFreeSql<SqliteFlag> freeSql)
    {
        SendMailService = sendMailService;
        _sqlite = freeSql;
        _ = LoadData();
        try
        {
            MailModel.CharacNo.Add(GlobalVariables.Instance.GlobalCurrentCharacInfo.CharacNo);
        }
        catch (Exception)
        {
            throw new Exception("请先选择角色");
        }
        LoadMailHistory();
        //EquipmentPartsets = new ObservableCollection<EquipmentPartset>(_sqlite.Select<EquipmentPartset>().Where(a=>a.Id!=2).ToList());
    }

    public async Task LoadData()
    {

        Equipments = await SendMailService.GetItemsList(MailType.Equipment);
        NPKHelper.GetBitMaps(Equipments);
        TempDatas = Equipments;
    }
    public async Task LoadPartsetData(int id, string? partsetName = null)
    {
        TempDatas = await SendMailService.GetEquipmentExAsync(id, partsetName);
        NPKHelper.GetBitMaps(TempDatas);
    }
    public async Task LoadPartsetNames(string query)
    {
        EquipmentPartsets = await SendMailService.GetEquipmentPartsetAsync(query);
        //NPKHelper.GetBitMaps(TempDatas);
    }
    [RelayCommand]
    public void LoadMailHistory()
    {

        ObservableCollection<_Postal>? data = SendMailService.GetPostals();
        foreach (_Postal item in data)
        {
            string? roleName = SendMailService.GetRoleNameById(item.ReceiveCharacNo);
            string? itemName = _sqlite.Select<Equipments>().Where(a => a.ItemId == item.ItemId.ToString()).First().ItemName;
            Message.Add(new Message($"To: {roleName}", item.OccTime, HorizontalAlignment.Right, (int)item.PostalId, $"{itemName}({item.ItemId})", new SolidColorBrush(Colors.Blue)));
            // 收件人尚未接收邮件
            if (item.ReceiveTime == DateTime.MinValue)
            {
                continue;
            }
            Message.Add(new Message($"Recive: {roleName}", item.ReceiveTime, HorizontalAlignment.Left, (int)item.PostalId, $"{itemName}({item.ItemId})", new SolidColorBrush(Colors.Green)));
        }
    }

    public async Task FilterData(MailType type, string query)
    {
        TempDatas = await SendMailService.GetItemsList(type, query);
        NPKHelper.GetBitMaps(TempDatas);
    }

    public async Task LoadEquipments()
    {
        TempDatas = await SendMailService.GetItemsList(MailType.Equipment);
        NPKHelper.GetBitMaps(TempDatas);
    }

    public async Task LoadAvatars()
    {
        TempDatas = await SendMailService.GetItemsList(MailType.Avatar);
        NPKHelper.GetBitMaps(TempDatas);
    }

    public async Task LoadCreatures()
    {
        TempDatas = await SendMailService.GetItemsList(MailType.Creature);
        NPKHelper.GetBitMaps(TempDatas);
    }
    public async Task LoadStackables()
    {
        TempDatas = await SendMailService.GetItemsList(MailType.Stackable);
        NPKHelper.GetBitMaps(TempDatas);
    }

    [RelayCommand/*(CanExecute = nameof(CanSendMail))*/]
    public void SendMail()
    {
        if (MailModel is null)
        {
            return;
        }
        MailModel.CharacNo.Clear();
        MailModel.CharacNo.Add(GlobalVariables.Instance.GlobalCurrentCharacInfo!.CharacNo);

        if (SelectedEquip is not null && SelectedEquip.ItemId != null)
        {
            MailModel.ItemId = int.Parse(SelectedEquip.ItemId);
        }
        try
        {
            int id = SendMailService.SendMail(SelectedMailType, MailModel, TempDatas);
            string? itemName = _sqlite.Select<Equipments>().Where(a => a.ItemId == SelectedEquip.ItemId.ToString()).First().ItemName;
            string? roleName = SendMailService.GetRoleNameById(GlobalVariables.Instance.GlobalCurrentCharacInfo.CharacNo);
            Message.Add(new Message($"To: {roleName}", DateTime.Now, HorizontalAlignment.Right, id, $"{itemName}({SelectedEquip.ItemId})", new SolidColorBrush(Colors.Blue)));

        }
        catch
        {

            throw new Exception("请先选择一件物品");
        }
    }

    //private bool CanSendMail()
    //{
    //    return SelectedEquip != null && !string.IsNullOrEmpty(SelectedEquip.ItemId) ||  IsPartsetTab==true;
    //}

    //partial void OnSelectedEquipChanged(Equipments? value)
    //{
    //    // 告诉SendMail我已经选择了一个item
    //    SendMailCommand.NotifyCanExecuteChanged();
    //}
    [RelayCommand]
    public void DeleteMail()
    {
        if (SelectedMessage is null)
        {
            throw new Exception("请先选择一件物品");
        }
        SendMailService.DeletePostal(SelectedMessage.PostId);
        Message.RemoveAt(Message.IndexOf(SelectedMessage));
    }
}

