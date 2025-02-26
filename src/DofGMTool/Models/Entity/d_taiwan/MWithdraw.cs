using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "m_withdraw", DisableSyncStructure = true)]
public partial class MWithdraw
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true, IsIdentity = true)]
    public int MId { get; set; }

    [JsonProperty, Column(Name = "email", StringLength = 25, IsNullable = false)]
    public string Email { get; set; }

    [JsonProperty, Column(Name = "first_ssn", StringLength = 3, IsNullable = false)]
    public string FirstSsn { get; set; }

    [JsonProperty, Column(Name = "mobile_no", StringLength = 7, IsNullable = false)]
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

    [JsonProperty, Column(Name = "second_ssn", StringLength = 3, IsNullable = false)]
    public string SecondSsn { get; set; }

    [JsonProperty, Column(Name = "state", DbType = "tinyint(4)")]
    public sbyte State { get; set; } = 0;

    [JsonProperty, Column(Name = "updt_date", DbType = "timestamp", InsertValueSql = "CURRENT_TIMESTAMP")]
    public DateTime UpdtDate { get; set; }

    [JsonProperty, Column(Name = "user_id", StringLength = 6, IsNullable = false)]
    public string UserId { get; set; }

    [JsonProperty, Column(Name = "user_name", StringLength = 5, IsNullable = false)]
    public string UserName { get; set; }

    [JsonProperty, Column(Name = "w_cause", StringLength = 100, IsNullable = false)]
    public string WCause { get; set; }

    [JsonProperty, Column(Name = "w_date")]
    public int WDate { get; set; } = 0;

    [JsonProperty, Column(Name = "w_type")]
    public short WType { get; set; } = 0;

}
