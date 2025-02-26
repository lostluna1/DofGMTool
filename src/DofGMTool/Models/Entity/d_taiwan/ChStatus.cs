using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "ch_status", DisableSyncStructure = true)]
public partial class ChStatus
{

    [JsonProperty, Column(Name = "gc_group")]
    public byte GcGroup { get; set; } = 1;

    [JsonProperty, Column(Name = "gc_status")]
    public byte GcStatus { get; set; } = 0;

}
