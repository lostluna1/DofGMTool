using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "member_miles", DisableSyncStructure = true)]
public partial class MemberMiles
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "daily_miles")]
    public short DailyMiles { get; set; } = 0;

    [JsonProperty, Column(Name = "miles")]
    public int Miles { get; set; } = 0;

}
