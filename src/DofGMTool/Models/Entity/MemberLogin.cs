using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "member_login", DisableSyncStructure = true)]
public partial class MemberLogin
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "account_fail", DbType = "tinyint(4)")]
    public sbyte AccountFail { get; set; } = 0;

    [JsonProperty, Column(Name = "cleanpad_point")]
    public uint CleanpadPoint { get; set; } = 0;

    [JsonProperty, Column(Name = "dungeon_gain_gold")]
    public uint DungeonGainGold { get; set; } = 0;

    [JsonProperty, Column(Name = "event_charac_flag")]
    public byte EventCharacFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "expire_time")]
    public uint ExpireTime { get; set; } = 0;

    [JsonProperty, Column(Name = "garena_token_key")]
    public long GarenaTokenKey { get; set; } = 0;

    [JsonProperty, Column(Name = "gift_cnt")]
    public ushort GiftCnt { get; set; } = 0;

    [JsonProperty, Column(Name = "last_gift_time")]
    public uint LastGiftTime { get; set; } = 0;

    [JsonProperty, Column(Name = "last_play_time")]
    public uint LastPlayTime { get; set; } = 0;

    [JsonProperty, Column(Name = "login_ip", StringLength = 15, IsNullable = false)]
    public required string LoginIp { get; set; }

    [JsonProperty, Column(Name = "login_time")]
    public uint LoginTime { get; set; } = 0;

    [JsonProperty, Column(Name = "power_side", DbType = "tinyint(4)")]
    public sbyte PowerSide { get; set; } = 0;

    [JsonProperty, Column(Name = "rating")]
    public float Rating { get; set; } = 0f;

    [JsonProperty, Column(Name = "reliable_flag", DbType = "tinyint(4)")]
    public sbyte ReliableFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "report_cnt")]
    public int ReportCnt { get; set; } = 0;

    [JsonProperty, Column(Name = "school_id")]
    public int SchoolId { get; set; } = 0;

    [JsonProperty, Column(Name = "security_flag", DbType = "tinyint(4)")]
    public sbyte SecurityFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "total_account_fail")]
    public uint TotalAccountFail { get; set; } = 0;

    [JsonProperty, Column(Name = "trade_gold_daily")]
    public uint TradeGoldDaily { get; set; } = 0;

    [JsonProperty, Column(Name = "tutorial_skipable", DbType = "char(1)", IsNullable = false)]
    public string TutorialSkipable { get; set; } = "0";

}
