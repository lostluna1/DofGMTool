using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "dnf_event_info", DisableSyncStructure = true)]
public partial class DnfEventInfo
{

    [JsonProperty, Column(Name = "event_id", IsPrimary = true)]
    public int EventId { get; set; } = 0;

    [JsonProperty, Column(Name = "apply_type", DbType = "tinyint(4)")]
    public sbyte ApplyType { get; set; } = 0;

    [JsonProperty, Column(Name = "end_date", DbType = "date", InsertValueSql = "0000-00-00")]
    public DateTime EndDate { get; set; }

    [JsonProperty, Column(Name = "event_explain", StringLength = 100, IsNullable = false)]
    public string EventExplain { get; set; }

    [JsonProperty, Column(Name = "event_name", StringLength = 30, IsNullable = false)]
    public string EventName { get; set; }

    [JsonProperty, Column(Name = "start_date", DbType = "date", InsertValueSql = "0000-00-00")]
    public DateTime StartDate { get; set; }

}
