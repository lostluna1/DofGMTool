using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "member_security_card", DisableSyncStructure = true)]
public partial class MemberSecurityCard
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "apply_flag", DbType = "tinyint(4)")]
    public sbyte ApplyFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "cancel_cnt")]
    public ushort CancelCnt { get; set; } = 0;

    [JsonProperty, Column(Name = "card", IsNullable = false)]
    public string Card { get; set; }

    [JsonProperty, Column(Name = "cert_flag", DbType = "char(1)", IsNullable = false)]
    public string CertFlag { get; set; } = "0";

    [JsonProperty, Column(Name = "cert_key", StringLength = 12, IsNullable = false)]
    public string CertKey { get; set; }

    [JsonProperty, Column(Name = "fail_cnt", DbType = "tinyint(4)")]
    public sbyte FailCnt { get; set; } = 0;

    [JsonProperty, Column(Name = "last_issue_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime LastIssueTime { get; set; }

    [JsonProperty, Column(Name = "occ_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime OccTime { get; set; }

    [JsonProperty, Column(Name = "phone", StringLength = 11, IsNullable = false)]
    public string Phone { get; set; }

    [JsonProperty, Column(Name = "re_issue_cnt", DbType = "tinyint(4)")]
    public sbyte ReIssueCnt { get; set; } = 0;

    [JsonProperty, Column(Name = "server_key", StringLength = 32, IsNullable = false)]
    public string ServerKey { get; set; }

    [JsonProperty, Column(Name = "validity_time")]
    public int ValidityTime { get; set; } = 0;

    [JsonProperty, Column(Name = "web_flag", DbType = "tinyint(4)")]
    public sbyte WebFlag { get; set; } = 0;

}
