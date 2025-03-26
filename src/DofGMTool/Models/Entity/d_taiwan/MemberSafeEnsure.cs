using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "member_safe_ensure", DisableSyncStructure = true)]
public partial class MemberSafeEnsure
{

    [JsonProperty, Column(Name = "expire_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime ExpireTime { get; set; }

    [JsonProperty, Column(Name = "m_id")]
    public uint MId { get; set; } = 0;

    [JsonProperty, Column(Name = "mobile_no", StringLength = 15, IsNullable = false)]
    public required string MobileNo { get; set; }

    [JsonProperty, Column(Name = "occ_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime OccTime { get; set; }

    [JsonProperty, Column(Name = "service_flag", DbType = "tinyint(4)")]
    public sbyte ServiceFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "settle_id", StringLength = 18, IsNullable = false)]
    public required string SettleId { get; set; }

    [JsonProperty, Column(Name = "type1_flag", DbType = "tinyint(4)")]
    public sbyte Type1Flag { get; set; } = 0;

    [JsonProperty, Column(Name = "type2_flag", DbType = "tinyint(4)")]
    public sbyte Type2Flag { get; set; } = 0;

}
