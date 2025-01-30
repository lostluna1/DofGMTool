using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "event_1106_idol_bring_up", DisableSyncStructure = true)]
public partial class Event1106IdolBringUp
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public uint CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "give_title_flag", DbType = "tinyint(4)")]
    public sbyte GiveTitleFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "give_title_flag2", DbType = "tinyint(4)")]
    public sbyte GiveTitleFlag2 { get; set; } = 0;

    [JsonProperty, Column(Name = "m_id")]
    public uint MId { get; set; } = 0;

    [JsonProperty, Column(Name = "occ_date", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime OccDate { get; set; }

    [JsonProperty, Column(Name = "pot_type", DbType = "tinyint(4)")]
    public sbyte PotType { get; set; } = 0;

    [JsonProperty, Column(Name = "water_cnt", DbType = "tinyint(4)")]
    public sbyte WaterCnt { get; set; } = 0;

}
