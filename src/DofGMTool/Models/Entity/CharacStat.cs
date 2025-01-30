using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_stat", DisableSyncStructure = true)]
public partial class CharacStat
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "add_equipslot_flag", DbType = "tinyint(4)")]
    public sbyte AddEquipslotFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "add_slot_flag", DbType = "tinyint(4) unsigned")]
    public byte AddSlotFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "assault_count")]
    public uint AssaultCount { get; set; } = 0;

    [JsonProperty, Column(Name = "birthday_effect_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime? BirthdayEffectTime { get; set; }

    [JsonProperty, Column(Name = "channel_equipslot_switch", DbType = "tinyint(4)")]
    public sbyte ChannelEquipslotSwitch { get; set; } = 0;

    [JsonProperty, Column(Name = "chaos_die_count")]
    public uint ChaosDieCount { get; set; } = 0;

    [JsonProperty, Column(Name = "chaos_die_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime ChaosDieTime { get; set; }

    [JsonProperty, Column(Name = "chaos_exp")]
    public uint ChaosExp { get; set; } = 0;

    [JsonProperty, Column(Name = "chaos_kill_count")]
    public uint ChaosKillCount { get; set; } = 0;

    [JsonProperty, Column(Name = "chaos_kill_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime ChaosKillTime { get; set; }

    [JsonProperty, Column(Name = "chaos_mode_count")]
    public uint ChaosModeCount { get; set; } = 0;

    [JsonProperty, Column(Name = "chaos_point")]
    public uint ChaosPoint { get; set; } = 0;

    [JsonProperty, Column(Name = "chaos_respon_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime ChaosResponTime { get; set; }

    [JsonProperty, Column(Name = "dungeon_clear_point")]
    public int DungeonClearPoint { get; set; } = 0;

    [JsonProperty, Column(Name = "dungeon_map_help_pass_cnt")]
    public uint DungeonMapHelpPassCnt { get; set; } = 0;

    [JsonProperty, Column(Name = "dungeon_map_pass_cnt")]
    public uint DungeonMapPassCnt { get; set; } = 0;

    [JsonProperty, Column(Name = "dungeon_play_count")]
    public uint DungeonPlayCount { get; set; } = 0;

    [JsonProperty, Column(Name = "emotion")]
    public ushort Emotion { get; set; } = 0;

    [JsonProperty, Column(Name = "escalade_tutorial_flag", StringLength = 32, IsNullable = false)]
    public string EscaladeTutorialFlag { get; set; }

    [JsonProperty, Column(Name = "exp")]
    public int Exp { get; set; } = 0;

    [JsonProperty, Column(Name = "expand_equipslot_switch", DbType = "tinyint(4)")]
    public sbyte ExpandEquipslotSwitch { get; set; } = 0;

    [JsonProperty, Column(Name = "expert_job_exp")]
    public int ExpertJobExp { get; set; } = 0;

    [JsonProperty, Column(Name = "fatigue", DbType = "smallint(11)")]
    public short Fatigue { get; set; } = 0;

    [JsonProperty, Column(Name = "fatigue_battery_charging")]
    public int FatigueBatteryCharging { get; set; } = 0;

    [JsonProperty, Column(Name = "fatigue_grownup_buff")]
    public uint FatigueGrownupBuff { get; set; } = 0;

    [JsonProperty, Column(Name = "forbidden_due_to", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime ForbiddenDueTo { get; set; }

    [JsonProperty, Column(Name = "forbidden_to_play", DbType = "char(1)", IsNullable = false)]
    public string ForbiddenToPlay { get; set; }

    [JsonProperty, Column(Name = "growth_power_reward", DbType = "tinyint(4)")]
    public sbyte GrowthPowerReward { get; set; } = 0;

    [JsonProperty, Column(Name = "help_abuse_exp", DbType = "int(10)")]
    public int HelpAbuseExp { get; set; } = 0;

    [JsonProperty, Column(Name = "help_abuse_point")]
    public uint HelpAbusePoint { get; set; } = 0;

    [JsonProperty, Column(Name = "help_abuse_ratio", DbType = "int(10)")]
    public int HelpAbuseRatio { get; set; } = 0;

    [JsonProperty, Column(DbType = "tinyint(4) unsigned")]
    public byte HP { get; set; } = 0;

    [JsonProperty, Column(Name = "last_play_dungeon_index")]
    public uint LastPlayDungeonIndex { get; set; } = 0;

    [JsonProperty, Column(Name = "last_play_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime LastPlayTime { get; set; }

    [JsonProperty, Column(Name = "last_play_time_powerwar", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime LastPlayTimePowerwar { get; set; }

    [JsonProperty, Column(Name = "luck_point")]
    public int LuckPoint { get; set; } = 5000;

    [JsonProperty, Column(Name = "member_bonus_fatigue")]
    public byte MemberBonusFatigue { get; set; } = 0;

    [JsonProperty, Column(Name = "member_dungeon_flag", DbType = "tinyint(4) unsigned")]
    public byte MemberDungeonFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "open_flag", DbType = "tinyint(4)")]
    public sbyte OpenFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "power_war_assault_count")]
    public uint PowerWarAssaultCount { get; set; } = 0;

    [JsonProperty, Column(Name = "power_war_assault_victory_count")]
    public uint PowerWarAssaultVictoryCount { get; set; } = 0;

    [JsonProperty, Column(Name = "power_war_point")]
    public ushort PowerWarPoint { get; set; } = 0;

    [JsonProperty, Column(Name = "premium_fatigue", DbType = "smallint(11)")]
    public short PremiumFatigue { get; set; } = 0;

    [JsonProperty, Column(Name = "total_play_time")]
    public uint TotalPlayTime { get; set; } = 0;

    [JsonProperty, Column(Name = "trade_gold_daily")]
    public uint TradeGoldDaily { get; set; } = 0;

    [JsonProperty, Column(Name = "trade_gold_total")]
    public uint TradeGoldTotal { get; set; } = 0;

    [JsonProperty, Column(Name = "trade_gold_total_billion")]
    public ushort TradeGoldTotalBillion { get; set; } = 0;

    [JsonProperty, Column(Name = "tutorial_flag")]
    public int TutorialFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "used_fatigue", DbType = "smallint(11)")]
    public short UsedFatigue { get; set; } = 0;

    [JsonProperty, Column(Name = "village", DbType = "tinyint(4)")]
    public sbyte Village { get; set; } = 1;

    [JsonProperty, Column(Name = "village_prev", DbType = "tinyint(4)")]
    public sbyte VillagePrev { get; set; } = 1;

    [JsonProperty, Column(Name = "visible_flags", DbType = "tinyint(4) unsigned")]
    public byte VisibleFlags { get; set; } = 2;

}
