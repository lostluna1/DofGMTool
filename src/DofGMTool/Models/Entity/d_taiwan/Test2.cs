using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "test2", DisableSyncStructure = true)]
public partial class Test2
{

    [JsonProperty, Column(Name = "a")]
    public uint A { get; set; }

}
