using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

/// <summary>
/// 서비스 제재 정보 문자열
/// </summary>
[JsonObject(MemberSerialization.OptIn), Table(Name = "dnf_restrict_info", DisableSyncStructure = true)]
public partial class DnfRestrictInfo
{

    [JsonProperty, Column(Name = "category", IsPrimary = true)]
    public int Category { get; set; }

    [JsonProperty, Column(Name = "restrict_code", IsPrimary = true)]
    public int RestrictCode { get; set; }

    [JsonProperty, Column(Name = "reg_date", DbType = "datetime")]
    public DateTime RegDate { get; set; }

    [JsonProperty, Column(Name = "restrict_str", StringLength = 45, IsNullable = false)]
    public string RestrictStr { get; set; }

}
