using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_blood_best_record", DisableSyncStructure = true)]
public partial class CharacBloodBestRecord
{

    [JsonProperty, Column(Name = "charac_no", DbType = "int(11) unsigned", IsPrimary = true)]
    public uint CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "dungeon_index", DbType = "int(11) unsigned", IsPrimary = true)]
    public uint DungeonIndex { get; set; } = 0;

    [JsonProperty, Column(Name = "best_round")]
    public byte BestRound { get; set; } = 0;

    [JsonProperty, Column(Name = "best_time")]
    public int BestTime { get; set; } = 0;

}
