using DofGMTool.Contracts.Services;
using DofGMTool.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace DofGMTool.Services;
public class InventoryManageService : IInventoryManageService
{
    public IFreeSql<SqliteFlag> _freeSql;
    public InventoryManageService(IFreeSql<SqliteFlag> freeSql)
    {
        _freeSql = freeSql;
        _freeSql.CodeFirst.SyncStructure<Equipments>();
        _freeSql.CodeFirst.SyncStructure<Skill>();

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

        foreach (var item in result)
        {
            if (!string.IsNullOrEmpty(item.SkillLevelUp))
            {
                var skillLevelInfos = ParseSkillLevelUpInfo(item.SkillLevelUp);
                item.SkillLevelList = skillLevelInfos;

                    item.Skill = await GetSkill(skillLevelInfos);
            }
        }
        Debug.WriteLine($"Total records: {total}");
        return (new ObservableCollection<Equipments>(result), (int)total);
    }

    /// <summary>
    /// 解析技能提升列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public ObservableCollection<SkillLevelUpInfo> ParseSkillLevelUpInfo(string input)
    {
        var skillLevelUpInfos = new ObservableCollection<SkillLevelUpInfo>();
        var regex = new Regex(@"`([^`]+)`\n(\d+)\t(\d+)\t|`([^`]+)`\n(\d+)\t(\d+)");

        var matches = regex.Matches(input);
        foreach (Match match in matches)
        {
            var job = match.Groups[1].Success ? match.Groups[1].Value : match.Groups[4].Value;
            var skillId = match.Groups[2].Success ? match.Groups[2].Value : match.Groups[5].Value;
            var levelUp = match.Groups[3].Success ? match.Groups[3].Value : match.Groups[6].Value;

            var skillLevelUpInfo = new SkillLevelUpInfo
            {
                Job = job.Replace("[", "").Replace("]", "").Replace(" ", ""),
                SkillId = int.Parse(skillId),
                LevelUp = int.Parse(levelUp)
            };
            skillLevelUpInfos.Add(skillLevelUpInfo);
        }

        return skillLevelUpInfos;
    }


    public async Task<ObservableCollection<Skill>> GetSkill(ObservableCollection<SkillLevelUpInfo> skillLevelUpInfos)
    {
        var skills = new ObservableCollection<Skill>();
        foreach (var item in skillLevelUpInfos)
        {
            var skill = await _freeSql.Select<Skill>()
                .Where(a => a.SkillId == item.SkillId.ToString() && (a.SourceList == item.Job || item.Job == "common"))
                .FirstAsync();
            if (skill != null /*&& !skills.Any(s => s.SkillId == skill.SkillId)*/)
            {
                if (TagDictionary.CharacterTypeTranslations.TryGetValue(skill.SourceList, out var translatedSourceList))
                {
                    skill.SourceList = translatedSourceList;
                }
                skills.Add(skill);
            }
        }
        return skills;
    }


    public async Task InsertEquipmentData(ObservableCollection<Equipments> equipments)
    {
        await _freeSql.InsertOrUpdate<Equipments>().SetSource(equipments).ExecuteAffrowsAsync();
    }

    public async Task InsertSkillData(ObservableCollection<Skill> skills)
    {
        await _freeSql.InsertOrUpdate<Skill>().SetSource(skills).ExecuteAffrowsAsync();

    }

    public async Task UpdateEquipmentData(ObservableCollection<Equipments> equipments)
    {
        await _freeSql.Update<Equipments>().SetSource(equipments).ExecuteAffrowsAsync();
    }
}
