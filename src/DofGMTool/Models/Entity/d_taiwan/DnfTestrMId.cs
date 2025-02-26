using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "dnf_testr_m_id", DisableSyncStructure = true)]
public partial class DnfTestrMId
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "sex", DbType = "tinyint(4)")]
    public sbyte Sex { get; set; } = 0;

}
