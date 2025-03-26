using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "guild_info", DisableSyncStructure = true)]
public partial class GuildInfo
{

    [JsonProperty, Column(Name = "guild_id", IsPrimary = true, IsIdentity = true)]
    public int GuildId { get; set; }

    [JsonProperty, Column(Name = "ability", DbType = "tinyint(4)")]
    public sbyte Ability { get; set; } = 0;

    [JsonProperty, Column(Name = "create_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime CreateTime { get; set; }

    [JsonProperty, Column(Name = "expire_flag", DbType = "tinyint(4)")]
    public sbyte ExpireFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "expire_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime ExpireTime { get; set; }

    [JsonProperty, Column(Name = "final_entry")]
    public ushort FinalEntry { get; set; } = 0;

    [JsonProperty, Column(Name = "final_win")]
    public ushort FinalWin { get; set; } = 0;

    [JsonProperty, Column(Name = "guild_exp")]
    public uint GuildExp { get; set; } = 0;

    [JsonProperty, Column(Name = "guild_icon")]
    public byte GuildIcon { get; set; } = 0;

    [JsonProperty, Column(Name = "guild_icon_auth", DbType = "tinyint(4)")]
    public sbyte GuildIconAuth { get; set; } = 0;

    [JsonProperty, Column(Name = "guild_name", StringLength = 40, IsNullable = false)]
    public required string GuildName { get; set; }

    [JsonProperty, Column(Name = "guild_point")]
    public uint GuildPoint { get; set; } = 0;

    [JsonProperty, Column(Name = "guild_point_acc")]
    public uint GuildPointAcc { get; set; } = 0;

    [JsonProperty, Column(Name = "guild_point_prev")]
    public uint GuildPointPrev { get; set; } = 0;

    [JsonProperty, Column(Name = "guild_rank")]
    public uint GuildRank { get; set; } = 0;

    [JsonProperty, Column(Name = "guild_url", StringLength = 40, IsNullable = false)]
    public required string GuildUrl { get; set; }

    [JsonProperty, Column(Name = "guild_war_point")]
    public uint GuildWarPoint { get; set; } = 0;

    [JsonProperty, Column(Name = "lev")]
    public int Lev { get; set; } = 0;

    [JsonProperty, Column(Name = "master_id")]
    public int MasterId { get; set; } = 0;

    [JsonProperty, Column(Name = "master_name", StringLength = 20, IsNullable = false)]
    public required string MasterName { get; set; }

    [JsonProperty, Column(Name = "master_no")]
    public int MasterNo { get; set; } = 0;

    [JsonProperty, Column(Name = "member_count")]
    public int MemberCount { get; set; } = 0;

    [JsonProperty, Column(Name = "member_secede_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime MemberSecedeTime { get; set; }

    [JsonProperty, Column(Name = "recommend_flag", DbType = "tinyint(4)")]
    public sbyte RecommendFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "recommend_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime RecommendTime { get; set; }

    [JsonProperty, Column(Name = "server_id", DbType = "tinyint(4)")]
    public sbyte ServerId { get; set; } = 0;

}
