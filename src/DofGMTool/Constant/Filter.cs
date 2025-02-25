namespace DofGMTool.Constant;
public class EquipTypeFilter
{
    public string[] Types { get; set; } = [];
    public bool IsInclude { get; set; } = true; // true 表示包含，false 表示不包含
}
