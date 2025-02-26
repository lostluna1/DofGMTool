using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "event_server_message", DisableSyncStructure = true)]
public partial class EventServerMessage
{

    [JsonProperty, Column(Name = "channel_no", DbType = "tinyint(4) unsigned")]
    public byte ChannelNo { get; set; } = 0;

    [JsonProperty, Column(Name = "charac_name", DbType = "char(64)", IsNullable = false)]
    public string CharacName { get; set; }

    [JsonProperty, Column(Name = "kind", DbType = "char(1)", IsNullable = false)]
    public string Kind { get; set; }

    [JsonProperty, Column(Name = "message", DbType = "char(128)", IsNullable = false)]
    public string Message { get; set; }

    [JsonProperty, Column(Name = "message_index", DbType = "char(1)", IsNullable = false)]
    public string MessageIndex { get; set; }

    [JsonProperty, Column(Name = "server_info", DbType = "tinyint(4) unsigned")]
    public byte ServerInfo { get; set; } = 0;

    [JsonProperty, Column(Name = "update_time")]
    public uint UpdateTime { get; set; } = 0;

}
