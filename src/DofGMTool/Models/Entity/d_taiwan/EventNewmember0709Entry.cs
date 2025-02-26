using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "event_newmember0709_entry", DisableSyncStructure = true)]
public partial class EventNewmember0709Entry
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "charac_no")]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "item1_check", DbType = "int(11) unsigned")]
    public uint Item1Check { get; set; } = 0;

    [JsonProperty, Column(Name = "item1_no", DbType = "int(11) unsigned")]
    public uint Item1No { get; set; } = 0;

    [JsonProperty, Column(Name = "item2_check", DbType = "int(11) unsigned")]
    public uint Item2Check { get; set; } = 0;

    [JsonProperty, Column(Name = "item2_no", DbType = "int(11) unsigned")]
    public uint Item2No { get; set; } = 0;

    [JsonProperty, Column(Name = "occ_date", DbType = "int(11) unsigned")]
    public uint OccDate { get; set; } = 0;

    [JsonProperty, Column(Name = "server_id", DbType = "tinyint(4)")]
    public sbyte ServerId { get; set; } = 0;

}
