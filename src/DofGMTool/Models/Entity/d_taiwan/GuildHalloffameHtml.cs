using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "guild_halloffame_html", DisableSyncStructure = true)]
public partial class GuildHalloffameHtml
{

    [JsonProperty, Column(Name = "fame_id", IsPrimary = true)]
    public int FameId { get; set; } = 0;

    [JsonProperty, Column(Name = "html", StringLength = -1, IsNullable = false)]
    public string Html { get; set; }

    [JsonProperty, Column(Name = "title", StringLength = 100, IsNullable = false)]
    public string Title { get; set; }

}
