using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "member_lioness", DisableSyncStructure = true)]
public partial class MemberLioness
{

    [JsonProperty, Column(Name = "user_id", StringLength = 30, IsNullable = false)]
    public required string UserId { get; set; }

}
