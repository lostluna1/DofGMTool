using DofGMTool.Constant;

namespace DofGMTool.Contracts.Services;
public interface ICharacterManagerService
{
    /// <summary>
    /// 变更当前装备
    /// </summary>
    /// <param name="newEquipId"></param>
    /// <param name="slotIndex"></param>
    void ChangeCurrentEquip(ulong newEquipId, int slotIndex);

    /// <summary>
    /// 强化当前装备
    /// </summary>
    /// <param name="powerupLevel"></param>
    /// <param name="slotIndex"></param>
    void PowerupCurrentEquip(ulong powerupLevel, int slotIndex);
    /// <summary>
    /// 充值
    /// </summary>
    /// <param name="mid"></param>
    /// <param name="payValue"></param>
    /// <param name="pay"></param>
    void AccountRecharge(int mid, int payValue, Pay pay);
}
