using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "member_info_old", DisableSyncStructure = true)]
public partial class MemberInfoOld
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true, IsIdentity = true)]
    public int MId { get; set; }

    [JsonProperty, Column(Name = "email", StringLength = 25, IsNullable = false)]
    public string Email { get; set; }

    [JsonProperty, Column(Name = "email_yn", InsertValueSql = "'y'")]
    public MemberInfoOldEMAILYN EmailYn { get; set; }

    [JsonProperty, Column(Name = "first_ssn", StringLength = 10)]
    public string FirstSsn { get; set; }

    [JsonProperty, Column(Name = "last_play_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime LastPlayTime { get; set; }

    [JsonProperty, Column(Name = "mobile_no", StringLength = 8, IsNullable = false)]
    public string MobileNo { get; set; }

    [JsonProperty, Column(Name = "nickname", StringLength = 8, IsNullable = false)]
    public string Nickname { get; set; }

    [JsonProperty, Column(Name = "passwd", StringLength = 8, IsNullable = false)]
    public string Passwd { get; set; }

    [JsonProperty, Column(Name = "q_answer", StringLength = 15, IsNullable = false)]
    public string QAnswer { get; set; }

    [JsonProperty, Column(Name = "q_no", DbType = "tinyint(4)")]
    public sbyte QNo { get; set; } = 0;

    [JsonProperty, Column(Name = "reg_date")]
    public int RegDate { get; set; } = 0;

    [JsonProperty, Column(Name = "second_ssn", StringLength = 10)]
    public string SecondSsn { get; set; }

    [JsonProperty, Column(Name = "ssn_check")]
    public byte SsnCheck { get; set; } = 0;

    [JsonProperty, Column(Name = "state", DbType = "tinyint(4)")]
    public sbyte State { get; set; } = 1;

    [JsonProperty, Column(Name = "updt_date", DbType = "timestamp", InsertValueSql = "CURRENT_TIMESTAMP")]
    public DateTime UpdtDate { get; set; }

    [JsonProperty, Column(Name = "user_id", StringLength = 15)]
    public string UserId { get; set; }

    [JsonProperty, Column(Name = "user_name", StringLength = 5, IsNullable = false)]
    public string UserName { get; set; }

}

public enum MemberInfoOldEMAILYN
{
    y = 1, n
}
