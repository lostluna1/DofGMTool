using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "village_attack_dungeon", DisableSyncStructure = true)]
public partial class VillageAttackDungeon
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public uint CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "occ_date", DbType = "date", IsPrimary = true, InsertValueSql = "0000-00-00")]
    public DateTime OccDate { get; set; }

    [JsonProperty, Column(Name = "attack_count")]
    public byte AttackCount { get; set; } = 0;

    [JsonProperty, Column(Name = "revenge_dungeon")]
    public byte RevengeDungeon { get; set; } = 0;

}
