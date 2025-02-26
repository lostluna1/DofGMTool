using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "dnf_story", DisableSyncStructure = true)]
public partial class DnfStory
{

    [JsonProperty, Column(Name = "no", IsPrimary = true, IsIdentity = true)]
    public int No { get; set; }

    [JsonProperty, Column(Name = "content", StringLength = -1)]
    public string Content { get; set; }

    [JsonProperty, Column(Name = "hits")]
    public uint Hits { get; set; } = 0;

    [JsonProperty, Column(Name = "img_name", StringLength = 30, IsNullable = false)]
    public string ImgName { get; set; }

    [JsonProperty, Column(Name = "m_id")]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "notice_flag", DbType = "tinyint(4)")]
    public sbyte NoticeFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "open_flag", InsertValueSql = "'n'")]
    public DnfStoryOPENFLAG OpenFlag { get; set; }

    [JsonProperty, Column(Name = "opt")]
    public byte Opt { get; set; } = 0;

    [JsonProperty, Column(Name = "reg_date", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime RegDate { get; set; }

    [JsonProperty, Column(Name = "reg_id", StringLength = 12, IsNullable = false)]
    public string RegId { get; set; }

    [JsonProperty, Column(Name = "reserve_time")]
    public uint ReserveTime { get; set; } = 0;

    [JsonProperty, Column(Name = "story_type", DbType = "tinyint(4)")]
    public sbyte StoryType { get; set; } = 0;

    [JsonProperty, Column(Name = "title", StringLength = 50, IsNullable = false)]
    public string Title { get; set; }

    [JsonProperty, Column(Name = "url", StringLength = 250, IsNullable = false)]
    public string Url { get; set; }

}

public enum DnfStoryOPENFLAG
{
    y = 1, n
}
