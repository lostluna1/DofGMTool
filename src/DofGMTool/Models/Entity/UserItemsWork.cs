using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "user_items_work", DisableSyncStructure = true)]
public partial class UserItemsWork
{

    [JsonProperty, Column(Name = "ability_no", DbType = "tinyint(4)")]
    public sbyte AbilityNo { get; set; } = 0;

    [JsonProperty, Column(Name = "charac_no")]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "clear_avatar_id")]
    public int ClearAvatarId { get; set; } = 0;

    [JsonProperty, Column(Name = "expire_date", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime ExpireDate { get; set; }

    [JsonProperty, Column(Name = "ipg_agency_no", StringLength = 32, IsNullable = false)]
    public string IpgAgencyNo { get; set; }

    [JsonProperty, Column(Name = "it_id")]
    public int ItId { get; set; } = 0;

    [JsonProperty, Column(Name = "item_lock_key")]
    public byte ItemLockKey { get; set; } = 0;

    [JsonProperty, Column(Name = "jewel_socket", DbType = "blob")]
    public byte[] JewelSocket { get; set; }

    [JsonProperty, Column(Name = "obtain_from", DbType = "tinyint(4)")]
    public sbyte? ObtainFrom { get; set; }

    [JsonProperty, Column(Name = "reg_date", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime RegDate { get; set; }

    [JsonProperty, Column(Name = "slot")]
    public int Slot { get; set; } = 0;

    [JsonProperty, Column(Name = "stat")]
    public byte Stat { get; set; } = 0;

    [JsonProperty, Column(Name = "ui_id")]
    public int UiId { get; set; } = 0;

}
