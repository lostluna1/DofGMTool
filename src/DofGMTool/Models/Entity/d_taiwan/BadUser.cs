using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "bad_user", DisableSyncStructure = true)]
public partial class BadUser
{

    [JsonProperty, Column(Name = "no", IsPrimary = true, IsIdentity = true)]
    public int No { get; set; }

    [JsonProperty, Column(Name = "admin_n")]
    public int AdminN { get; set; } = 0;

    [JsonProperty, Column(Name = "bad_code")]
    public int BadCode { get; set; } = 0;

    [JsonProperty, Column(Name = "create_day")]
    public int CreateDay { get; set; } = 0;

    [JsonProperty, Column(Name = "exit_day")]
    public int ExitDay { get; set; } = 0;

    [JsonProperty, Column(Name = "m_id")]
    public int MId { get; set; } = 0;

}
