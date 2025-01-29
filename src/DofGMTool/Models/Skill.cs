using CommunityToolkit.Mvvm.ComponentModel;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models;
public partial class Skill : ObservableValidator
{
    [ObservableProperty]
    [Column(IsPrimary =true)]
    public partial string SkillId { get; set; }
    [ObservableProperty]
    public partial string Name { get; set; }
    [ObservableProperty]
    public partial string Name2 { get; set; }
    [ObservableProperty]
    public partial string Explain { get; set; }
    [ObservableProperty]
    public partial string BasicExplain { get; set; }
    [ObservableProperty]
    public partial string FeatureSkillIndex { get; set; }
    [ObservableProperty]
    public partial string PurchaseCost { get; set; }
    [ObservableProperty]
    public partial string RequiredLevel { get; set; }
    [ObservableProperty]
    public partial string RequiredLevelRange { get; set; }
    [ObservableProperty]
    public partial string Type { get; set; }
    [ObservableProperty]
    public partial string SkillClass { get; set; }
    [ObservableProperty]
    public partial string MaximumLevel { get; set; }
    [ObservableProperty]
    public partial string GrowtypeMaximumLevel { get; set; }
    [ObservableProperty]
    public partial string SkillFitnessGrowtype { get; set; }
    [ObservableProperty]
    public partial string ConsumeMP { get; set; }
    [ObservableProperty]
    public partial string CastingTime { get; set; }
    [ObservableProperty]
    public partial string CoolTime { get; set; }
    [ObservableProperty]
    public partial string DurabilityDecreaseRate { get; set; }
    [ObservableProperty]
    public partial string WeaponEffectType { get; set; }
    [ObservableProperty]
    public partial string Icon { get; set; }
    [ObservableProperty]
    public partial string Command { get; set; }
    [ObservableProperty]
    public partial string CommandKeyExplain { get; set; }
    [ObservableProperty]
    public partial string StaticData { get; set; }
    [ObservableProperty]
    public partial string LevelInfo { get; set; }
    [ObservableProperty]
    public partial string PvpCoolTime { get; set; }
    [ObservableProperty]
    public partial string PvpLevelInfo { get; set; }
    [ObservableProperty]
    public partial string LevelProperty { get; set; }
    [ObservableProperty]
    public partial string SkillPreloadingImage { get; set; }
    [ObservableProperty]
    [Column(IsPrimary =true)]
    public partial string SourceList { get; set; }
}

