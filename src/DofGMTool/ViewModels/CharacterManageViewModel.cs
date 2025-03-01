using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DofGMTool.Constant;
using DofGMTool.Contracts.Services;
using DofGMTool.Helpers;
using DofGMTool.Models;
using System.Collections.ObjectModel;

namespace DofGMTool.ViewModels;

public partial class CharacterManageViewModel : ObservableRecipient
{
    public IFreeSql<MySqlFlag> d_taiwan;
    public IFreeSql<MySqlFlag> taiwan_cain_2nd;
    public IFreeSql<MySqlFlag> taiwan_login;
    public IFreeSql<MySqlFlag> taiwan_cain;
    public IFreeSql<SqliteFlag> _fsql;
    public IInventoryManageService _inventoryManageService;
    public ICharacterManagerService _characterManagerService;
    private readonly IEquipSlotProcessor _equipSlotProcessor;
    //public IDatabaseService? _databaseService;

    [ObservableProperty]
    public partial ObservableCollection<EquipSlotModel>? EquipSlotModels { get; set; }

    [ObservableProperty]
    public partial ObservableCollection<Equipments>? Equips { get; set; }

    #region 装备
    /// <summary>
    /// 武器
    /// </summary>
    [ObservableProperty]
    public partial Equipments? Weapon { get; set; }

    /// <summary>
    /// 胸甲
    /// </summary>
    [ObservableProperty]
    public partial Equipments? Jacket { get; set; }

    /// <summary>
    /// 护肩
    /// </summary>
    [ObservableProperty]
    public partial Equipments? Shoulder { get; set; }

    /// <summary>
    /// 腰带
    /// </summary>
    [ObservableProperty]
    public partial Equipments? Belt { get; set; }

    /// <summary>
    /// 裤子
    /// </summary>
    [ObservableProperty]
    public partial Equipments? Pants { get; set; }

    /// <summary>
    /// 鞋子
    /// </summary>
    [ObservableProperty]
    public partial Equipments? Shoes { get; set; }

    /// <summary>
    /// 戒指
    /// </summary>
    [ObservableProperty]
    public partial Equipments? Ring { get; set; }

    /// <summary>
    /// 项链
    /// </summary>
    [ObservableProperty]
    public partial Equipments? Amulet { get; set; }

    /// <summary>
    /// 手镯
    /// </summary>
    [ObservableProperty]
    public partial Equipments? Wrist { get; set; }

    /// <summary>
    /// 称号
    /// </summary>
    [ObservableProperty]
    public partial Equipments? Title { get; set; }

    /// <summary>
    /// 魔法石
    /// </summary>
    [ObservableProperty]
    public partial Equipments? Magicstone { get; set; }
    /// <summary>
    /// 辅助装备
    /// </summary>
    [ObservableProperty]
    public partial Equipments? Support { get; set; }
    #endregion

    [ObservableProperty]
    public partial int CurrentSlot { get; set; }

    [ObservableProperty]
    public partial ulong newEquipId { get; set; }

    [ObservableProperty]
    public partial ulong PowerupLevel { get; set; }


    [ObservableProperty]
    public partial ObservableCollection<Equipments> AllEquipments { get; set; } = [];

    [ObservableProperty]
    public partial ObservableCollection<Equipments> Avatars { get; set; } = [];

    [ObservableProperty]
    public partial ObservableCollection<Equipments> Creatures { get; set; } = [];

    [ObservableProperty]
    public partial int AccountId { get; set; }

    [ObservableProperty]
    public partial int PayValue { get; set; }

    [ObservableProperty]
    public partial ObservableCollection<Pay> PayOptions { get; set; }

    [ObservableProperty]
    public partial Pay SelectedPay { get; set; }

    [ObservableProperty]
    public partial bool IsPayForAccount { get; set; } = true;

    [ObservableProperty]
    public partial bool IsPayForRole { get; set; } = false;

    partial void OnSelectedPayChanged(Pay value)
    {
        if (value == Pay.DMoney || value == Pay.DDot)
        {
            IsPayForAccount = true;
            IsPayForRole = false;
        }
        else
        {
            IsPayForAccount = false;
            IsPayForRole = true;
        }
    }


    [RelayCommand]
    public async Task CommonOperation(string type)
    {
        if (GlobalVariables.Instance.Accounts is null)
        {
            throw new Exception("请先选择账号");
        }
        if (GlobalVariables.Instance.GlobalCurrentCharacInfo is null)
        {
            throw new Exception("请先选择一个角色");
        }
        int characNo = GlobalVariables.Instance.GlobalCurrentCharacInfo.CharacNo;
        int accountId = GlobalVariables.Instance.Accounts.UID;
        switch (type)
        {
            case "ClearRoleWarehouse":
                await _characterManagerService.ClearRoleWarehouse(characNo);
                break;
            case "AccountBan":
                await _characterManagerService.AccountBan(accountId);
                break;
            case "LiftAccountBan":
                await _characterManagerService.LiftAccountBan(accountId);
                break;
            case "MaxInven":
                await _characterManagerService.MaxInven(characNo);
                break;
            case "ClearInven":
                await _characterManagerService.ClearInven(characNo);
                break;
            case "SetInvenWeightMax":
                await _characterManagerService.SetInvenWeightMax(characNo);
                break;
            case "ClearEquipSlots":
                await _characterManagerService.ClearEquipSlots(characNo);
                break;
            default:
                throw new ArgumentException("无效的操作类型", nameof(type));
        }
    }



    [RelayCommand]
    public async Task UnlimitedCharacSlods()
    {
        if (GlobalVariables.Instance.Accounts is null)
        {
            throw new Exception("请先选择账号");
        }
        await _characterManagerService.UnlimitedCharacSlods(GlobalVariables.Instance.Accounts.UID);
    }

    /// <summary>
    /// 仓库扩容
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    [RelayCommand]
    public async Task SetWarehouse(string type)
    {
        if (type == "1")
        {
            if (GlobalVariables.Instance.Accounts is null)
            {
                throw new Exception("请先选择账号");
            }
            await _characterManagerService.SetAccountWarehouseMax(GlobalVariables.Instance.Accounts.UID);
        }
        else if (type == "2")
        {
            if (GlobalVariables.Instance.GlobalCurrentCharacInfo is null)
            {
                throw new Exception("请先选择一个角色");
            }
            int chr = GlobalVariables.Instance.GlobalCurrentCharacInfo.CharacNo;
            await _characterManagerService.SetWarehouseMax(chr);
        }
        //await _characterManagerService.SetAccountWarehouseMax();
    }

    /// <summary>
    /// 完成任务
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    [RelayCommand]
    public async Task ClearMissions(string type)
    {

        if (type == "1")
        {
            if (GlobalVariables.Instance.Accounts is null)
            {
                throw new Exception("请先选择账号");
            }
            List<Accounts> characs = await d_taiwan.Select<Accounts>().ToListAsync();
            List<int> a = await taiwan_cain.Select<CharacInfo>()
                .Where(a => a.MId == GlobalVariables.Instance.Accounts.UID)
                .ToListAsync(a => a.CharacNo);

            await _characterManagerService.ClearMission(a);
        }
        else if (type == "2")
        {
            if (GlobalVariables.Instance.GlobalCurrentCharacInfo is null)
            {
                throw new Exception("请先选择一个角色");
            }
            int chr = GlobalVariables.Instance.GlobalCurrentCharacInfo.CharacNo;
            await _characterManagerService.ClearMission(chr);
        }
    }


    [RelayCommand]
    public async Task ReleaseExtendsSlods(string type)
    {
        if (type == "1")
        {
            if (GlobalVariables.Instance.GlobalCurrentCharacInfo is null)
            {
                throw new Exception("请先选择一个角色");
            }
            int chr = GlobalVariables.Instance.GlobalCurrentCharacInfo.CharacNo;
            await _characterManagerService.ReleaseExtendsSlods(chr);
        }
        else if (type == "2")
        {
            if (GlobalVariables.Instance.Accounts is null)
            {
                throw new Exception("请先选择账号");
            }
            List<Accounts> characs = await d_taiwan.Select<Accounts>().ToListAsync();
            List<int> a = await taiwan_cain.Select<CharacInfo>()
                .Where(a => a.MId == GlobalVariables.Instance.Accounts.UID)
                .ToListAsync(a => a.CharacNo);
            await _characterManagerService.ReleaseExtendsSlods(a);
        }
    }

    [RelayCommand]
    public void AccountRecharge()
    {
        _characterManagerService.AccountRecharge(/*AccountId,*/ PayValue, SelectedPay);
    }

    [RelayCommand]
    public void ChangeCurrentEquip(/*int curSlot*/)
    {
        _characterManagerService.ChangeCurrentEquip(newEquipId, CurrentSlot);
        LoadCurrentCharacinfo();
    }

    [RelayCommand]
    public void PowerupCurrentEquip(/*int curSlot*/)
    {
        _characterManagerService.PowerupCurrentEquip(PowerupLevel, CurrentSlot);
        LoadCurrentCharacinfo();

    }

    public CharacterManageViewModel(
        ICharacterManagerService characterManagerService,
        IInventoryManageService inventoryManageService,
        IEquipSlotProcessor equipSlotProcessor, IFreeSql<SqliteFlag> freeSql)
    {
        DatabaseHelper databaseService = DatabaseHelper.Instance;
        d_taiwan = databaseService.GetMySqlConnection(DBNames.D_Taiwan);
        _inventoryManageService = inventoryManageService;
        _characterManagerService = characterManagerService;
        _fsql = freeSql;
        taiwan_cain = databaseService.GetMySqlConnection(DBNames.TaiwanCain);
        taiwan_cain_2nd = databaseService.GetMySqlConnection(DBNames.TaiwanCain2nd);
        taiwan_login = databaseService.GetMySqlConnection(DBNames.TaiwanLogin);
        _equipSlotProcessor = equipSlotProcessor;
        PayOptions = new ObservableCollection<Pay>(Enum.GetValues(typeof(Pay)).Cast<Pay>());
        LoadCurrentCharacinfo();

    }
    public async void LoadCurrentCharacinfo()
    {

        if (GlobalVariables.Instance?.GlobalCurrentCharacInfo == null)
        {
            return;
        }
        CharacInfo currentCharacInfo = GlobalVariables.Instance.GlobalCurrentCharacInfo; //taiwan_cain.Select<CharacInfo>().Where(a => a.CharacNo == newVal.CharacNo).First();
        var equipSlots1 = await _equipSlotProcessor.GetEquipSlots(currentCharacInfo.CharacNo);

        _Inventory a = taiwan_cain_2nd.Ado.QuerySingle<_Inventory>($"SELECT UNCOMPRESS(equipslot) as EquipSlot  FROM inventory WHERE charac_no = {currentCharacInfo.CharacNo}");
        //var b = taiwan_cain_2nd.Select<_Inventory>().Where(w => w.CharacNo == currentCharacInfo.CharacNo).ToList();
        //byte[] decompressedData = Decompress(b[0].Equipslot);
        byte[] decompressedData = a.Equipslot;
        List<byte[]> equipSlots = _equipSlotProcessor.ExtractEquipSlots(decompressedData);


        //IEnumerable<EquipSlotModel> equipSlotModels = _equipSlotProcessor.ConvertSlotsToEquipSlotModels(equipSlots)/*.Where(a => a.EquipId != 0)*/;
        EquipSlotModels = new ObservableCollection<EquipSlotModel>(equipSlots1);
        //EquipSlotModels = new ObservableCollection<EquipSlotModel>(equipSlotModels);

        if (EquipSlotModels != null)
        {

            EquipSlotModels[6].EquipId = 120087;
            //AllEquipments = GetEquipment(EquipSlotModels);
            Weapon = AllEquipments.FirstOrDefault(a => a.EquipmentType == "武器");
            Jacket = AllEquipments.FirstOrDefault(a => a.EquipmentType == "胸甲");
            Shoulder = AllEquipments.FirstOrDefault(a => a.EquipmentType == "肩膀");
            Belt = AllEquipments.FirstOrDefault(a => a.EquipmentType == "腰带");
            Pants = AllEquipments.FirstOrDefault(a => a.EquipmentType == "护腿");
            Shoes = AllEquipments.FirstOrDefault(a => a.EquipmentType == "鞋子");
            Ring = AllEquipments.FirstOrDefault(a => a.EquipmentType == "戒指");
            Amulet = AllEquipments.FirstOrDefault(a => a.EquipmentType == "护身符");
            Wrist = AllEquipments.FirstOrDefault(a => a.EquipmentType == "手镯");
            Title = AllEquipments.FirstOrDefault(a => a.EquipmentType == "称号");
            Magicstone = AllEquipments.FirstOrDefault(a => a.EquipmentType == "魔法石");
            Support = AllEquipments.FirstOrDefault(a => a.EquipmentType == "辅助装备");
            NPKHelper.GetBitMaps(AllEquipments);
            await _equipSlotProcessor.SetEquipSlots(GlobalVariables.Instance.GlobalCurrentCharacInfo.CharacNo, EquipSlotModels,false);
            //GetBitMaps(EquipSlotModels);
        }
        Avatars = _characterManagerService.GetAvatar(GlobalVariables.Instance.GlobalCurrentCharacInfo.CharacNo);
        Creatures = _characterManagerService.GetCreature(GlobalVariables.Instance.GlobalCurrentCharacInfo.CharacNo);
    }

    [RelayCommand]
    public void SetGM()
    {
        try
        {
            if (GlobalVariables.Instance.GlobalCurrentCharacInfo != null)
            {
                taiwan_login.Delete<GmManifest>().Where(w => w.MId == GlobalVariables.Instance.GlobalCurrentCharacInfo.MId).ExecuteAffrows();
                var data = new GmManifest
                {
                    Level = 7,
                    MId = GlobalVariables.Instance.GlobalCurrentCharacInfo.MId
                };
                taiwan_login.Insert<GmManifest>(data).ExecuteAffrows();
            }
        }
        catch (Exception e)
        {
            if (e.InnerException?.Message == $"Duplicate entry '{GlobalVariables.Instance.GlobalCurrentCharacInfo.MId}' for key 'PRIMARY'")
            {
                throw new Exception("这个账号已经是GM了");
            }
            else
            {
                throw; // 重新抛出其他异常
            }
        }
    }

    /*    
        partial void OnSelectedCharacInfoChanged(CharacInfo? value)
        {
            if (value == null)
            {
                return;
            }
            GlobalVariables.Instance.GlobalCurrentCharacInfo = value;
            _GlobalVariables.GlobalCurrentCharacInfo = value;
            SelectedCharacInfo = value;
            LoadCurrentCharacinfo(_GlobalVariables.GlobalCurrentCharacInfo!);
        }*/

    public ObservableCollection<Equipments> GetEquipment(ObservableCollection<EquipSlotModel> Equips)
    {
        ObservableCollection<Equipments> AllEquipments = [];
        if (Equips?.Count > 0)
        {
            foreach (EquipSlotModel item in Equips)
            {
                ulong equipmentId = item.EquipId;
                Equipments equips = _fsql.Select<Equipments>().Where(a => a.ItemId == equipmentId.ToString()).First();
                equips.EquipSlot = item;
                AllEquipments.Add(equips);
            }
        }
        return AllEquipments;
        //await _fsql.Select<Equipments>().Where(a => a.ItemId == equipmentId).ToListAsync();
    }

}
