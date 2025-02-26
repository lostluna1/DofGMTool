using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "auto_punish_first_user", DisableSyncStructure = true)]
public partial class AutoPunishFirstUser
{

    [JsonProperty, Column(Name = "hack_sub_type", IsPrimary = true)]
    public ushort HackSubType { get; set; } = 0;

    [JsonProperty, Column(Name = "hack_type", IsPrimary = true)]
    public ushort HackType { get; set; } = 0;

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "cnt")]
    public uint Cnt { get; set; } = 0;

    [JsonProperty, Column(Name = "hack_sub_cnt")]
    public uint HackSubCnt { get; set; } = 0;

    [JsonProperty, Column(Name = "ip", StringLength = 15, IsNullable = false)]
    public string Ip { get; set; }

    [JsonProperty, Column(Name = "occ_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime OccTime { get; set; }

    [JsonProperty, Column(Name = "punish_flag", DbType = "tinyint(4)")]
    public sbyte PunishFlag { get; set; } = 0;

}
