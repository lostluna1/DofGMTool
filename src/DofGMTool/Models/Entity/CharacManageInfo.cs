using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_manage_info", DisableSyncStructure = true)]
public partial class CharacManageInfo
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public uint CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "max_equip_level")]
    public ushort MaxEquipLevel { get; set; } = 0;

    [JsonProperty, Column(Name = "striker_skill_index")]
    public byte StrikerSkillIndex { get; set; } = 0;

    [JsonProperty, Column(Name = "tag_charac_no")]
    public uint TagCharacNo { get; set; } = 0;

}
