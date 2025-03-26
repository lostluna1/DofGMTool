using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "guild_member_introduce", DisableSyncStructure = true)]
public partial class GuildMemberIntroduce
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "guild_id", IsPrimary = true)]
    public int GuildId { get; set; } = 0;

    [JsonProperty, Column(Name = "introduce", StringLength = 200, IsNullable = false)]
    public required string Introduce { get; set; }

}
