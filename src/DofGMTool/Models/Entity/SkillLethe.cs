using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "skill_lethe", DisableSyncStructure = true)]
public partial class SkillLethe
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "flag", DbType = "tinyint(4)")]
    public sbyte Flag { get; set; } = 0;

    [JsonProperty, Column(Name = "skill_slot", DbType = "blob")]
    public byte[] SkillSlot { get; set; }

}
