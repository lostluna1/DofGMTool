using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "pvp_result", DisableSyncStructure = true)]
public partial class PvpResult
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "avg_aerial_count")]
    public int AvgAerialCount { get; set; } = 0;

    [JsonProperty, Column(Name = "avg_attacked_count")]
    public int AvgAttackedCount { get; set; } = 0;

    [JsonProperty, Column(Name = "avg_back_atk_count")]
    public int AvgBackAtkCount { get; set; } = 0;

    [JsonProperty, Column(Name = "avg_buf_count")]
    public int AvgBufCount { get; set; } = 0;

    [JsonProperty, Column(Name = "avg_combo_count")]
    public int AvgComboCount { get; set; } = 0;

    [JsonProperty, Column(Name = "avg_counter_count")]
    public int AvgCounterCount { get; set; } = 0;

    [JsonProperty, Column(Name = "avg_deal_damage")]
    public int AvgDealDamage { get; set; } = 0;

    [JsonProperty, Column(Name = "avg_debuf_count")]
    public int AvgDebufCount { get; set; } = 0;

    [JsonProperty, Column(Name = "avg_heal_count")]
    public int AvgHealCount { get; set; } = 0;

    [JsonProperty, Column(Name = "avg_hit_penalty")]
    public int AvgHitPenalty { get; set; } = 0;

    [JsonProperty, Column(Name = "avg_kill_count")]
    public int AvgKillCount { get; set; } = 0;

    [JsonProperty, Column(Name = "avg_overkill_count")]
    public int AvgOverkillCount { get; set; } = 0;

    [JsonProperty, Column(Name = "avg_style")]
    public int AvgStyle { get; set; } = 0;

    [JsonProperty, Column(Name = "avg_technic")]
    public int AvgTechnic { get; set; } = 0;

    [JsonProperty, Column(Name = "avg_union_hit_count")]
    public int AvgUnionHitCount { get; set; } = 0;

    [JsonProperty, Column(Name = "last_play_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime LastPlayTime { get; set; }

    [JsonProperty, Column(Name = "lose")]
    public int Lose { get; set; } = 0;

    [JsonProperty, Column(Name = "play_count")]
    public uint PlayCount { get; set; } = 0;

    [JsonProperty, Column(Name = "play_time")]
    public uint PlayTime { get; set; } = 0;

    [JsonProperty, Column(Name = "pvp_count")]
    public int PvpCount { get; set; } = 0;

    [JsonProperty, Column(Name = "pvp_grade")]
    public int PvpGrade { get; set; } = 0;

    [JsonProperty, Column(Name = "pvp_grade_ext")]
    public byte PvpGradeExt { get; set; } = 0;

    [JsonProperty, Column(Name = "pvp_grade_ext_update_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime PvpGradeExtUpdateTime { get; set; }

    [JsonProperty, Column(Name = "pvp_point")]
    public int PvpPoint { get; set; } = 0;

    [JsonProperty, Column(Name = "win")]
    public int Win { get; set; } = 0;

    [JsonProperty, Column(Name = "win_point")]
    public int WinPoint { get; set; } = 0;

}
