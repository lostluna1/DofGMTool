using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "member_mousepass", DisableSyncStructure = true)]
public partial class MemberMousepass
{

    [JsonProperty, Column(Name = "cancel_cnt")]
    public ushort CancelCnt { get; set; } = 0;

    [JsonProperty, Column(Name = "enable_flag", DbType = "char(1)", IsNullable = false)]
    public string EnableFlag { get; set; }

    [JsonProperty, Column(Name = "fail_cnt", DbType = "tinyint(4)")]
    public sbyte FailCnt { get; set; } = 0;

    [JsonProperty, Column(Name = "m_id")]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "mousepass", StringLength = 32, IsNullable = false)]
    public string Mousepass { get; set; }

    [JsonProperty, Column(Name = "occ_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime OccTime { get; set; }

    [JsonProperty, Column(Name = "reward_time")]
    public int RewardTime { get; set; } = 0;

    [JsonProperty, Column(Name = "validity_time")]
    public int ValidityTime { get; set; } = 0;

    [JsonProperty, Column(Name = "version_info", DbType = "char(1)", IsNullable = false)]
    public string VersionInfo { get; set; } = "1";

}
