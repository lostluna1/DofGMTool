using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "member_mousepass_history_201506", DisableSyncStructure = true)]
public partial class MemberMousepassHistory201506
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "occ_time", DbType = "datetime", IsPrimary = true, InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime OccTime { get; set; }

    [JsonProperty, Column(Name = "ip_info", StringLength = 15, IsNullable = false)]
    public required string IpInfo { get; set; }

    [JsonProperty, Column(Name = "modify_type", DbType = "tinyint(4)")]
    public sbyte ModifyType { get; set; } = 0;

    [JsonProperty, Column(Name = "port_info", StringLength = 5, IsNullable = false)]
    public required string PortInfo { get; set; }

    [JsonProperty, Column(Name = "pre_mousepass", StringLength = 32, IsNullable = false)]
    public required string PreMousepass { get; set; }

}
