using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "limit_npc_item", DisableSyncStructure = true)]
public partial class LimitNpcItem
{

    [JsonProperty, Column(Name = "item_index", IsPrimary = true)]
    public uint ItemIndex { get; set; } = 0;

    [JsonProperty, Column(Name = "max_count")]
    public uint MaxCount { get; set; } = 0;

    [JsonProperty, Column(Name = "sell_count")]
    public uint SellCount { get; set; } = 0;

}
