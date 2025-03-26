using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "auto_market_condition_ctrl_change", DisableSyncStructure = true)]
public partial class AutoMarketConditionCtrlChange
{

    [JsonProperty, Column(Name = "occ_time", DbType = "date", IsPrimary = true, InsertValueSql = "0000-00-00")]
    public DateTime OccTime { get; set; }

    [JsonProperty, Column(Name = "memo", IsNullable = false)]
    public required string Memo { get; set; }

    [JsonProperty, Column(Name = "MNG_user_id", StringLength = 30, IsNullable = false)]
    public required string MNGUserId { get; set; }

    [JsonProperty, Column(Name = "over_gold_new")]
    public ulong OverGoldNew { get; set; } = 0;

    [JsonProperty, Column(Name = "over_gold_old")]
    public ulong OverGoldOld { get; set; } = 0;

    [JsonProperty, Column(Name = "total_gold_new")]
    public ulong TotalGoldNew { get; set; } = 0;

    [JsonProperty, Column(Name = "total_gold_old")]
    public ulong TotalGoldOld { get; set; } = 0;

}
