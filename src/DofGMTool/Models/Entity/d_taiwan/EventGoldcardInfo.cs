using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "event_goldcard_info", DisableSyncStructure = true)]
public partial class EventGoldcardInfo
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "coupon")]
    public ushort Coupon { get; set; } = 0;

}
