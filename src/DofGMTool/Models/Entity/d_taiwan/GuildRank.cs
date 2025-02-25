using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "guild_rank", DisableSyncStructure = true)]
public partial class GuildRank
{

    [JsonProperty, Column(Name = "guild_id", IsPrimary = true)]
    public int GuildId { get; set; } = 0;

    [JsonProperty, Column(Name = "server_id", DbType = "tinyint(4)", IsPrimary = true)]
    public sbyte ServerId { get; set; } = 0;

    [JsonProperty, Column(Name = "guild_acc_member")]
    public ushort GuildAccMember { get; set; } = 0;

    [JsonProperty, Column(Name = "guild_acc_point")]
    public uint GuildAccPoint { get; set; } = 0;

    [JsonProperty, Column(Name = "guild_acc_visit")]
    public uint GuildAccVisit { get; set; } = 0;

    [JsonProperty, Column(Name = "guild_avg_lev")]
    public ushort GuildAvgLev { get; set; } = 0;

    [JsonProperty, Column(Name = "guild_member")]
    public ushort GuildMember { get; set; } = 0;

    [JsonProperty, Column(Name = "guild_name", StringLength = 40, IsNullable = false)]
    public string GuildName { get; set; } = "0";

    [JsonProperty, Column(Name = "guild_point")]
    public uint GuildPoint { get; set; } = 0;

    [JsonProperty, Column(Name = "guild_Rank")]
    public ushort Guild_Rank { get; set; } = 0;

    [JsonProperty, Column(Name = "guild_visit")]
    public uint GuildVisit { get; set; } = 0;

}
