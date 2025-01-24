using CommunityToolkit.Mvvm.ComponentModel;

namespace DofGMTool.Models;
public partial class InventoryItem : ObservableRecipient
{
    /// <summary>
    /// 物品ID
    /// </summary>
    [ObservableProperty]
    public partial string? ItemId
    {
        get; set;
    }

    /// <summary>
    /// 物品名称
    /// </summary>
    [ObservableProperty]
    public partial string? ItemName
    {
        get; set;
    }

    /// <summary>
    /// 导入类型
    /// </summary>
    [ObservableProperty]
    public partial string? ItemImportType
    {
        get; set;
    }

    /// <summary>
    /// 物品稀有度
    /// </summary>
    [ObservableProperty]
    public partial RarityOption? ItemRarity
    {
        get; set;
    }
}
