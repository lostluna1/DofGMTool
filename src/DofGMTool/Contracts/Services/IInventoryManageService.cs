using DofGMTool.Models;
using System.Collections.ObjectModel;

namespace DofGMTool.Contracts.Services;
public interface IInventoryManageService
{
    Task InsertEquipmentData(ObservableCollection<Equipments> equipments);
    Task InsertSkillData(ObservableCollection<Skill> equipments);

    Task UpdateEquipmentData(ObservableCollection<Equipments> equipments);

    //Task< Skill> GetSkill(SkillLevelUpInfo skillLevelUpInfos);
    //SkillLevelUpInfo ParseSkillLevelUpInfo(string input);
    Task<int> DeleteEquipmentData(string guid);

    //Task<(ObservableCollection<Equipments> Equipments, int TotalCount)> GetEquipmentDataPaged(int pageNumber, int pageSize);
    Task<(ObservableCollection<Equipments> Equipments, int TotalCount)> GetEquipmentDataPaged(int pageNumber, int pageSize, string? itemId = null, string? itemName = null, RarityOption? rarityOption = null);
}