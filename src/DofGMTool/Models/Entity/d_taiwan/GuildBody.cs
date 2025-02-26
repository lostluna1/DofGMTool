using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "guild_body", DisableSyncStructure = true)]
public partial class GuildBody
{

    [JsonProperty, Column(Name = "gno", IsPrimary = true)]
    public int Gno { get; set; } = 0;

    [JsonProperty, Column(Name = "body", StringLength = -1, IsNullable = false)]
    public string Body { get; set; }

}
