using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "auto_punish_second_user", DisableSyncStructure = true)]
public partial class AutoPunishSecondUser
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "occ_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime OccTime { get; set; }

    [JsonProperty, Column(Name = "punish_flag", DbType = "tinyint(4)")]
    public sbyte PunishFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "total_trade_cnt")]
    public uint TotalTradeCnt { get; set; } = 0;

    [JsonProperty, Column(Name = "total_trade_gold")]
    public ulong TotalTradeGold { get; set; } = 0;

    [JsonProperty, Column(Name = "trade_cnt")]
    public uint TradeCnt { get; set; } = 0;

    [JsonProperty, Column(Name = "trade_gold")]
    public ulong TradeGold { get; set; } = 0;

}
