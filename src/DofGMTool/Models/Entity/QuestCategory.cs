using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "quest_category", DisableSyncStructure = true)]
public partial class QuestCategory
{

    [JsonProperty, Column(Name = "quest_idx", IsPrimary = true)]
    public int QuestIdx { get; set; } = 0;

    [JsonProperty, Column(Name = "quest_name", StringLength = 30, IsNullable = false)]
    public string QuestName { get; set; }

}
