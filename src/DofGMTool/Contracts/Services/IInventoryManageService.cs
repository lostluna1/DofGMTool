using System.Collections.ObjectModel;
using DofGMTool.Models;

namespace DofGMTool.Contracts.Services;
public interface IInventoryManageService
{
    Task InsertEquipmentData(ObservableCollection<Equipments> equipments);

    Task UpdateEquipmentData(ObservableCollection<Equipments> equipments);

    Task<int> DeleteEquipmentData(string guid);

    Task<ObservableCollection<Equipments>> GetEquipmentData();
}
