using DofGMTool.Contracts.Services;
using DofGMTool.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

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
    public async Task<(ObservableCollection<Equipments> Equipments, int TotalCount)> GetEquipmentDataPaged(int pageNumber, int pageSize, string? itemId = null, string? itemName = null, RarityOption? rarityOption = null)
    {
        FreeSql.ISelect<Equipments> query = _freeSql.Select<Equipments>();

        // 添加条件选择
        if (!string.IsNullOrEmpty(itemName))
        {
            query = query.Where(e => e.ItemName.Contains(itemName));
        }

        if (!string.IsNullOrEmpty(itemId))
        {
            query = query.Where(e => e.ItemId!.Contains(itemId));
        }

        if (rarityOption != null)
        {
            query = query.Where(e => e.ItemRarityName == rarityOption.Name);
        }
        string sql = query.ToSql();
        Debug.WriteLine($"Generated SQL: {sql}");
        List<Equipments> result = await query.Count(out long total)
                                .Page(pageNumber, pageSize)
                                .ToListAsync();

        Debug.WriteLine($"Total records: {total}");
        return (new ObservableCollection<Equipments>(result), (int)total);
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
