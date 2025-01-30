using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_m_id_cbt_2", DisableSyncStructure = true)]
public partial class BakMIdCbt2
{

    [JsonProperty, Column(Name = "m_id")]
    public int MId { get; set; } = 0;

}
