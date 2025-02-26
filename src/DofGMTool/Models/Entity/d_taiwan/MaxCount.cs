using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "max_count", DisableSyncStructure = true)]
public partial class MaxCount
{

    [JsonProperty, Column(Name = "mc_date", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime McDate { get; set; }

    [JsonProperty, Column(Name = "mc_max", DbType = "int(11) unsigned")]
    public uint McMax { get; set; } = 0;

    [JsonProperty, Column(Name = "server_info")]
    public byte ServerInfo { get; set; } = 0;

}
