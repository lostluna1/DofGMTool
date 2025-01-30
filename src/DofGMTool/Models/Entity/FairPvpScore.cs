using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "fair_pvp_score", DisableSyncStructure = true)]
public partial class FairPvpScore
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public uint CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "daily_play_count")]
    public uint DailyPlayCount { get; set; } = 0;

    [JsonProperty, Column(Name = "give_item", DbType = "tinyint(4)")]
    public sbyte GiveItem { get; set; } = 0;

    [JsonProperty, Column(Name = "job_score", DbType = "blob")]
    public byte[] JobScore { get; set; }

    [JsonProperty, Column(Name = "last_play_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime LastPlayTime { get; set; }

    [JsonProperty, Column(Name = "max_successive_win")]
    public uint? MaxSuccessiveWin { get; set; } = 0;

    [JsonProperty, Column(Name = "private_draw")]
    public uint PrivateDraw { get; set; } = 0;

    [JsonProperty, Column(Name = "private_lose")]
    public uint PrivateLose { get; set; } = 0;

    [JsonProperty, Column(Name = "private_win")]
    public uint PrivateWin { get; set; } = 0;

    [JsonProperty, Column(Name = "pvp_mission_info", DbType = "blob")]
    public byte[] PvpMissionInfo { get; set; }

    [JsonProperty, Column(Name = "relay_battle_2kill")]
    public uint RelayBattle2kill { get; set; } = 0;

    [JsonProperty, Column(Name = "relay_battle_3kill")]
    public uint? RelayBattle3kill { get; set; } = 0;

    [JsonProperty, Column(Name = "relay_battle_draw")]
    public uint RelayBattleDraw { get; set; } = 0;

    [JsonProperty, Column(Name = "relay_battle_lose")]
    public uint RelayBattleLose { get; set; } = 0;

    [JsonProperty, Column(Name = "relay_battle_win")]
    public uint RelayBattleWin { get; set; } = 0;

    [JsonProperty, Column(Name = "successive_win")]
    public uint SuccessiveWin { get; set; } = 0;

}
