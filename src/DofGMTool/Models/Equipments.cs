using CommunityToolkit.Mvvm.ComponentModel;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models;

[Table(Name = "Equipments")]
public partial class Equipments : ObservableObject
{
    public string Id { get; set; } = Guid.NewGuid().ToString("n");

    /// <summary>
    /// 装备ID
    /// </summary>
    [ObservableProperty]
    [Column(IsPrimary = true)]
    public partial string? ItemId
    {
        get; set;
    }

    /// <summary>
    /// 装备名称
    /// </summary>
    [ObservableProperty]
    public partial string? ItemName
    {
        get; set;
    }

    /// <summary>
    /// 装备图片路径
    /// </summary>
    [ObservableProperty]
    public partial string? NpkPath
    {
        get; set;
    }

    /// <summary>
    /// 装备图片帧序列
    /// </summary>
    [ObservableProperty]
    public partial uint FrameNo
    {
        get; set;
    }

    /// <summary>
    /// 装备描述
    /// </summary>
    [ObservableProperty]
    public partial string? Description
    {
        get; set;
    }

    /// <summary>
    /// 装备稀有度
    /// </summary>
    [Column(IsIgnore = true)]
    [ObservableProperty]
    public partial RarityOption? ItemRarity
    {
        get; set;
    }

    [Column(Name = "ItemRarity")]
    public string? ItemRarityName
    {
        get => ItemRarity?.Name;
        set
        {
            if (ItemRarity == null)
            {
                ItemRarity = new RarityOption { Name = value };
            }
            else
            {
                ItemRarity.Name = value;
            }
        }
    }
}



