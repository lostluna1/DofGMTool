using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_mid_20130408", DisableSyncStructure = true)]
public partial class BakMid20130408
{

    [JsonProperty, Column(Name = "m_id")]
    public uint MId { get; set; } = 0;

}
