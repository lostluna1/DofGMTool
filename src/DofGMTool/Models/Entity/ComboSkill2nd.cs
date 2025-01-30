using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "combo_skill_2nd", DisableSyncStructure = true)]
public partial class ComboSkill2nd
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public uint CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "combo_idx", IsPrimary = true)]
    public uint ComboIdx { get; set; } = 0;

    [JsonProperty, Column(Name = "value1")]
    public ushort Value1 { get; set; } = 0;

    [JsonProperty, Column(Name = "value2")]
    public ushort Value2 { get; set; } = 0;

    [JsonProperty, Column(Name = "value3")]
    public ushort Value3 { get; set; } = 0;

    [JsonProperty, Column(Name = "value4")]
    public ushort Value4 { get; set; } = 0;

    [JsonProperty, Column(Name = "value5")]
    public ushort Value5 { get; set; } = 0;

    [JsonProperty, Column(Name = "value6")]
    public ushort Value6 { get; set; } = 0;

}
