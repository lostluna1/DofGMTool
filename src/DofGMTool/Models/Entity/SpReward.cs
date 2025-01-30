using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "sp_reward", DisableSyncStructure = true)]
public partial class SpReward
{

    [JsonProperty, Column(Name = "grade")]
    public int Grade { get; set; } = 0;

    [JsonProperty, Column(Name = "sp")]
    public int Sp { get; set; } = 0;

}
