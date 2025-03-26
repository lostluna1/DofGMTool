using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "auto_punish_hack_full_ip", DisableSyncStructure = true)]
public partial class AutoPunishHackFullIp
{

    [JsonProperty, Column(Name = "full_ip", StringLength = 15, IsPrimary = true, IsNullable = false)]
    public string? FullIp { get; set; }

    [JsonProperty, Column(Name = "hack_sub_type", IsPrimary = true)]
    public ushort HackSubType { get; set; } = 0;

    [JsonProperty, Column(Name = "hack_type", IsPrimary = true)]
    public ushort HackType { get; set; } = 0;

    [JsonProperty, Column(Name = "occ_date", DbType = "date", IsPrimary = true, InsertValueSql = "0000-00-00")]
    public DateTime OccDate { get; set; }

    [JsonProperty, Column(Name = "cnt")]
    public uint Cnt { get; set; } = 0;

}
