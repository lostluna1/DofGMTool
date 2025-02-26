using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "slang_list_name", DisableSyncStructure = true)]
public partial class SlangListName
{

    [JsonProperty, Column(Name = "slang", StringLength = 153, IsPrimary = true, IsNullable = false)]
    public string Slang { get; set; }

}
