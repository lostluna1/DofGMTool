using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_action_point_desc", DisableSyncStructure = true)]
public partial class CharacActionPointDesc
{

    [JsonProperty, Column(Name = "action_group_index", IsPrimary = true)]
    public int ActionGroupIndex { get; set; } = 0;

    [JsonProperty, Column(Name = "action_index", IsPrimary = true)]
    public int ActionIndex { get; set; } = 0;

    [JsonProperty, Column(Name = "action_group_name", StringLength = 128)]
    public string ActionGroupName { get; set; }

}
