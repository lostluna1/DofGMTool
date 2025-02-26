using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "member_security_card_history", DisableSyncStructure = true)]
public partial class MemberSecurityCardHistory
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "occ_time", DbType = "datetime", IsPrimary = true, InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime OccTime { get; set; }

    [JsonProperty, Column(Name = "modify_type", DbType = "tinyint(4)")]
    public sbyte ModifyType { get; set; } = 0;

}
