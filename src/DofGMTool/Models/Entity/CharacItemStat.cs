using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_item_stat", DisableSyncStructure = true)]
public partial class CharacItemStat
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "check_flag", DbType = "blob")]
    public required byte[] CheckFlag { get; set; }

    [JsonProperty, Column(Name = "cooltime_item", DbType = "blob")]
    public required byte[] CooltimeItem { get; set; }

    [JsonProperty, Column(Name = "effect_item", DbType = "blob")]
    public required byte[] EffectItem { get; set; }

}
