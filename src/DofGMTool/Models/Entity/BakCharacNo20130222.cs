using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_charac_no_20130222", DisableSyncStructure = true)]
public partial class BakCharacNo20130222
{

    [JsonProperty, Column(Name = "charac_no")]
    public uint CharacNo { get; set; } = 0;

}
