using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "event_levelup_support", DisableSyncStructure = true)]
public partial class EventLevelupSupport
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public int CharacNo { get; set; }

    [JsonProperty, Column(Name = "level", IsPrimary = true)]
    public int Level { get; set; }

    [JsonProperty, Column(Name = "state")]
    public int? State { get; set; }

}
