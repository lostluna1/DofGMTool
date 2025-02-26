using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "guild_recommend", DisableSyncStructure = true)]
public partial class GuildRecommend
{

    [JsonProperty, Column(Name = "no", IsPrimary = true)]
    public int No { get; set; } = 0;

    [JsonProperty, Column(Name = "charac_name", StringLength = 20, IsNullable = false)]
    public string CharacName { get; set; }

    [JsonProperty, Column(Name = "charac_no")]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "comment", StringLength = 100, IsNullable = false)]
    public string Comment { get; set; }

    [JsonProperty, Column(Name = "guild_id")]
    public int GuildId { get; set; } = 0;

    [JsonProperty, Column(Name = "recommend_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime RecommendTime { get; set; }

    [JsonProperty, Column(Name = "server_id", DbType = "tinyint(4)")]
    public sbyte ServerId { get; set; } = 0;

}
