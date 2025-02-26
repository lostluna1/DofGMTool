using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "check_pick_up_random_option_item", DisableSyncStructure = true)]
public partial class CheckPickUpRandomOptionItem
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public uint MId { get; set; } = 0;

    [JsonProperty, Column(Name = "check_count")]
    public byte CheckCount { get; set; } = 0;

}
