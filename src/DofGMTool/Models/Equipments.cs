using CommunityToolkit.Mvvm.ComponentModel;
using FreeSql.DataAnnotations;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;

namespace DofGMTool.Models;

// 小项目就直接单表存储了
[Table(Name = "Equipments")]
public partial class Equipments : ObservableObject
{
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
