using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_kill_monster_info", DisableSyncStructure = true)]
public partial class CharacKillMonsterInfo
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public uint CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "apc_boss_info", DbType = "blob")]
    public byte[] ApcBossInfo { get; set; }

    [JsonProperty, Column(Name = "boss_info", DbType = "blob")]
    public byte[] BossInfo { get; set; }

    [JsonProperty, Column(Name = "named_info", DbType = "blob")]
    public byte[] NamedInfo { get; set; }

}
