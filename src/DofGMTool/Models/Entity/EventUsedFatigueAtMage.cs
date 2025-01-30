using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "event_used_fatigue_at_mage", DisableSyncStructure = true)]
public partial class EventUsedFatigueAtMage
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public uint CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "fatigue_quantity")]
    public uint FatigueQuantity { get; set; } = 0;

}
