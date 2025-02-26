using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "log_query_ref~", DisableSyncStructure = true)]
public partial class LogQueryRef
{

    [JsonProperty, Column(Name = "q_id", IsPrimary = true, IsIdentity = true)]
    public ushort QId { get; set; }

    [JsonProperty, Column(Name = "query", StringLength = -1, IsNullable = false)]
    public string Query { get; set; }

    [JsonProperty, Column(Name = "query_hash", StringLength = 16, IsNullable = false)]
    public string QueryHash { get; set; }

}
