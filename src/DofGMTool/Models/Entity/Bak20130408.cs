using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_20130408", DisableSyncStructure = true)]
public partial class Bak20130408
{

    [JsonProperty, Column(Name = "charac_no")]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "lev", DbType = "tinyint(4)")]
    public sbyte Lev { get; set; } = 1;

    [JsonProperty, Column(Name = "m_id")]
    public int MId { get; set; } = 0;

}
