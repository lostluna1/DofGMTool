using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_dungeon_test", DisableSyncStructure = true)]
public partial class CharacDungeonTest
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "dungeon", DbType = "blob")]
    public required byte[] Dungeon { get; set; }

}
