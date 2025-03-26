using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "guild_bbs", DisableSyncStructure = true)]
public partial class GuildBbs
{

    [JsonProperty, Column(Name = "gno", IsPrimary = true, IsIdentity = true)]
    public int Gno { get; set; }

    [JsonProperty, Column(Name = "bd_id", DbType = "tinyint(4)")]
    public sbyte BdId { get; set; } = 0;

    [JsonProperty, Column(Name = "body_type", DbType = "char(1)", IsNullable = false)]
    public required string BodyType { get; set; }

    [JsonProperty, Column(Name = "empyn", DbType = "tinyint(4)")]
    public sbyte Empyn { get; set; } = 0;

    [JsonProperty, Column(Name = "hits", DbType = "mediumint(8) unsigned")]
    public uint Hits { get; set; } = 0;

    [JsonProperty, Column(Name = "m_id")]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "main", DbType = "tinyint(4)")]
    public sbyte Main { get; set; } = 0;

    [JsonProperty, Column(Name = "mgno")]
    public int Mgno { get; set; } = 0;

    [JsonProperty, Column(Name = "mod_date")]
    public int ModDate { get; set; } = 0;

    [JsonProperty, Column(Name = "open", DbType = "tinyint(1)")]
    public sbyte Open { get; set; } = 1;

    [JsonProperty, Column(Name = "reg_date")]
    public int RegDate { get; set; } = 0;

    [JsonProperty, Column(Name = "reg_id", StringLength = 20, IsNullable = false)]
    public required string RegId { get; set; }

    [JsonProperty, Column(Name = "subject", StringLength = 50, IsNullable = false)]
    public required string Subject { get; set; }

}
