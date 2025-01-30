using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "money_gen_ref", DisableSyncStructure = true)]
public partial class MoneyGenRef
{

    [JsonProperty, Column(Name = "bottom_grade")]
    public int BottomGrade { get; set; } = 0;

    [JsonProperty, Column(Name = "grade")]
    public int Grade { get; set; } = 0;

    [JsonProperty, Column(Name = "money")]
    public int Money { get; set; } = 0;

    [JsonProperty, Column(Name = "random_value")]
    public int RandomValue { get; set; } = 0;

}
