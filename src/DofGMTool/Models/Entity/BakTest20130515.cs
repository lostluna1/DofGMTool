using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_test_20130515", DisableSyncStructure = true)]
public partial class BakTest20130515
{

    [JsonProperty, Column(Name = "a")]
    public uint A { get; set; } = 0;

}
