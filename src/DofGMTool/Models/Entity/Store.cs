using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "store", DisableSyncStructure = true)]
public partial class _Store
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "store", DbType = "blob")]
    public byte[] Store { get; set; }

    [JsonProperty, Column(Name = "use_doll", DbType = "tinyint(1)")]
    public sbyte? UseDoll { get; set; } = 0;

}
