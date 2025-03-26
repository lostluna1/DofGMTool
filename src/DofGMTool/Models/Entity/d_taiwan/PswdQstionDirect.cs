using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "pswd_qstion_direct", DisableSyncStructure = true)]
public partial class PswdQstionDirect
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "q_text", StringLength = 20, IsNullable = false)]
    public required string QText { get; set; }

}
