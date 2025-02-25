using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "member_captcha_info", DisableSyncStructure = true)]
public partial class d_taiwan_MemberCaptchaInfo
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public uint MId { get; set; } = 0;

    [JsonProperty, Column(Name = "cert_time")]
    public uint CertTime { get; set; } = 0;

    [JsonProperty, Column(Name = "fail_count")]
    public byte FailCount { get; set; } = 0;

}
