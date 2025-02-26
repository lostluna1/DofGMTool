using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "event_goldcard_entry1", DisableSyncStructure = true)]
public partial class EventGoldcardEntry1
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "occ_date", IsPrimary = true)]
    public int OccDate { get; set; } = 0;

    [JsonProperty, Column(Name = "item_no", DbType = "tinyint(4)")]
    public sbyte ItemNo { get; set; } = 0;

}
