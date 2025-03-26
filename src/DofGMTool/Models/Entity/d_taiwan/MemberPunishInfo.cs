using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "member_punish_info", DisableSyncStructure = true)]
public partial class MemberPunishInfo
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "punish_type", IsPrimary = true)]
    public int PunishType { get; set; } = 0;

    [JsonProperty, Column(Name = "admin_id", StringLength = 25, IsNullable = false)]
    public string? AdminId { get; set; }

    [JsonProperty, Column(Name = "apply_flag", DbType = "tinyint(4)")]
    public sbyte ApplyFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "end_time", DbType = "datetime")]
    public DateTime EndTime { get; set; }

    [JsonProperty, Column(Name = "occ_time", DbType = "datetime")]
    public DateTime OccTime { get; set; }

    [JsonProperty, Column(Name = "punish_value")]
    public int PunishValue { get; set; } = 0;

    [JsonProperty, Column(Name = "reason", StringLength = 100, IsNullable = false)]
    public string? Reason { get; set; }

    [JsonProperty, Column(Name = "start_time", DbType = "datetime")]
    public DateTime StartTime { get; set; }

}
