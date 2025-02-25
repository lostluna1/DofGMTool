using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(DisableSyncStructure = true)]
public partial class N3n3
{
    [JsonProperty, Column(Name = "id", DbType = "int(100)", IsPrimary = true, IsIdentity = true)]
    public int Id { get; set; }

    [JsonProperty, Column(StringLength = 100, IsNullable = false)]
    public string N3n1 { get; set; }

    [JsonProperty, Column(StringLength = 100, IsNullable = false)]
    public string N3n2 { get; set; }

    [JsonProperty, Column(StringLength = 100, IsNullable = false)]
    public string N_3n3 { get; set; }
}
