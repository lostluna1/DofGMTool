using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "inventory", DisableSyncStructure = true)]
public partial class _Inventory
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "avatar_coin")]
    public uint AvatarCoin { get; set; } = 0;

    [JsonProperty, Column(Name = "coin", DbType = "int(11) unsigned")]
    public uint Coin { get; set; } = 0;

    [JsonProperty, Column(Name = "creature", DbType = "blob")]
    public required byte[] Creature { get; set; }

    [JsonProperty, Column(Name = "creature_flag", DbType = "tinyint(4)")]
    public sbyte CreatureFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "equipslot", DbType = "blob")]
    public required byte[] Equipslot { get; set; }

    [JsonProperty, Column(Name = "event_coin", DbType = "int(11) unsigned")]
    public uint EventCoin { get; set; } = 0;

    [JsonProperty, Column(Name = "inventory", DbType = "blob")]
    public required byte[] Inventory { get; set; }

    [JsonProperty, Column(Name = "inventory_capacity")]
    public uint InventoryCapacity { get; set; } = 0;

    [JsonProperty, Column(Name = "katagaki", DbType = "blob")]
    public required byte[] Katagaki { get; set; }

    [JsonProperty, Column(Name = "money", DbType = "int(11) unsigned")]
    public uint Money { get; set; } = 0;

    [JsonProperty, Column(Name = "pay_coin", DbType = "int(11) unsigned")]
    public uint PayCoin { get; set; } = 0;

}
