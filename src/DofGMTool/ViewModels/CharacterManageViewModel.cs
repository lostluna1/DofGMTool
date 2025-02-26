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
    public void LoadCurrentCharacinfo()
    {

        if (GlobalVariables.Instance?.GlobalCurrentCharacInfo == null)
        {
            return;
        }
        CharacInfo currentCharacInfo = GlobalVariables.Instance.GlobalCurrentCharacInfo; //taiwan_cain.Select<CharacInfo>().Where(a => a.CharacNo == newVal.CharacNo).First();


        _Inventory a = taiwan_cain_2nd.Ado.QuerySingle<_Inventory>($"SELECT UNCOMPRESS(equipslot) as EquipSlot  FROM inventory WHERE charac_no = {currentCharacInfo.CharacNo}");
        //var b = taiwan_cain_2nd.Select<_Inventory>().Where(w => w.CharacNo == currentCharacInfo.CharacNo).ToList();
        //byte[] decompressedData = Decompress(b[0].Equipslot);
        byte[] decompressedData = a.Equipslot;
        List<byte[]> equipSlots = _equipSlotProcessor.ExtractEquipSlots(decompressedData);


        IEnumerable<EquipSlotModel> equipSlotModels = _equipSlotProcessor.ConvertSlotsToEquipSlotModels(equipSlots).Where(a => a.EquipId != 0);
        EquipSlotModels = new ObservableCollection<EquipSlotModel>(equipSlotModels);

        if (EquipSlotModels != null)
        {
            AllEquipments = GetEquipment(EquipSlotModels);
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

            //GetBitMaps(EquipSlotModels);
        }
        Avatars = _characterManagerService.GetAvatar(GlobalVariables.Instance.GlobalCurrentCharacInfo.CharacNo);
        Creatures = _characterManagerService.GetCreature(GlobalVariables.Instance.GlobalCurrentCharacInfo.CharacNo);
    }

    [RelayCommand]
    public void SetGM()
    {

        if (GlobalVariables.Instance.GlobalCurrentCharacInfo != null)
        {
            taiwan_login.Delete<GmManifest>().Where(w => w.MId == GlobalVariables.Instance.GlobalCurrentCharacInfo.MId);
            var data = new GmManifest
            {
                Level = 7,
                MId = GlobalVariables.Instance.GlobalCurrentCharacInfo.MId
            };
            taiwan_login.Insert<GmManifest>(data).ExecuteAffrows();
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
