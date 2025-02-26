using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "accountss", DisableSyncStructure = true)]
public partial class Accountss
{

    [JsonProperty, Column(Name = "uid", IsPrimary = true, IsIdentity = true)]
    public int Uid { get; set; }

    [JsonProperty, Column(Name = "accountname", IsNullable = false)]
    public string Accountname { get; set; }

    [JsonProperty, Column(Name = "password", IsNullable = false)]
    public string Password { get; set; }

}
