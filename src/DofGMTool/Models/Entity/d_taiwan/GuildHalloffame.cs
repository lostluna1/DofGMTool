using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "guild_halloffame", DisableSyncStructure = true)]
public partial class GuildHalloffame
{

    [JsonProperty, Column(Name = "fame_id", IsPrimary = true)]
    public int FameId { get; set; } = 0;

    [JsonProperty, Column(Name = "server_id", DbType = "tinyint(4)", IsPrimary = true)]
    public sbyte ServerId { get; set; } = 0;

    [JsonProperty, Column(Name = "file_url", StringLength = 128, IsNullable = false)]
    public string FileUrl { get; set; } = "0";

    [JsonProperty, Column(Name = "guild_id")]
    public int GuildId { get; set; } = 0;

    [JsonProperty, Column(Name = "guild_name", StringLength = 40, IsNullable = false)]
    public required string GuildName { get; set; }

    [JsonProperty, Column(Name = "main_flag", DbType = "tinyint(4)")]
    public sbyte MainFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "open_flag", DbType = "tinyint(4)")]
    public sbyte OpenFlag { get; set; } = 0;

}
