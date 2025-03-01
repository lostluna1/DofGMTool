using DofGMTool.Constant;
using DofGMTool.Models;
using System.Collections.ObjectModel;

namespace DofGMTool.Contracts.Services;
public interface ICharacterManagerService
{
    /// <summary>
    /// 更改当前装备
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
    void AccountRecharge(int payValue, Pay pay);

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

    /// <summary>
    /// 完成角色任务
    /// </summary>
    /// <param name="characNos"></param>
    /// <returns></returns>
    Task<int> ClearMission(List<int> characNos);

    /// <summary>
    /// 完成角色任务
    /// </summary>
    /// <param name="characNo"></param>
    /// <returns></returns>
    Task<int> ClearMission(int characNo);

    /// <summary>
    /// 开启辅助装备、魔法石装备槽位
    /// </summary>
    /// <param name="characNo"></param>
    /// <returns></returns>
    Task<int> ReleaseExtendsSlods(int characNo);

    /// <summary>
    /// 开启辅助装备、魔法石装备槽位
    /// </summary>
    /// <param name="characNo"></param>
    /// <returns></returns>
    Task<int> ReleaseExtendsSlods(List<int> characNos);

    /// <summary>
    /// 解除最大角色数限制
    /// </summary>
    /// <param name="accountId"></param>
    /// <returns></returns>
    Task<int> UnlimitedCharacSlods(int accountId);

    /// <summary>
    /// 设置仓库容量Max
    /// </summary>
    /// <param name="characNo"></param>
    /// <returns></returns>
    Task<int> SetWarehouseMax(int characNo);

    /// <summary>
    /// 设置账号金库Max
    /// </summary>
    /// <param name="accountId"></param>
    /// <returns></returns>
    Task<int> SetAccountWarehouseMax(int accountId);

    /// <summary>
    /// 封禁账号
    /// </summary>
    /// <param name="accountId"></param>
    /// <returns></returns>
    Task<int> AccountBan(int accountId);

    /// <summary>
    /// 账号解封
    /// </summary>
    /// <param name="accountId"></param>
    /// <returns></returns>
    Task<int> LiftAccountBan(int accountId);

    /// <summary>
    /// 清空角色仓库
    /// </summary>
    /// <param name="characNo"></param>
    /// <returns></returns>
    Task<int> ClearRoleWarehouse(int characNo);

    /// <summary>
    /// 背包满级
    /// </summary>
    /// <param name="characNo"></param>
    /// <returns></returns>
    Task<int> MaxInven(int characNo);

    /// <summary>
    /// 清空背包
    /// </summary>
    /// <param name="characNo"></param>
    /// <returns></returns>
    Task<int> ClearInven(int characNo);

    /// <summary>
    /// 角色背包无限负重
    /// </summary>
    /// <param name="characNo"></param>
    /// <returns></returns>
    Task<int> SetInvenWeightMax(int characNo);
    Task<int> ClearEquipSlots(int characNo);
}
