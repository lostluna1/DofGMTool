using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "guild_visit", DisableSyncStructure = true)]
public partial class GuildVisit
{

    [JsonProperty, Column(Name = "guild_id", IsPrimary = true)]
    public int GuildId { get; set; } = 0;

    [JsonProperty, Column(Name = "server_id", DbType = "tinyint(4)")]
    public sbyte ServerId { get; set; } = 0;

    [JsonProperty, Column(Name = "today_visit")]
    public int TodayVisit { get; set; } = 0;

    [JsonProperty, Column(Name = "total_visit")]
    public int TotalVisit { get; set; } = 0;

}
