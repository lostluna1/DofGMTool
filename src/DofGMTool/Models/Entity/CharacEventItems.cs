using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_event_items", DisableSyncStructure = true)]
public partial class CharacEventItems
{

    [JsonProperty, Column(Name = "id", IsPrimary = true, IsIdentity = true)]
    public int Id { get; set; }

    [JsonProperty, Column(Name = "charac_no")]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "delete_flag", DbType = "tinyint(4)")]
    public sbyte DeleteFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "delete_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime DeleteTime { get; set; }

    [JsonProperty, Column(Name = "event_code")]
    public int EventCode { get; set; } = 0;

    [JsonProperty, Column(Name = "it_id")]
    public int ItId { get; set; } = 0;

    [JsonProperty, Column(Name = "reg_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime RegTime { get; set; }

    [JsonProperty, Column(Name = "stack_count", DbType = "int(11) unsigned")]
    public uint StackCount { get; set; } = 0;

}
