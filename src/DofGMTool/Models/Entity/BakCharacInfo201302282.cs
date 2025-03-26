using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_charac_info_20130228_2", DisableSyncStructure = true)]
public partial class BakCharacInfo201302282
{

    [JsonProperty, Column(Name = "charac_no")]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "lev", DbType = "tinyint(4)")]
    public sbyte Lev { get; set; } = 1;

    [JsonProperty, Column(Name = "m_id")]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "user_id", StringLength = 30, IsNullable = false)]
    public required string UserId { get; set; }

}
