using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "guild_member", DisableSyncStructure = true)]
public partial class GuildMember
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "guild_id", IsPrimary = true)]
    public int GuildId { get; set; } = 0;

    [JsonProperty, Column(Name = "age", DbType = "tinyint(4)")]
    public sbyte Age { get; set; } = 0;

    [JsonProperty, Column(Name = "apply_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime ApplyTime { get; set; }

    [JsonProperty, Column(Name = "bbs_cnt")]
    public ushort BbsCnt { get; set; } = 0;

    [JsonProperty, Column(Name = "born_year", StringLength = 2, IsNullable = false)]
    public string BornYear { get; set; }

    [JsonProperty, Column(Name = "charac_name", StringLength = 20, IsNullable = false)]
    public string CharacName { get; set; }

    [JsonProperty, Column(Name = "grade", DbType = "tinyint(4)")]
    public sbyte Grade { get; set; } = 0;

    [JsonProperty, Column(Name = "grow_type", DbType = "tinyint(4)")]
    public sbyte GrowType { get; set; } = 0;

    [JsonProperty, Column(Name = "job", DbType = "tinyint(4)")]
    public sbyte Job { get; set; } = 0;

    [JsonProperty, Column(Name = "last_play_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime LastPlayTime { get; set; }

    [JsonProperty, Column(Name = "last_visit_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime LastVisitTime { get; set; }

    [JsonProperty, Column(Name = "lev", DbType = "tinyint(4)")]
    public sbyte Lev { get; set; } = 0;

    [JsonProperty, Column(Name = "m_id")]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "member_flag", DbType = "tinyint(4)")]
    public sbyte MemberFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "member_point")]
    public uint MemberPoint { get; set; } = 0;

    [JsonProperty, Column(Name = "member_point_prev")]
    public uint MemberPointPrev { get; set; } = 0;

    [JsonProperty, Column(Name = "member_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime MemberTime { get; set; }

    [JsonProperty, Column(Name = "nick_name", StringLength = 12, IsNullable = false)]
    public string NickName { get; set; }

    [JsonProperty, Column(Name = "secede_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime SecedeTime { get; set; }

    [JsonProperty, Column(Name = "secede_type", DbType = "tinyint(4)")]
    public sbyte SecedeType { get; set; } = 0;

    [JsonProperty, Column(Name = "server_id", DbType = "tinyint(4)")]
    public sbyte ServerId { get; set; } = 0;

    [JsonProperty, Column(Name = "sex", DbType = "char(1)", IsNullable = false)]
    public string Sex { get; set; }

}
