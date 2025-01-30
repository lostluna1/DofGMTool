using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "event_condition_info", DisableSyncStructure = true)]
public partial class EventConditionInfo
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public uint CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "current_step")]
    public byte CurrentStep { get; set; } = 0;

    [JsonProperty, Column(Name = "reward_step")]
    public byte RewardStep { get; set; } = 0;

    [JsonProperty, Column(Name = "update_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime UpdateTime { get; set; }

}
