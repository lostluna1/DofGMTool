using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_npc", DisableSyncStructure = true)]
public partial class CharacNpc
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "npc_cnt")]
    public byte NpcCnt { get; set; } = 0;

    [JsonProperty, Column(Name = "npc_data", DbType = "blob")]
    public required byte[] NpcData { get; set; }

}
