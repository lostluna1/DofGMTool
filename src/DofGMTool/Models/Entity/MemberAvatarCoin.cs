using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "member_avatar_coin", DisableSyncStructure = true)]
public partial class MemberAvatarCoin
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "avatar_coin")]
    public uint AvatarCoin { get; set; } = 0;

}
