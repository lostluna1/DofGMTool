using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "auto_market_condition_ctrl", DisableSyncStructure = true)]
public partial class AutoMarketConditionCtrl
{

    [JsonProperty, Column(Name = "optimum_gold_supply")]
    public ulong OptimumGoldSupply { get; set; } = 0;

    [JsonProperty, Column(Name = "over_gold")]
    public ulong OverGold { get; set; } = 0;

}
