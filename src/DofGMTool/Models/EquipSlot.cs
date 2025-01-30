using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Media.Imaging;

namespace DofGMTool.Models;

public partial class EquipSlotModel : ObservableObject
{
    /// <summary>
    /// 封装/魔法封印
    /// </summary>
    [ObservableProperty]
    public partial ulong Enchantment { get; set; }

    /// <summary>
    /// 类型:1装备 8时装
    /// </summary>
    [ObservableProperty]
    public partial ulong Type { get; set; }

    /// <summary>
    /// 装备id
    /// </summary>
    [ObservableProperty]
    public partial ulong EquipId { get; set; }

    /// <summary>
    /// 强化等级
    /// </summary>
    [ObservableProperty]
    public partial ulong EnhancementLevel { get; set; }

    /// <summary>
    /// 装备品级
    /// </summary>
    [ObservableProperty]
    public partial ulong EquipGrade { get; set; }

    /// <summary>
    /// 耐久度
    /// </summary>
    [ObservableProperty]
    public partial ulong Durability { get; set; }

    /// <summary>
    /// 宝珠
    /// </summary>
    [ObservableProperty]
    public partial ulong Orb { get; set; }

    /// <summary>
    /// 增幅: 1体力 2精神 3力量 4智力
    /// </summary>
    [ObservableProperty]
    public partial ulong AmplificationType { get; set; }

    /// <summary>
    /// 增幅附加值 最大65536
    /// </summary>
    [ObservableProperty]
    public partial ulong AmplificationValue { get; set; }

    /// <summary>
    /// 异界气息
    /// </summary>
    [ObservableProperty]
    public partial ulong AbyssalBreath { get; set; }

    /// <summary>
    /// 魔法封印
    /// </summary>
    [ObservableProperty]
    public partial ulong MagicSeal { get; set; }

    /// <summary>
    /// 锻造等级
    /// </summary>
    [ObservableProperty]
    public partial ulong ForgingLevel { get; set; }

    /// <summary>
    /// 装备图标
    /// </summary>
    [ObservableProperty]
    public partial BitmapImage? BitMap { get; set; }
}

