using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_charac_info_20130326_1_2", DisableSyncStructure = true)]
public partial class BakCharacInfo2013032612
{

    [JsonProperty, Column(Name = "charac_no")]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "create_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime CreateTime { get; set; }

    [JsonProperty, Column(Name = "lev", DbType = "tinyint(4)")]
    public sbyte Lev { get; set; } = 1;

    [JsonProperty, Column(Name = "m_id")]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "user_id", StringLength = 30, IsNullable = false)]
    public required string UserId { get; set; }

}
