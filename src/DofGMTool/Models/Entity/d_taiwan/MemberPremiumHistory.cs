using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "member_premium_history", DisableSyncStructure = true)]
public partial class MemberPremiumHistory
{

    [JsonProperty, Column(Name = "event_id", IsPrimary = true)]
    public int EventId { get; set; } = 0;

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "pre_type", IsPrimary = true)]
    public byte PreType { get; set; } = 0;

    [JsonProperty, Column(Name = "service_start", DbType = "datetime", IsPrimary = true, InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime ServiceStart { get; set; }

    [JsonProperty, Column(Name = "service_end", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime ServiceEnd { get; set; }

}
