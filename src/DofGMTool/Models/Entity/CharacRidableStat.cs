using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_ridable_stat", DisableSyncStructure = true)]
public partial class CharacRidableStat
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public uint CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "cooltime", DbType = "blob")]
    public byte[] Cooltime { get; set; }

}
