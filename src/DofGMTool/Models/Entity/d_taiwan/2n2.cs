using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(DisableSyncStructure = true)]
public partial class N2n2
{
    [JsonProperty, Column(Name = "id", DbType = "int(100)", IsPrimary = true, IsIdentity = true)]
    public int Id { get; set; }

    [JsonProperty, Column(StringLength = 100, IsNullable = false)]
    public string? N2n1 { get; set; }

    [JsonProperty, Column(StringLength = 100, IsNullable = false)]
    public string? N_2n2 { get; set; }
}
