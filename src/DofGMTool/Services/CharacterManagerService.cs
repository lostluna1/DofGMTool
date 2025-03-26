using DofGMTool.Constant;
using DofGMTool.Contracts.Services;
using DofGMTool.Helpers;
using DofGMTool.Models;
using System.Collections.ObjectModel;

namespace DofGMTool.Services;
public class CharacterManagerService : ICharacterManagerService
{
    //private IDatabaseService _databaseService;
    private readonly IEquipSlotProcessor _equipSlotProcessor;
    private readonly IFreeSql<SqliteFlag> _fsql;
    private IFreeSql _d_taiwan => DatabaseHelper.DTaiwan;
    private IFreeSql _taiwan_cain_2nd => DatabaseHelper.TaiwanCain2nd;
    private IFreeSql _taiwan_cain => DatabaseHelper.TaiwanCain;
    private IFreeSql _taiwan_billing => DatabaseHelper.TaiwanBilling;

    public CharacterManagerService(IEquipSlotProcessor equipSlotProcessor, IFreeSql<SqliteFlag> freeSql)
    {
        //DatabaseHelper databseService = DatabaseHelper.Instance;
        _equipSlotProcessor = equipSlotProcessor;
        _fsql = freeSql;
        //_d_taiwan = DatabaseHelper.GetMySqlConnection(DBNames.D_Taiwan);
        //_taiwan_cain_2nd = DatabaseHelper.GetMySqlConnection(DBNames.TaiwanCain2nd);
        //_taiwan_cain = DatabaseHelper.GetMySqlConnection(DBNames.TaiwanCain);
        //_taiwan_billing = DatabaseHelper.GetMySqlConnection(DBNames.TaiwanBilling);
    }

    public async Task<int> ClearEquipSlots(int characNo)
    {
        int result = await _taiwan_cain_2nd.Update<_Inventory>()
            .Set(a => a.Equipslot == null)
            .Where(a => a.CharacNo == characNo)
            .ExecuteAffrowsAsync();
        return result;
    }
    public async Task<int> SetInvenWeightMax(int characNo)
    {
        int result = await _taiwan_cain.Update<CharacInfo>()
            .Set(a => a.InvenWeight == 999999999)
            .Where(a => a.CharacNo == characNo)
            .ExecuteAffrowsAsync();
        return result;
    }


    public async Task<int> ClearInven(int characNo)
    {
        int result = await _taiwan_cain_2nd.Update<_Inventory>()
            .Set(a => a.Inventory == null)
            .Where(a => a.CharacNo == characNo)
            .ExecuteAffrowsAsync();
        return result;

    }


    public async Task<int> MaxInven(int characNo)
    {
        int result = await _taiwan_cain_2nd.Update<_Inventory>()
            .Set(a => a.InventoryCapacity == 16)
            .Where(a => a.CharacNo == characNo)
            .ExecuteAffrowsAsync();
        return result;
    }


    public async Task<int> LiftAccountBan(int accountId)
    {
        int result = await _d_taiwan.Delete<MemberPunishInfo>()
            .Where(a => a.MId == accountId)
            .ExecuteAffrowsAsync();

        return result;
    }


    public async Task<int> AccountBan(int accountId)
    {
        var data = new MemberPunishInfo
        {
            PunishType = 1,
            OccTime = DateTime.Now,
            PunishValue = 101,
            ApplyFlag = 2,
            StartTime = DateTime.Now,
            EndTime = DateTime.MaxValue,
            Reason = "ByGM",
            MId = accountId
        };
        int result = await _d_taiwan.InsertOrUpdate<MemberPunishInfo>()
            .SetSource(data)
            .ExecuteAffrowsAsync();

        return result;
    }


    public async Task<int> ClearRoleWarehouse(int characNo)
    {
        int result = await _taiwan_cain_2nd.Update<CharacInvenExpand>()
            .Set(a => a.Cargo == null)
            .Where(a => a.CharacNo == characNo)
            .ExecuteAffrowsAsync();
        return result;
    }


    public async Task<int> SetAccountWarehouseMax(int accountId)
    {
        _taiwan_cain.CodeFirst.SyncStructure<AccountCargo>();

        var data = new AccountCargo { Capacity = 56, MId = (ulong)accountId, OccTime = DateTime.Now };
        int result = await _taiwan_cain.InsertOrUpdate<AccountCargo>()
            .SetSource(data)
            .ExecuteAffrowsAsync();
        return result;
    }


    public async Task<int> SetWarehouseMax(int characNo)
    {
        int result = await _taiwan_cain_2nd.Update<CharacInvenExpand>()
            .Set(a => a.CargoCapacity == 152)
            .Where(a => a.CharacNo == characNo)
            .ExecuteAffrowsAsync();
        return result;
    }

    public async Task<int> UnlimitedCharacSlods(int accountId)
    {
        int result = await _taiwan_cain.Update<CharacView>()
            .Set(a => a.SlotEffectCount == 24)
            .Set(a => a.CharacSlotLimit == 24)
            .Where(a => a.MId == accountId)
            .ExecuteAffrowsAsync();
        return result;
    }


    public async Task<int> ReleaseExtendsSlods(int characNo)
    {
        //List<CharacStat> isReleasedList = await _taiwan_cain.Select<CharacStat>().Where(a => a.CharacNo == characNo && a.AddSlotFlag == 3).ToListAsync();
        //int isReleased = isReleasedList.Count;
        //if (isReleased > 0) { return 0; }
        int result = await _taiwan_cain.Update<CharacStat>().Set(a => a.AddSlotFlag == 3)
            .Where(a => a.CharacNo == characNo && a.AddSlotFlag != 3).ExecuteAffrowsAsync();
        return result;
    }

    public async Task<int> ReleaseExtendsSlods(List<int> characNos)
    {
        int result = 0;
        foreach (int item in characNos)
        {
            result += await _taiwan_cain.Update<CharacStat>().Set(a => a.AddSlotFlag == 3)
            .Where(a => a.CharacNo == item && a.AddSlotFlag != 3).ExecuteAffrowsAsync();
        }
        return result;
    }

    #region 完成角色任务
    public async Task<int> ClearMission(int characNo)
    {
        //byte[] clearQuestData = [
        //    0x30, 0x75, 0x00, 0x00, 0x78, 0x9C, 0xED, 0xC1, 0x31, 0x0D, 0x00, 0x00, 0x00, 0xC3, 0xA0, 0xD4,
        //    0xBF, 0xE9, 0x99, 0xD8, 0x09, 0x14, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        //    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        //    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xC0, 0xC7, 0x00, 0xB6, 0xB4, 0x75, 0x31
        //];

        //byte[] questNotifyData = new byte[] {
        //    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        //    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        //    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        //    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
        //};

        int result = await _taiwan_cain.Update<NewCharacQuest>()
            //.Set(a => a.ClearQuest, clearQuestData)
            //.Set(a => a.QuestNotify, questNotifyData)
            .Set(a => a.Play20Trigger == 0)
            .Set(a => a.Play19Trigger == 0)
            .Set(a => a.Play18Trigger == 0)
            .Set(a => a.Play17Trigger == 0)
            .Set(a => a.Play16Trigger == 0)
            .Set(a => a.Play15Trigger == 0)
            .Set(a => a.Play14Trigger == 0)
            .Set(a => a.Play13Trigger == 0)
            .Set(a => a.Play12Trigger == 0)
            .Set(a => a.Play11Trigger == 0)
            .Set(a => a.Play10Trigger == 0)
            .Set(a => a.Play9Trigger == 0)
            .Set(a => a.Play8Trigger == 0)
            .Set(a => a.Play7Trigger == 0)
            .Set(a => a.Play6Trigger == 0)
            .Set(a => a.Play5Trigger == 0)
            .Set(a => a.Play4Trigger == 0)
            .Set(a => a.Play3Trigger == 0)
            .Set(a => a.Play2Trigger == 0)
            .Set(a => a.Play1Trigger == 0)
            .Where(a => a.CharacNo == characNo)
            .ExecuteAffrowsAsync();
        return result;
    }

    public async Task<int> ClearMission(List<int> characNos)
    {
        //byte[] clearQuestData = [
        //    0x30, 0x75, 0x00, 0x00, 0x78, 0x9C, 0xED, 0xC1, 0x31, 0x0D, 0x00, 0x00, 0x00, 0xC3, 0xA0, 0xD4,
        //    0xBF, 0xE9, 0x99, 0xD8, 0x09, 0x14, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        //    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        //    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xC0, 0xC7, 0x00, 0xB6, 0xB4, 0x75, 0x31
        //];

        //byte[] questNotifyData = [
        //    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        //    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        //    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        //    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
        //];

        int result = 0;
        foreach (int characNo in characNos)
        {
            result += await _taiwan_cain.Update<NewCharacQuest>()
                //.Set(a => a.ClearQuest, clearQuestData)
                //.Set(a => a.QuestNotify, questNotifyData)
                .Set(a => a.Play20Trigger == 0)
                .Set(a => a.Play19Trigger == 0)
                .Set(a => a.Play18Trigger == 0)
                .Set(a => a.Play17Trigger == 0)
                .Set(a => a.Play16Trigger == 0)
                .Set(a => a.Play15Trigger == 0)
                .Set(a => a.Play14Trigger == 0)
                .Set(a => a.Play13Trigger == 0)
                .Set(a => a.Play12Trigger == 0)
                .Set(a => a.Play11Trigger == 0)
                .Set(a => a.Play10Trigger == 0)
                .Set(a => a.Play9Trigger == 0)
                .Set(a => a.Play8Trigger == 0)
                .Set(a => a.Play7Trigger == 0)
                .Set(a => a.Play6Trigger == 0)
                .Set(a => a.Play5Trigger == 0)
                .Set(a => a.Play4Trigger == 0)
                .Set(a => a.Play3Trigger == 0)
                .Set(a => a.Play2Trigger == 0)
                .Set(a => a.Play1Trigger == 0)
                .Where(a => a.CharacNo == characNo)
                .ExecuteAffrowsAsync();
        }
        return result;
    }
    #endregion


    public void ChangeCurrentEquip(ulong newEquipId, int slotIndex)
    {
        CharacInfo? currentCharacInfo = GlobalVariables.Instance.GlobalCurrentCharacInfo;
        if (currentCharacInfo == null || currentCharacInfo?.CharacNo == null)
        {
            return;
        }
        _Inventory a = _taiwan_cain_2nd.Ado.QuerySingle<_Inventory>($"SELECT UNCOMPRESS(equipslot) as EquipSlot  FROM inventory WHERE charac_no = {currentCharacInfo.CharacNo}");
        //var b = _fsql_2nd.Select<_Inventory>().Where(w => w.CharacNo == currentCharacInfo.CharacNo).ToList();
        //byte[] decompressedData = Decompress(b[0].Equipslot);
        byte[] decompressedData = a.Equipslot;
        List<byte[]> equipSlots = _equipSlotProcessor.ExtractEquipSlots(decompressedData);//732个字节

        //int slotIndex = 0;
        //ulong newEquipId = 27746; // 新的装备ID
        int bitStartIndex = 16;
        int bitLength = 32;
        List<byte[]> updatedBytes = _equipSlotProcessor.UpdateEquipSlotData(equipSlots, slotIndex, newEquipId, bitStartIndex, bitLength);
        byte[] updatedData = _equipSlotProcessor.CompressEquipSlots(updatedBytes);

        #region 更改当前装备
        byte[] compressedCombinedData = _equipSlotProcessor.CompressBytes(updatedData);
        _taiwan_cain_2nd.Update<_Inventory>()
           .Set(a => a.Equipslot, compressedCombinedData)
           .Where(w => w.CharacNo == currentCharacInfo.CharacNo)
           .ExecuteAffrows();
        #endregion

    }


    public void PowerupCurrentEquip(ulong powerupLevel, int slotIndex)
    {
        CharacInfo? currentCharacInfo = GlobalVariables.Instance.GlobalCurrentCharacInfo;
        if (currentCharacInfo == null || currentCharacInfo?.CharacNo == null)
        {
            return;
        }
        _Inventory a = _taiwan_cain_2nd.Ado.QuerySingle<_Inventory>($"SELECT UNCOMPRESS(equipslot) as EquipSlot  FROM inventory WHERE charac_no = {currentCharacInfo.CharacNo}");
        //var b = _fsql_2nd.Select<_Inventory>().Where(w => w.CharacNo == currentCharacInfo.CharacNo).ToList();
        //byte[] decompressedData = Decompress(b[0].Equipslot);
        byte[] decompressedData = a.Equipslot;
        List<byte[]> equipSlots = _equipSlotProcessor.ExtractEquipSlots(decompressedData);

        #region 强化等级设置为+15
        List<byte[]> updatedBytes1 = _equipSlotProcessor.UpdateEquipSlotData(equipSlots, slotIndex, powerupLevel, 48, 8);
        byte[] updatedData1 = _equipSlotProcessor.CompressEquipSlots(updatedBytes1);

        byte[] compressedCombinedData1 = _equipSlotProcessor.CompressBytes(updatedData1);
        _taiwan_cain_2nd.Update<_Inventory>()
            .Set(a => a.Equipslot, compressedCombinedData1)
            .Where(w => w.CharacNo == currentCharacInfo.CharacNo)
            .ExecuteAffrows();
        #endregion
    }


    public void AccountRecharge(int payValue, Pay pay)
    {
        if (GlobalVariables.Instance.GlobalCurrentCharacInfo == null)
        {
            return;
        }
        switch (pay)
        {
            case Pay.DDot:
                _taiwan_billing.Update<CashCeraPoint>()
                    .Set(a => a.CeraPoint + payValue)
                    .Where(a => a.Account == GlobalVariables.Instance.GlobalCurrentCharacInfo.MId.ToString())
                    .ExecuteAffrows();
                break;
            case Pay.DMoney:
                _taiwan_billing.Update<CashCera>()
                    .Set(a => a.Cera + payValue)
                    .Where(a => a.Account == GlobalVariables.Instance.GlobalCurrentCharacInfo.MId.ToString())
                    .ExecuteAffrows();
                break;
            case Pay.Money:
                _taiwan_cain_2nd.Update<_Inventory>()
                    .Set(a => a.Money + payValue)
                    .Where(a => a.CharacNo == GlobalVariables.Instance.GlobalCurrentCharacInfo.CharacNo)
                    .ExecuteAffrows();
                break;
            case Pay.SP:
                _taiwan_cain_2nd.Update<Skill>()
                    .Set(a => a.RemainSp + payValue)
                    .Where(a => a.CharacNo == GlobalVariables.Instance.GlobalCurrentCharacInfo.CharacNo)
                    .ExecuteAffrows();
                break;
            case Pay.TP:
                _taiwan_cain_2nd.Update<Skill>()
                    .Set(a => a.RemainSfp2nd + payValue)
                    .Set(a => a.RemainSfp1st + payValue)
                    .Where(a => a.CharacNo == GlobalVariables.Instance.GlobalCurrentCharacInfo.CharacNo)
                    .ExecuteAffrows();
                break;
            case Pay.PKLv:
                _taiwan_cain.Update<PvpResult>()
                    .Set(a => a.PvpGrade == payValue)
                    .Where(a => a.CharacNo == GlobalVariables.Instance.GlobalCurrentCharacInfo.CharacNo)
                    .ExecuteAffrows();
                break;
            case Pay.VictoryValue:
                _taiwan_cain.Update<PvpResult>()
                    .Set(a => a.WinPoint == payValue)
                    .Where(a => a.CharacNo == GlobalVariables.Instance.GlobalCurrentCharacInfo.CharacNo)
                    .ExecuteAffrows();
                break;
            case Pay.VictoryCount:
                _taiwan_cain.Update<PvpResult>()
                    .Set(a => a.Win == payValue)
                    .Where(a => a.CharacNo == GlobalVariables.Instance.GlobalCurrentCharacInfo.CharacNo)
                    .ExecuteAffrows();
                break;
            default:
                break;
        }
    }


    public void ChangeGrowType(int characNo, int job, int growType)
    {
        _taiwan_cain.Update<CharacInfo>()
            .Set(a => a.Job, job)
            .Set(a => a.GrowType, growType)
            .Where(a => a.CharacNo == characNo)
            .ExecuteAffrows();
    }


    public ObservableCollection<Equipments> GetAvatar(int characNo)
    {
        //_taiwan_cain_2nd = DatabaseHelper.GetMySqlConnection(DBNames.TaiwanCain2nd);
        var userItems = _taiwan_cain_2nd.Select<UserItems>().Where(a => a.CharacNo == characNo && a.Slot <= 9).OrderBy(a => a.Slot).ToList();
        var itemIds = userItems.Select(item => item.ItId.ToString()).ToList();
        if (itemIds?.Count == 0)
        {
            return [];
        }
        var equipmentList = _fsql.Select<Equipments>()
        .Where(e => itemIds!.Contains(e.ItemId!))
        .ToList();
        var equipments = new ObservableCollection<Equipments>(equipmentList);
        NPKHelper.GetBitMaps(equipments);
        return equipments;
    }


    public ObservableCollection<Equipments> GetCreature(int characNo)
    {
        var creatureItems = _taiwan_cain_2nd.Select<CreatureItems>().Where(a => a.CharacNo == characNo).ToList();
        var itemIds = creatureItems.Select(item => item.ItId.ToString()).ToList();
        if (itemIds?.Count == 0)
        {
            return [];
        }
        var equipmentList = _fsql.Select<Equipments>()
        .Where(e => itemIds!.Contains(e.ItemId!))
        .ToList();
        var equipments = new ObservableCollection<Equipments>(equipmentList);
        NPKHelper.GetBitMaps(equipments);
        return equipments;
    }
}
