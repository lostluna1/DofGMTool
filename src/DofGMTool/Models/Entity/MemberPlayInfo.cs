using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "member_play_info", DisableSyncStructure = true)]
public partial class MemberPlayInfo
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "occ_date", DbType = "date", IsPrimary = true, InsertValueSql = "0000-00-00")]
    public DateTime OccDate { get; set; }

    [JsonProperty, Column(Name = "end_ip", StringLength = 3, IsNullable = false)]
    public string EndIp { get; set; }

    [JsonProperty, Column(Name = "exp")]
    public uint Exp { get; set; } = 0;

    [JsonProperty, Column(Name = "ip", StringLength = 15, IsNullable = false)]
    public string Ip { get; set; }

    [JsonProperty, Column(Name = "last_play_time")]
    public uint LastPlayTime { get; set; } = 0;

    [JsonProperty, Column(Name = "mac_addr", StringLength = 64, IsNullable = false)]
    public string MacAddr { get; set; }

    [JsonProperty, Column(Name = "pcbang_flag", DbType = "tinyint(4)")]
    public sbyte PcbangFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "play_count")]
    public uint PlayCount { get; set; } = 0;

    [JsonProperty, Column(Name = "play_time")]
    public uint PlayTime { get; set; } = 0;

    [JsonProperty, Column(Name = "server_id", DbType = "tinyint(4)")]
    public sbyte ServerId { get; set; } = 0;

    [JsonProperty, Column(Name = "ting_count")]
    public ushort TingCount { get; set; } = 0;

    [JsonProperty, Column(Name = "trade_cnt")]
    public int TradeCnt { get; set; } = 0;

    [JsonProperty, Column(Name = "used_fatigue")]
    public ushort UsedFatigue { get; set; } = 0;

}
