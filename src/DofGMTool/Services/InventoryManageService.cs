using System.Collections.ObjectModel;
using DofGMTool.Contracts.Services;
using DofGMTool.Models;

namespace DofGMTool.Services;
public class InventoryManageService : IInventoryManageService
{
    public IFreeSql<SqliteFlag> _freeSql;
    public InventoryManageService(IFreeSql<SqliteFlag> freeSql)
    {
        _freeSql = freeSql;
        _freeSql.CodeFirst.SyncStructure<Equipments>();

    }
    public async Task<int> DeleteEquipmentData(string guid)
    {
        return await _freeSql.Delete<Equipments>().Where(a => a.Id == guid).ExecuteAffrowsAsync();
    }
    public async Task<ObservableCollection<Equipments>> GetEquipmentData()
    {
        var result = await _freeSql.Select<Equipments>().ToListAsync();
        return new ObservableCollection<Equipments>(result);
    }
    public async Task InsertEquipmentData(ObservableCollection<Equipments> equipments)
    {
        await _freeSql.InsertOrUpdate<Equipments>().SetSource(equipments).ExecuteAffrowsAsync();
    }
    public async Task UpdateEquipmentData(ObservableCollection<Equipments> equipments)
    {
        await _freeSql.Update<Equipments>().SetSource(equipments).ExecuteAffrowsAsync();
    }
}
