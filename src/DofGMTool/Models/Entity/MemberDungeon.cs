using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "member_dungeon", DisableSyncStructure = true)]
public partial class MemberDungeon
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public uint MId { get; set; } = 0;

    [JsonProperty, Column(Name = "dungeon", StringLength = -1, IsNullable = false)]
    public required string Dungeon { get; set; }

}
