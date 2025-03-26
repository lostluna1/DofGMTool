using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "member_broadcast", DisableSyncStructure = true)]
public partial class MemberBroadcast
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "event_id", IsPrimary = true)]
    public int EventId { get; set; } = 0;

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "server_id", DbType = "tinyint(4)", IsPrimary = true)]
    public sbyte ServerId { get; set; } = 0;

    [JsonProperty, Column(Name = "start_time", DbType = "datetime", IsPrimary = true, InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime StartTime { get; set; }

    [JsonProperty, Column(Name = "charac_name", StringLength = 20, IsNullable = false)]
    public required string CharacName { get; set; }

    [JsonProperty, Column(Name = "end_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime EndTime { get; set; }

}
