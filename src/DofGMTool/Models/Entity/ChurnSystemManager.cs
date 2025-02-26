using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "churn_system_manager", DisableSyncStructure = true)]
public partial class ChurnSystemManager
{

    [JsonProperty, Column(Name = "no", IsPrimary = true, IsIdentity = true)]
    public uint No { get; set; }

    [JsonProperty, Column(Name = "admin_id")]
    public uint AdminId { get; set; } = 0;

    [JsonProperty, Column(Name = "next_reward_day")]
    public int NextRewardDay { get; set; } = 0;

    [JsonProperty, Column(Name = "reg_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime RegTime { get; set; }

    [JsonProperty, Column(Name = "state_flag", DbType = "tinyint(4)")]
    public sbyte StateFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "weekday_var_a")]
    public int WeekdayVarA { get; set; } = 0;

    [JsonProperty, Column(Name = "weekday_var_b")]
    public int WeekdayVarB { get; set; } = 0;

    [JsonProperty, Column(Name = "weekday_var_c")]
    public int WeekdayVarC { get; set; } = 0;

    [JsonProperty, Column(Name = "weekend_var_x")]
    public int WeekendVarX { get; set; } = 0;

    [JsonProperty, Column(Name = "weekend_var_y")]
    public int WeekendVarY { get; set; } = 0;

    [JsonProperty, Column(Name = "weekend_var_z")]
    public int WeekendVarZ { get; set; } = 0;

}
