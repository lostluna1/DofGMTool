using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "test", DisableSyncStructure = true)]
public partial class Test
{

    [JsonProperty, Column(Name = "a")]
    public int? A { get; set; }

    [JsonProperty, Column(Name = "b", DbType = "datetime")]
    public DateTime? B { get; set; }

}
