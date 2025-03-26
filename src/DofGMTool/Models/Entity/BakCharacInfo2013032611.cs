using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_charac_info_20130326_1_1", DisableSyncStructure = true)]
public partial class BakCharacInfo2013032611
{

    [JsonProperty, Column(Name = "cnt", DbType = "bigint(21)")]
    public long Cnt { get; set; } = 0;

    [JsonProperty, Column(Name = "m_id")]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "user_id", StringLength = 30, IsNullable = false)]
    public required string UserId { get; set; }

}
