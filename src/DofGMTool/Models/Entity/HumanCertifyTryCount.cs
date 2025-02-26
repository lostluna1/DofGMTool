using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "human_certify_try_count", DisableSyncStructure = true)]
public partial class HumanCertifyTryCount
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "count")]
    public uint Count { get; set; } = 0;

}
