using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_m_id_20130424_ccb", DisableSyncStructure = true)]
public partial class BakMId20130424Ccb
{

    [JsonProperty, Column(Name = "m_id")]
    public uint MId { get; set; } = 0;

}
