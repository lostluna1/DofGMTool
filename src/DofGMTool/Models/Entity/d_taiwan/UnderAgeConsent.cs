using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "under_age_consent", DisableSyncStructure = true)]
public partial class UnderAgeConsent
{

    [JsonProperty, Column(Name = "consent_date")]
    public uint ConsentDate { get; set; } = 0;

    [JsonProperty, Column(Name = "consent_type")]
    public byte ConsentType { get; set; } = 0;

    [JsonProperty, Column(Name = "consent_yn")]
    public byte ConsentYn { get; set; } = 0;

    [JsonProperty, Column(Name = "create_date")]
    public uint CreateDate { get; set; } = 0;

    [JsonProperty, Column(Name = "history_yn")]
    public byte HistoryYn { get; set; } = 0;

    [JsonProperty, Column(Name = "limit_money", DbType = "mediumint(8) unsigned")]
    public uint LimitMoney { get; set; } = 0;

    [JsonProperty, Column(Name = "m_id")]
    public uint MId { get; set; } = 0;

    [JsonProperty, Column(Name = "notice_addr", StringLength = 50, IsNullable = false)]
    public required string NoticeAddr { get; set; }

    [JsonProperty, Column(Name = "notice_type")]
    public byte NoticeType { get; set; } = 0;

    [JsonProperty, Column(Name = "parent_consent_type")]
    public byte ParentConsentType { get; set; } = 0;

    [JsonProperty, Column(Name = "parent_email", StringLength = 25, IsNullable = false)]
    public required string ParentEmail { get; set; }

    [JsonProperty, Column(Name = "parent_jumin")]
    public ulong ParentJumin { get; set; } = 0;

    [JsonProperty, Column(Name = "parent_name", StringLength = 4, IsNullable = false)]
    public required string ParentName { get; set; }

    [JsonProperty, Column(Name = "parent_phone1")]
    public byte ParentPhone1 { get; set; } = 0;

    [JsonProperty, Column(Name = "parent_phone2")]
    public ushort ParentPhone2 { get; set; } = 0;

    [JsonProperty, Column(Name = "parent_phone3")]
    public ushort ParentPhone3 { get; set; } = 0;

}
