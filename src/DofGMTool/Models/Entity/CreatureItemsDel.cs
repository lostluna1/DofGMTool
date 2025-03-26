using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "creature_items_del", DisableSyncStructure = true)]
public partial class CreatureItemsDel
{

    [JsonProperty, Column(Name = "sdate", DbType = "date", IsPrimary = true, InsertValueSql = "0000-00-00")]
    public DateTime Sdate { get; set; }

    [JsonProperty, Column(Name = "ui_id", IsPrimary = true)]
    public int UiId { get; set; } = 0;

    [JsonProperty, Column(Name = "charac_no")]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "creature_type", DbType = "tinyint(4)")]
    public sbyte CreatureType { get; set; } = 0;

    [JsonProperty, Column(Name = "delete_date", DbType = "datetime")]
    public DateTime DeleteDate { get; set; } = DateTime.Parse("9999-12-31 23:59:59");

    [JsonProperty, Column(Name = "endurance")]
    public byte Endurance { get; set; } = 0;

    [JsonProperty, Column(Name = "exp")]
    public uint Exp { get; set; } = 0;

    [JsonProperty, Column(Name = "expire_date", DbType = "datetime")]
    public DateTime ExpireDate { get; set; } = DateTime.Parse("9999-12-31 23:59:59");

    [JsonProperty, Column(Name = "ipg_agency_no", StringLength = 32, IsNullable = false)]
    public required string IpgAgencyNo { get; set; }

    [JsonProperty, Column(Name = "it_id")]
    public uint ItId { get; set; } = 0;

    [JsonProperty, Column(Name = "item_lock_key", DbType = "tinyint(4)")]
    public sbyte ItemLockKey { get; set; } = 0;

    [JsonProperty, Column(Name = "name", StringLength = 12, IsNullable = false)]
    public required string Name { get; set; }

    [JsonProperty, Column(Name = "no_charge", DbType = "tinyint(4)")]
    public sbyte NoCharge { get; set; } = 0;

    [JsonProperty, Column(Name = "reg_date", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime RegDate { get; set; }

    [JsonProperty, Column(Name = "slot")]
    public byte Slot { get; set; } = 0;

    [JsonProperty, Column(Name = "stat", DbType = "tinyint(4)")]
    public sbyte Stat { get; set; } = 0;

    [JsonProperty, Column(Name = "stomach")]
    public uint Stomach { get; set; } = 0;

}
