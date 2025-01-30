using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_trade_limit_info", DisableSyncStructure = true)]
public partial class CharacTradeLimitInfo
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public uint CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "last_trade_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime LastTradeTime { get; set; }

    [JsonProperty, Column(Name = "m_id")]
    public uint MId { get; set; } = 0;

    [JsonProperty, Column(Name = "nexon_user", DbType = "tinyint(4)")]
    public sbyte NexonUser { get; set; } = 0;

    [JsonProperty, Column(Name = "total_trade_gold")]
    public uint TotalTradeGold { get; set; } = 0;

    [JsonProperty, Column(Name = "trade_count")]
    public ushort TradeCount { get; set; } = 0;

}
