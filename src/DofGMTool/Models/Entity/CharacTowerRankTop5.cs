using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_tower_rank_top5", DisableSyncStructure = true)]
public partial class CharacTowerRankTop5
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "part_type", DbType = "tinyint(4)", IsPrimary = true)]
    public sbyte PartType { get; set; } = 0;

    [JsonProperty, Column(Name = "tower_index", IsPrimary = true)]
    public byte TowerIndex { get; set; } = 0;

    [JsonProperty, Column(Name = "member_info", DbType = "char(128)", IsNullable = false)]
    public required string MemberInfo { get; set; }

    [JsonProperty, Column(Name = "rank")]
    public ushort Rank { get; set; } = 0;

}
