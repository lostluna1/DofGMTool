using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_best_record", DisableSyncStructure = true)]
public partial class CharacBestRecord
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "difficulty", IsPrimary = true)]
    public short Difficulty { get; set; } = 0;

    [JsonProperty, Column(Name = "dungeon_no", IsPrimary = true)]
    public short DungeonNo { get; set; } = 0;

    [JsonProperty, Column(Name = "attacked")]
    public int Attacked { get; set; } = 0;

    [JsonProperty, Column(Name = "rank")]
    public int Rank { get; set; } = 0;

    [JsonProperty, Column(Name = "style")]
    public int Style { get; set; } = 0;

    [JsonProperty, Column(Name = "technic")]
    public int Technic { get; set; } = 0;

}
