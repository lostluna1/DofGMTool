using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_member_info_20130326", DisableSyncStructure = true)]
public partial class BakMemberInfo20130326
{

    [JsonProperty, Column(Name = "m_id")]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "user_id", StringLength = 30)]
    public required string UserId { get; set; }

}
