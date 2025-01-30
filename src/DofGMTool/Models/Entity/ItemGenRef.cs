using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "item_gen_ref", DisableSyncStructure = true)]
public partial class ItemGenRef
{

    [JsonProperty, Column(Name = "free_rate")]
    public short FreeRate { get; set; } = 0;

    [JsonProperty, Column(Name = "item_grade", DbType = "tinyint(4)")]
    public sbyte ItemGrade { get; set; } = 0;

    [JsonProperty, Column(Name = "item_rate")]
    public short ItemRate { get; set; } = 0;

    [JsonProperty, Column(Name = "money_rate")]
    public short MoneyRate { get; set; } = 0;

    [JsonProperty, Column(Name = "rate_type", DbType = "tinyint(4)")]
    public sbyte RateType { get; set; } = 0;

}
