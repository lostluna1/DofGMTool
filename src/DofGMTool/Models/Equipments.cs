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
    public partial int Grade
    {
        get; set;
    }

    [ObservableProperty]
    public partial int MinimumLevel
    {
        get; set;
    }

    [ObservableProperty]
    public partial int MagicalAttack
    {
        get; set;
    }
    [ObservableProperty]
    public partial int PhysicalAttack
    {
        get; set;
    }

    [ObservableProperty]
    public partial int? CastSpeed
    {
        get; set;
    }
    [ObservableProperty]
    public partial int? AttackSpeed
    {
        get; set;
    }
    [ObservableProperty]
    public partial int? MoveSpeed
    {
        get; set;
    }
    [ObservableProperty]
    public partial int? HpMax
    {
        get; set;
    }
    [ObservableProperty]
    public partial int? Stuck
    {
        get; set;
    }
    [ObservableProperty]
    public partial int? MpMax
    {
        get; set;
    }

    [ObservableProperty]
    public partial int Price
    {
        get; set;
    }

    [ObservableProperty]
    public partial int? EquipmentPhysicalAttack
    {
        get; set;
    }

    [ObservableProperty]
    public partial int? EquipmentMagicalAttack
    {
        get; set;
    }

    [ObservableProperty]
    public partial int? SeparateAttack
    {
        get; set;
    }

    [ObservableProperty]
    public partial int MagicalCriticalHit
    {
        get; set;
    }


    [ObservableProperty]
    public partial int PhysicalCriticalHit
    {
        get; set;
    }

    [ObservableProperty]
    public partial string? EquipmentType
    {
        get; set;
    }

    [ObservableProperty]
    public partial int Weight
    {
        get; set;
    }

    [ObservableProperty]
    public partial int? EquipmentPhysicalDefense
    {
        get; set;
    }

    [ObservableProperty]
    public partial int? EquipmentMagicDefense
    {
        get; set;
    }

    [ObservableProperty]
    public partial int MagicalDefense
    {
        get; set;
    }

    [ObservableProperty]
    public partial int PhysicalDefense
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
    public partial int Durability
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
