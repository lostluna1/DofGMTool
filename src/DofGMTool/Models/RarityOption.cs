using Microsoft.UI;
using Microsoft.UI.Xaml.Media;

namespace DofGMTool.Models;
public class RarityOption
{
    public string? Name
    {
        get; set;
    }
    public SolidColorBrush? Color
    {
        get; set;
    }
    /// <summary>
    /// 普通
    /// </summary>
    public static readonly RarityOption Common = new() { Name = "普通", Color = new SolidColorBrush(Colors.Gray) };

    /// <summary>
    /// 高级
    /// </summary>
    public static readonly RarityOption Rare = new() { Name = "高级", Color = new SolidColorBrush(Colors.LightSkyBlue) };

    /// <summary>
    /// 稀有
    /// </summary>
    public static readonly RarityOption Epic = new() { Name = "稀有", Color = new SolidColorBrush(Colors.MediumPurple) };

    /// <summary>
    /// 史诗
    /// </summary>
    public static readonly RarityOption Legendary = new() { Name = "史诗", Color = new SolidColorBrush(Colors.Orange) };

    /// <summary>
    /// 传说
    /// </summary>
    public static readonly RarityOption Artifact = new() { Name = "传说", Color = new SolidColorBrush(Colors.Red) };

    /// <summary>
    /// 神器
    /// </summary>
    public static readonly RarityOption God = new() { Name = "神器", Color = new SolidColorBrush(Colors.DeepPink) };



}
