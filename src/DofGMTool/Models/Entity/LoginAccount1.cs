using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "login_account_1", DisableSyncStructure = true)]
public partial class LoginAccount1
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public uint MId { get; set; } = 0;

    [JsonProperty, Column(Name = "last_login_date", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime LastLoginDate { get; set; }

    [JsonProperty, Column(Name = "login_ip", StringLength = 15, IsNullable = false)]
    public string LoginIp { get; set; }

    [JsonProperty, Column(Name = "login_status", DbType = "tinyint(1)")]
    public sbyte LoginStatus { get; set; } = 0;

    [JsonProperty, Column(Name = "m_channel_no")]
    public int MChannelNo { get; set; } = 0;

}
