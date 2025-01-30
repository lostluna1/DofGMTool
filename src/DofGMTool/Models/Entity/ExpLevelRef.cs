using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "exp_level_ref", DisableSyncStructure = true)]
public partial class ExpLevelRef
{

    [JsonProperty, Column(Name = "exp")]
    public uint Exp { get; set; } = 0;

    [JsonProperty, Column(Name = "lev", DbType = "int(11) unsigned")]
    public uint Lev { get; set; } = 0;

}
