using CommunityToolkit.Mvvm.ComponentModel;
using FreeSql.DataAnnotations;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using System.Collections.ObjectModel;

namespace DofGMTool.Models;

// 小项目就直接单表存储了
[Table(Name = "Equipments")]
public partial class Equipments : ObservableObject
{
    [ObservableProperty]
    public partial EquipSlotModel? EquipSlot { get; set; }
    public string Id { get; set; } = Guid.NewGuid().ToString("n");

    [ObservableProperty]
    [Column(IsIgnore = true)]
    public partial BitmapImage? BitMap { get; set; }

    [ObservableProperty]
    public partial float PartsetIndex { get; set; }

    [ObservableProperty]
    public partial string PartsetItemArr { get; set; }

    /// <summary>
    /// 套装名称，这里是例如传承装备一类的套装名称，在etc文件中不存在的
    /// </summary>
    [ObservableProperty]
    public partial string SetName { get; set; }

    //[ObservableProperty]
    [Navigate(nameof(PartsetIndex))]
    public /*partial*/ EquipmentPartset? EquipmentPartset { get; set; }

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
    /// 装备描述
    /// </summary>
    [ObservableProperty]
    public partial string? DetailDescription
    {
        get; set;
    }
    /// <summary>
    /// 趣味文本
    /// </summary>
    [ObservableProperty]
    public partial string? FlavorText
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

    [Column(Name = "ItemRarityColor")]
    public string? ItemRarityColor
    {
        get => ItemRarity?.Color?.Color.ToString();
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (ItemRarity == null)
                {
                    ItemRarity = new RarityOption { Color = new SolidColorBrush(ColorHelper.FromArgb(value)) };
                }
                else
                {
                    ItemRarity.Color = new SolidColorBrush(ColorHelper.FromArgb(value));
                }
            }
        }
    }

    [ObservableProperty]
    public partial float Grade
    {
        get; set;
    }

    [ObservableProperty]
    public partial float MinimumLevel
    {
        get; set;
    }

    [ObservableProperty]
    public partial float MagicalAttack
    {
        get; set;
    }
    [ObservableProperty]
    public partial float PhysicalAttack
    {
        get; set;
    }

    [ObservableProperty]
    public partial float? CastSpeed
    {
        get; set;
    }
    [ObservableProperty]
    public partial float? AttackSpeed
    {
        get; set;
    }
    [ObservableProperty]
    public partial float? MoveSpeed
    {
        get; set;
    }
    [ObservableProperty]
    public partial float? HpMax
    {
        get; set;
    }
    [ObservableProperty]
    public partial float? Stuck
    {
        get; set;
    }
    [ObservableProperty]
    public partial float? MpMax
    {
        get; set;
    }

    [ObservableProperty]
    public partial float Price
    {
        get; set;
    }

    [ObservableProperty]
    public partial float? EquipmentPhysicalAttack
    {
        get; set;
    }

    [ObservableProperty]
    public partial float? EquipmentMagicalAttack
    {
        get; set;
    }

    [ObservableProperty]
    public partial float? SeparateAttack
    {
        get; set;
    }

    [ObservableProperty]
    public partial float MagicalCriticalHit
    {
        get; set;
    }


    [ObservableProperty]
    public partial float PhysicalCriticalHit
    {
        get; set;
    }

    [ObservableProperty]
    public partial string? EquipmentType
    {
        get; set;
    }

    [ObservableProperty]
    public partial float Weight
    {
        get; set;
    }

    [ObservableProperty]
    public partial float? EquipmentPhysicalDefense
    {
        get; set;
    }

    [ObservableProperty]
    public partial float? EquipmentMagicDefense
    {
        get; set;
    }

    [ObservableProperty]
    public partial float MagicalDefense
    {
        get; set;
    }

    [ObservableProperty]
    public partial float PhysicalDefense
    {
        get; set;
    }

    [ObservableProperty]
    public partial string? UsableJob
    {
        get; set;
    }
    [ObservableProperty]
    public partial string? LightAttack
    {
        get; set;
    }
    [ObservableProperty]
    public partial string? FireAttack
    {
        get; set;
    }
    [ObservableProperty]
    public partial string? WaterAttack
    {
        get; set;
    }
    [ObservableProperty]
    public partial string? DarkAttack
    {
        get; set;
    }

    [ObservableProperty]
    public partial string? AttachType
    {
        get; set;
    }

    [ObservableProperty]
    public partial string? SubType
    {
        get; set;
    }

    [ObservableProperty]
    public partial float Durability
    {
        get; set;
    }

    [ObservableProperty]
    public partial string? ItemGroupName
    {
        get; set;
    }

    [ObservableProperty]
    public partial string? ElementalProperty
    {
        get; set;
    }

    [ObservableProperty]
    public partial string? SkillLevelUp { get; set; }
    [ObservableProperty]
    public partial ObservableCollection<SkillLevelUpInfo>? SkillLevelList { get; set; }

    [ObservableProperty]
    public partial ObservableCollection<SkillInfo>? Skill { get; set; }
}

public static class ColorHelper
{
    public static Windows.UI.Color FromArgb(string? hex)
    {
        if (string.IsNullOrEmpty(hex))
        {
            throw new ArgumentNullException(nameof(hex), "Hex color code cannot be null or empty.");
        }

        hex = hex.Replace("#", string.Empty);
        byte a = 255;
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

        if (hex.Length == 8)
        {
            a = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            r = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            g = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            b = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
        }

        return Windows.UI.Color.FromArgb(a, r, g, b);
    }
}
