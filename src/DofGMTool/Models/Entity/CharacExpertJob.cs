using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_expert_job", DisableSyncStructure = true)]
public partial class CharacExpertJob
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "expert_job_giveup_cnt")]
    public byte ExpertJobGiveupCnt { get; set; } = 0;

    [JsonProperty, Column(Name = "expert_job_info")]
    public int ExpertJobInfo { get; set; } = 0;

    [JsonProperty, Column(Name = "expert_job_info_ex")]
    public int ExpertJobInfoEx { get; set; } = 0;

    [JsonProperty, Column(Name = "recipe", DbType = "blob")]
    public byte[] Recipe { get; set; }

}
