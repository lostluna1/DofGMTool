using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "max_count_channel", DisableSyncStructure = true)]
public partial class MaxCountChannel
{

    [JsonProperty, Column(Name = "gc_channeltype", StringLength = 25, IsNullable = false)]
    public string GcChanneltype { get; set; }

    [JsonProperty, Column(Name = "mc_date", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime McDate { get; set; }

    [JsonProperty, Column(Name = "mc_max", DbType = "int(11) unsigned")]
    public uint McMax { get; set; } = 0;

    [JsonProperty, Column(Name = "server_info")]
    public byte ServerInfo { get; set; } = 0;

}
