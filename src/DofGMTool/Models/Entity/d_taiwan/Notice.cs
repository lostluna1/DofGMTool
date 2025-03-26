using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "notice", DisableSyncStructure = true)]
public partial class Notice
{

    [JsonProperty, Column(Name = "adorn")]
    public byte Adorn { get; set; } = 0;

    [JsonProperty, Column(Name = "adorn_color1")]
    public byte AdornColor1 { get; set; } = 0;

    [JsonProperty, Column(Name = "adorn_color2")]
    public byte AdornColor2 { get; set; } = 0;

    [JsonProperty, Column(Name = "bbs_name", StringLength = 10, IsNullable = false)]
    public required string BbsName { get; set; }

    [JsonProperty, Column(Name = "category")]
    public byte Category { get; set; } = 0;

    [JsonProperty, Column(Name = "comment")]
    public ushort Comment { get; set; } = 0;

    [JsonProperty, Column(Name = "content", StringLength = -1, IsNullable = false)]
    public required string Content { get; set; }

    [JsonProperty, Column(Name = "content_type", InsertValueSql = "'br'")]
    public NoticeCONTENTTYPE ContentType { get; set; }

    [JsonProperty, Column(Name = "create_day")]
    public uint CreateDay { get; set; } = 0;

    [JsonProperty, Column(Name = "depth")]
    public byte Depth { get; set; } = 0;

    [JsonProperty, Column(Name = "ip", StringLength = 15, IsNullable = false)]
    public required string Ip { get; set; }

    [JsonProperty, Column(Name = "m_id")]
    public uint MId { get; set; } = 0;

    [JsonProperty, Column(Name = "m_nickname", StringLength = 12, IsNullable = false)]
    public required string MNickname { get; set; }

    [JsonProperty, Column(Name = "m_sex", InsertValueSql = "'m'")]
    public NoticeMSEX MSex { get; set; }

    [JsonProperty, Column(Name = "m_user_id", StringLength = 16, IsNullable = false)]
    public required string MUserId { get; set; }

    [JsonProperty, Column(Name = "no", DbType = "mediumint(8) unsigned", IsIdentity = true)]
    public uint No { get; set; }

    [JsonProperty, Column(Name = "recom", DbType = "mediumint(8) unsigned")]
    public uint Recom { get; set; } = 0;

    [JsonProperty, Column(Name = "ring")]
    public ushort Ring { get; set; } = 0;

    [JsonProperty, Column(Name = "sequence", DbType = "double unsigned")]
    public double Sequence { get; set; } = 0d;

    [JsonProperty, Column(Name = "sms", InsertValueSql = "'n'")]
    public NoticeSMS Sms { get; set; }

    [JsonProperty, Column(Name = "title", StringLength = 120, IsNullable = false)]
    public required string Title { get; set; }

    [JsonProperty, Column(Name = "view", DbType = "mediumint(8) unsigned")]
    public uint View { get; set; } = 0;

}

public enum NoticeCONTENTTYPE
{
    br = 1, text, all
}
public enum NoticeMSEX
{
    m = 1, f
}
public enum NoticeSMS
{
    y = 1, n
}
