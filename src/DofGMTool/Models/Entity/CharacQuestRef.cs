using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_quest_ref", DisableSyncStructure = true)]
public partial class CharacQuestRef
{

    [JsonProperty, Column(Name = "origin_idx", IsPrimary = true)]
    public int OriginIdx { get; set; } = 0;

    [JsonProperty, Column(Name = "mapped_idx")]
    public int MappedIdx { get; set; } = 0;

}
