using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_charac_info_20130228", DisableSyncStructure = true)]
public partial class BakCharacInfo20130228
{

    [JsonProperty, Column(DbType = "bigint(21)")]
    public long CNT { get; set; } = 0;

    [JsonProperty, Column(Name = "m_id")]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "user_id", StringLength = 30, IsNullable = false)]
    public required string UserId { get; set; }

}
