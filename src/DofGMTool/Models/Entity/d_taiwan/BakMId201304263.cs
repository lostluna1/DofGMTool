using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_m_id_20130426_3", DisableSyncStructure = true)]
public partial class BakMId201304263
{

    [JsonProperty, Column(Name = "reg_date", DbType = "datetime")]
    public DateTime? RegDate { get; set; }

    [JsonProperty, Column(Name = "user_id", StringLength = 30)]
    public string UserId { get; set; }

}
