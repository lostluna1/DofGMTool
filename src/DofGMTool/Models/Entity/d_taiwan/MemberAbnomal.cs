using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "member_abnomal", DisableSyncStructure = true)]
public partial class MemberAbnomal
{

    [JsonProperty, Column(Name = "user_id", StringLength = 12, IsPrimary = true, IsNullable = false)]
    public required string UserId { get; set; }

    [JsonProperty, Column(Name = "overlab_count")]
    public short OverlabCount { get; set; } = 0;

}
