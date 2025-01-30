using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_friends", DisableSyncStructure = true)]
public partial class CharacFriends
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "friend_no", IsPrimary = true)]
    public int FriendNo { get; set; } = 0;

}
