using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "limit_create_character_ip", DisableSyncStructure = true)]
public partial class LimitCreateCharacterIp
{

    [JsonProperty, Column(Name = "ip", DbType = "int(11) unsigned", IsPrimary = true)]
    public uint Ip { get; set; } = 0;

    [JsonProperty, Column(Name = "count", DbType = "int(11) unsigned")]
    public uint Count { get; set; } = 0;

    [JsonProperty, Column(Name = "ip_str", DbType = "char(16)", IsNullable = false)]
    public string IpStr { get; set; }

    [JsonProperty, Column(Name = "last_access_mid", DbType = "int(11) unsigned")]
    public uint LastAccessMid { get; set; } = 0;

    [JsonProperty, Column(Name = "last_access_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime LastAccessTime { get; set; }

}
