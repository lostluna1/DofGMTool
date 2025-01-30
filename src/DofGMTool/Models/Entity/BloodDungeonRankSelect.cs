using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "blood_dungeon_rank_select", DisableSyncStructure = true)]
public partial class BloodDungeonRankSelect
{

    [JsonProperty, Column(Name = "max_amount", IsPrimary = true)]
    public long MaxAmount { get; set; } = 0;

    [JsonProperty, Column(Name = "min_amount", IsPrimary = true)]
    public long MinAmount { get; set; } = 0;

    [JsonProperty, Column(Name = "rank", IsPrimary = true)]
    public byte Rank { get; set; } = 0;

    [JsonProperty, Column(Name = "reward_gold")]
    public uint RewardGold { get; set; } = 0;

    [JsonProperty, Column(Name = "reward_item_id")]
    public uint RewardItemId { get; set; } = 0;

    [JsonProperty, Column(Name = "winner_count")]
    public uint WinnerCount { get; set; } = 0;

}
