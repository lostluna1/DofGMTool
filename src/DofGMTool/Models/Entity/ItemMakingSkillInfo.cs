using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "item_making_skill_info", DisableSyncStructure = true)]
public partial class ItemMakingSkillInfo
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public uint CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "amulet")]
    public ushort Amulet { get; set; } = 0;

    [JsonProperty, Column(Name = "cloth")]
    public ushort Cloth { get; set; } = 0;

    [JsonProperty, Column(Name = "heavy_armor")]
    public ushort HeavyArmor { get; set; } = 0;

    [JsonProperty, Column(Name = "leather")]
    public ushort Leather { get; set; } = 0;

    [JsonProperty, Column(Name = "light_armor")]
    public ushort LightArmor { get; set; } = 0;

    [JsonProperty, Column(Name = "magic_stone")]
    public ushort MagicStone { get; set; } = 0;

    [JsonProperty, Column(Name = "plate")]
    public ushort Plate { get; set; } = 0;

    [JsonProperty, Column(Name = "ring")]
    public ushort Ring { get; set; } = 0;

    [JsonProperty, Column(Name = "support")]
    public ushort Support { get; set; } = 0;

    [JsonProperty, Column(Name = "weapon")]
    public ushort Weapon { get; set; } = 0;

    [JsonProperty, Column(Name = "wrist")]
    public ushort Wrist { get; set; } = 0;

}
