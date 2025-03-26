using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "guild_introduce", DisableSyncStructure = true)]
public partial class GuildIntroduce
{

    [JsonProperty, Column(Name = "guild_id", IsPrimary = true)]
    public int GuildId { get; set; } = 0;

    [JsonProperty, Column(Name = "introduce", StringLength = 200, IsNullable = false)]
    public required string Introduce { get; set; }

    [JsonProperty, Column(Name = "server_id", DbType = "tinyint(4)")]
    public sbyte ServerId { get; set; } = 0;

}
