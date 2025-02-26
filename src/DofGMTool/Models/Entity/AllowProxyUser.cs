using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "allow_proxy_user", DisableSyncStructure = true)]
public partial class AllowProxyUser
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public uint MId { get; set; } = 0;

}
