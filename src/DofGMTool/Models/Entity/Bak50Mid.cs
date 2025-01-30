using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_50_mid", DisableSyncStructure = true)]
public partial class Bak50Mid
{

    [JsonProperty, Column(Name = "m_id")]
    public uint MId { get; set; } = 0;

}
