using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_advance_altar_item_desc", DisableSyncStructure = true)]
public partial class CharacAdvanceAltarItemDesc
{

    /// <summary>
    /// ｾﾆﾀﾌﾅﾛｾﾆﾀﾌｵ
    /// </summary>
    [JsonProperty, Column(Name = "item_id", IsPrimary = true)]
    public int ItemId { get; set; } = 0;

    /// <summary>
    /// ｾﾆﾀﾌﾅﾛﾅｸﾀﾔ 0:ﾀｯｴﾖ, 1:ｽｺﾅｳ, 2:ﾅｸｿ
    /// </summary>
    [JsonProperty, Column(Name = "item_type", IsPrimary = true)]
    public short ItemType { get; set; } = 0;

    /// <summary>
    /// ｺｯｽﾅｸ?ｺﾅﾍ ｾﾆﾀﾌｵ
    /// </summary>
    [JsonProperty, Column(Name = "ridable_id", IsPrimary = true)]
    public int RidableId { get; set; } = 0;

    /// <summary>
    /// ｾﾆﾀﾌﾅﾛｼｳｸ
    /// </summary>
    [JsonProperty, Column(Name = "item_desc", DbType = "blob")]
    public byte[] ItemDesc { get; set; }

}
