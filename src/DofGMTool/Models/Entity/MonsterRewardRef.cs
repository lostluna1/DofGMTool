using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "monster_reward_ref", DisableSyncStructure = true)]
public partial class MonsterRewardRef
{

    [JsonProperty, Column(Name = "exp")]
    public int Exp { get; set; } = 0;

    [JsonProperty, Column(Name = "level", DbType = "smallint(11)")]
    public short Level { get; set; } = 0;

}
