using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "member_punish_hack", DisableSyncStructure = true)]
public partial class MemberPunishHack
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public uint MId { get; set; } = 0;

    [JsonProperty, Column(Name = "auto_flag", DbType = "tinyint(4)")]
    public sbyte AutoFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "hack_ip", StringLength = 15, IsNullable = false)]
    public string HackIp { get; set; }

    [JsonProperty, Column(Name = "now_flag", DbType = "tinyint(4)")]
    public sbyte NowFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "occ_time")]
    public uint OccTime { get; set; } = 0;

    [JsonProperty, Column(Name = "period")]
    public uint Period { get; set; } = 0;

    [JsonProperty, Column(Name = "reason", StringLength = 250, IsNullable = false)]
    public string Reason { get; set; }

}
