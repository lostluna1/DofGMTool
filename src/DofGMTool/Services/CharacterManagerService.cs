using DofGMTool.Contracts.Services;
using DofGMTool.Models;

namespace DofGMTool.Services;
public class CharacterManagerService : ICharacterManagerService
{
    public IFreeSql<MySqlFlag> _databaseService;
    private readonly IEquipSlotProcessor _equipSlotProcessor;
    //public CharacInfo? currentCharacInfo { get;set;}
    public CharacterManagerService(IDatabaseService databaseService, IEquipSlotProcessor equipSlotProcessor)
    {
        _databaseService = databaseService.GetMySqlConnection("taiwan_cain_2nd");
        _equipSlotProcessor = equipSlotProcessor;
        //currentCharacInfo = GlobalVariables.Instance.GlobalCurrentCharacInfo;
    }
    //CharacInfo currentCharacInfo = GlobalVariables.Instance.GlobalCurrentCharacInfo;
    public void ChangeCurrentEquip(ulong newEquipId,int slotIndex)
    {
        var currentCharacInfo = GlobalVariables.Instance.GlobalCurrentCharacInfo;
        if (currentCharacInfo==null || currentCharacInfo?.CharacNo==null)
        {
            return;
        }
        _Inventory a = _databaseService.Ado.QuerySingle<_Inventory>($"SELECT UNCOMPRESS(equipslot) as EquipSlot  FROM inventory WHERE charac_no = {currentCharacInfo.CharacNo}");
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
         _databaseService.Update<_Inventory>()
            .Set(a => a.Equipslot, compressedCombinedData)
            .Where(w => w.CharacNo == currentCharacInfo.CharacNo)
            .ExecuteAffrows();
        #endregion
        
    }

    public void PowerupCurrentEquip(ulong powerupLevel, int slotIndex)
    {
        var currentCharacInfo = GlobalVariables.Instance.GlobalCurrentCharacInfo;
        if (currentCharacInfo == null || currentCharacInfo?.CharacNo == null)
        {
            return;
        }
        _Inventory a = _databaseService.Ado.QuerySingle<_Inventory>($"SELECT UNCOMPRESS(equipslot) as EquipSlot  FROM inventory WHERE charac_no = {currentCharacInfo.CharacNo}");
        //var b = _fsql_2nd.Select<_Inventory>().Where(w => w.CharacNo == currentCharacInfo.CharacNo).ToList();
        //byte[] decompressedData = Decompress(b[0].Equipslot);
        byte[] decompressedData = a.Equipslot;
        List<byte[]> equipSlots = _equipSlotProcessor.ExtractEquipSlots(decompressedData);

        #region 强化等级设置为+15
        List<byte[]> updatedBytes1 = _equipSlotProcessor.UpdateEquipSlotData(equipSlots, slotIndex, powerupLevel, 48, 8);
        byte[] updatedData1 = _equipSlotProcessor.CompressEquipSlots(updatedBytes1);

        byte[] compressedCombinedData1 = _equipSlotProcessor.CompressBytes(updatedData1);
        _databaseService.Update<_Inventory>()
            .Set(a => a.Equipslot, compressedCombinedData1)
            .Where(w => w.CharacNo == currentCharacInfo.CharacNo)
            .ExecuteAffrows();
        #endregion
    }
}
