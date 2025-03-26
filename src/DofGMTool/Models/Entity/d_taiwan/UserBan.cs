using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "user_ban", DisableSyncStructure = true)]
public partial class UserBan
{

    [JsonProperty, Column(Name = "no", IsPrimary = true, IsIdentity = true)]
    public uint No { get; set; }

    [JsonProperty, Column(Name = "admin_id")]
    public uint AdminId { get; set; } = 0;

    [JsonProperty, Column(Name = "ban_date")]
    public uint BanDate { get; set; } = 0;

    [JsonProperty, Column(Name = "ban_reason")]
    public byte BanReason { get; set; } = 0;

    [JsonProperty, Column(Name = "ban_term")]
    public ushort BanTerm { get; set; } = 0;

    [JsonProperty, Column(Name = "cancel_date")]
    public uint CancelDate { get; set; } = 0;

    [JsonProperty, Column(Name = "cancel_reason", StringLength = -1, IsNullable = false)]
    public required string CancelReason { get; set; }

    [JsonProperty, Column(Name = "category", DbType = "tinyint(4)")]
    public sbyte Category { get; set; } = 1;

    [JsonProperty, Column(Name = "detail_reason", StringLength = -1, IsNullable = false)]
    public required string DetailReason { get; set; }

    [JsonProperty, Column(Name = "first_ssn", StringLength = 6, IsNullable = false)]
    public required string FirstSsn { get; set; }

    [JsonProperty, Column(Name = "m_id")]
    public uint MId { get; set; } = 0;

    [JsonProperty, Column(Name = "second_ssn", StringLength = 7, IsNullable = false)]
    public required string SecondSsn { get; set; }

    [JsonProperty, Column(Name = "status")]
    public byte Status { get; set; } = 0;

}
