using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_item_lock_info", DisableSyncStructure = true)]
public partial class CharacItemLockInfo
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public uint CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "item_lock_info", DbType = "blob")]
    public required byte[] ItemLockInfo { get; set; }

}
