using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "skill_index", DisableSyncStructure = true)]
public partial class SkillIndex
{

    [JsonProperty, Column(Name = "no", IsPrimary = true, IsIdentity = true)]
    public int No { get; set; }

    [JsonProperty, Column(Name = "job", DbType = "mediumint(9)")]
    public int Job { get; set; } = 100;

    [JsonProperty, Column(Name = "skill_idx", DbType = "mediumint(9)")]
    public int SkillIdx { get; set; } = 0;

    [JsonProperty, Column(Name = "skill_name", StringLength = 30, IsNullable = false)]
    public string SkillName { get; set; }

}
