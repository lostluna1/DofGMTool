using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "auto_punish_hack_info", DisableSyncStructure = true)]
public partial class AutoPunishHackInfo
{

    [JsonProperty, Column(Name = "apply_flag", DbType = "tinyint(4)", IsPrimary = true)]
    public sbyte ApplyFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "hack_sub_type", IsPrimary = true)]
    public ushort HackSubType { get; set; } = 0;

    [JsonProperty, Column(Name = "hack_type", IsPrimary = true)]
    public ushort HackType { get; set; } = 0;

    [JsonProperty, Column(Name = "cnt")]
    public uint Cnt { get; set; } = 0;

    [JsonProperty, Column(Name = "etc")]
    public ulong Etc { get; set; } = 0;

    [JsonProperty, Column(Name = "hack_sub_cnt")]
    public uint HackSubCnt { get; set; } = 0;

    [JsonProperty, Column(Name = "ip_cnt")]
    public uint IpCnt { get; set; } = 0;

    [JsonProperty, Column(Name = "reg_date", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime RegDate { get; set; }

}
