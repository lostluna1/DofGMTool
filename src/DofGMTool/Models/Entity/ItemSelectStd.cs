using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "item_select_std", DisableSyncStructure = true)]
public partial class ItemSelectStd
{

    [JsonProperty, Column(Name = "bottom")]
    public int Bottom { get; set; } = 0;

    [JsonProperty, Column(Name = "item_grade")]
    public int ItemGrade { get; set; } = 0;

    [JsonProperty, Column(Name = "top")]
    public int Top { get; set; } = 0;

    [JsonProperty, Column(Name = "weight")]
    public int Weight { get; set; } = 0;

}
