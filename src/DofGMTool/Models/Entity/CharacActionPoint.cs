using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_action_point", DisableSyncStructure = true)]
public partial class CharacActionPoint
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public uint CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "occ_date", DbType = "date", IsPrimary = true, InsertValueSql = "0000-00-00")]
    public DateTime OccDate { get; set; }

    [JsonProperty, Column(Name = "ap_clear_state", DbType = "blob")]
    public byte[] ApClearState { get; set; }

    [JsonProperty, Column(Name = "ap_sum")]
    public uint ApSum { get; set; } = 0;

    [JsonProperty, Column(Name = "is_reward_item_1")]
    public byte IsRewardItem1 { get; set; } = 0;

    [JsonProperty, Column(Name = "is_reward_item_2")]
    public byte IsRewardItem2 { get; set; } = 0;

    [JsonProperty, Column(Name = "is_reward_item_3")]
    public byte IsRewardItem3 { get; set; } = 0;

    [JsonProperty, Column(Name = "is_reward_item_4")]
    public byte IsRewardItem4 { get; set; } = 0;

    [JsonProperty, Column(Name = "is_reward_medal")]
    public byte IsRewardMedal { get; set; } = 0;

}
