using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "churn_member_info", DisableSyncStructure = true)]
public partial class ChurnMemberInfo
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public uint MId { get; set; } = 0;

    [JsonProperty, Column(Name = "accrue_cera")]
    public uint AccrueCera { get; set; } = 0;

    [JsonProperty, Column(Name = "add_info", DbType = "tinyint(4)")]
    public sbyte AddInfo { get; set; } = 0;

    [JsonProperty, Column(Name = "charac_no")]
    public uint CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "first_reward_time")]
    public uint FirstRewardTime { get; set; } = 0;

    [JsonProperty, Column(Name = "item_id")]
    public uint ItemId { get; set; } = 0;

    [JsonProperty, Column(Name = "last_reward_time")]
    public uint LastRewardTime { get; set; } = 0;

    [JsonProperty, Column(Name = "last_update_time")]
    public uint LastUpdateTime { get; set; } = 0;

    [JsonProperty, Column(Name = "luck_point")]
    public uint LuckPoint { get; set; } = 0;

    [JsonProperty, Column(Name = "play_info", DbType = "char(30)", IsNullable = false)]
    public string PlayInfo { get; set; }

    [JsonProperty, Column(Name = "quest_time")]
    public uint QuestTime { get; set; } = 0;

    [JsonProperty, Column(Name = "second_reward_time")]
    public uint SecondRewardTime { get; set; } = 0;

    [JsonProperty, Column(Name = "server_id", DbType = "tinyint(4)")]
    public sbyte ServerId { get; set; } = 0;

}
