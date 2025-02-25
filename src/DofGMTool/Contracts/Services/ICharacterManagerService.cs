using DofGMTool.Constant;
using DofGMTool.Models;
using System.Collections.ObjectModel;

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
    void AccountRecharge( int payValue, Pay pay);

    /// <summary>
    /// 转职
    /// </summary>
    /// <param name="characNo"></param>
    /// <param name="job"></param>
    /// <param name="growType"></param>
    void ChangeGrowType(int characNo, int job, int growType);

    /// <summary>
    /// 获取已穿戴装扮
    /// </summary>
    /// <param name="characNo"></param>
    /// <returns></returns>
    ObservableCollection<Equipments> GetAvatar(int characNo);

    /// <summary>
    /// 获取已佩戴的宠物
    /// </summary>
    /// <param name="characNo"></param>
    /// <returns></returns>
    ObservableCollection<Equipments> GetCreature(int characNo);
}
