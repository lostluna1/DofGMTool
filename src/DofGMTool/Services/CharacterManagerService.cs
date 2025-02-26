using DofGMTool.Constant;
using DofGMTool.Contracts.Services;
using DofGMTool.Helpers;
using DofGMTool.Models;
using System.Collections.ObjectModel;

namespace DofGMTool.Services;
public class CharacterManagerService : ICharacterManagerService
{
    //private IDatabaseService _databaseService;
    private IEquipSlotProcessor _equipSlotProcessor;
    private IFreeSql<SqliteFlag> _fsql;
    private IFreeSql<MySqlFlag> _taiwan_cain_2nd;
    private IFreeSql<MySqlFlag> _taiwan_cain;
    private IFreeSql<MySqlFlag> _taiwan_billing;

    public CharacterManagerService(
        IEquipSlotProcessor equipSlotProcessor,
        //IDatabaseService billingDatabaseService,
        IFreeSql<SqliteFlag> freeSql)
    {
        DatabaseHelper databseService = DatabaseHelper.Instance;
        _equipSlotProcessor = equipSlotProcessor;
        _fsql = freeSql;

        _taiwan_cain_2nd = databseService.GetMySqlConnection(DBNames.TaiwanCain2nd);
        _taiwan_cain = databseService.GetMySqlConnection(DBNames.TaiwanCain);
        _taiwan_billing = databseService.GetMySqlConnection(DBNames.TaiwanBilling);
    }
    //CharacInfo currentCharacInfo = GlobalVariables.Instance.GlobalCurrentCharacInfo;
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
        List<byte[]> equipSlots = _equipSlotProcessor.ExtractEquipSlots(decompressedData);

        //int slotIndex = 0;
        //ulong newEquipId = 27746; // 新的装备ID
        int bitStartIndex = 16;
        int bitLength = 32;
        List<byte[]> updatedBytes = _equipSlotProcessor.UpdateEquipSlotData(equipSlots, slotIndex, newEquipId, bitStartIndex, bitLength);
        byte[] updatedData = _equipSlotProcessor.CompressEquipSlots(updatedBytes);

        #region 更改当前武器为简易的武士刀
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
