using CommunityToolkit.Mvvm.ComponentModel;
using DofGMTool.Enums;

namespace DofGMTool.Models;
public partial class MailModel : ObservableValidator
{
    [ObservableProperty]
    public partial List<int> CharacNo { get; set; } = new();

    [ObservableProperty]
    public partial string Title { get; set; }

    [ObservableProperty]
    public partial string Content { get; set; }

    [ObservableProperty]
    public partial int ItemId { get; set; }

    [ObservableProperty]
    public partial int Gold { get; set; }

    [ObservableProperty]
    public partial int ItemCount { get; set; } = 1;

    // EquipmentMailModel properties
    /// <summary>
    /// 强化等级
    /// </summary>
    [ObservableProperty]
    public partial int PowerUpLevel { get; set; }

    /// <summary>
    /// 锻造
    /// </summary>
    [ObservableProperty]
    public partial int Smithing { get; set; }

    /// <summary>
    /// 增幅类型
    /// </summary>
    [ObservableProperty]
    public partial IncreaseType IncreaseType { get; set; }

    /// <summary>
    /// 增幅数值
    /// </summary>
    [ObservableProperty]
    public partial int IncreaseValue { get; set; }

    [ObservableProperty]
    public partial int CreatureType { get; set; }
}

public enum MailType
{
    Stackable = 1,
    Equipment = 2,
    Creature = 3,
    Avatar = 4,
    Partset = 5
}
