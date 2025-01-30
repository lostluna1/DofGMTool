using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_inven_expand", DisableSyncStructure = true)]
public partial class CharacInvenExpand
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "cargo", DbType = "blob")]
    public byte[] Cargo { get; set; }

    [JsonProperty, Column(Name = "cargo_capacity")]
    public uint CargoCapacity { get; set; } = 0;

    [JsonProperty, Column(Name = "current_equipslot", DbType = "char(1)", IsNullable = false)]
    public string CurrentEquipslot { get; set; }

    [JsonProperty, Column(Name = "expand_equipslot", DbType = "blob")]
    public byte[] ExpandEquipslot { get; set; }

    [JsonProperty, Column(Name = "jewel", DbType = "blob")]
    public byte[] Jewel { get; set; }

    [JsonProperty, Column(Name = "redeem_info", DbType = "blob")]
    public byte[] RedeemInfo { get; set; }

    [JsonProperty, Column(Name = "switch_equipslot", DbType = "blob")]
    public byte[] SwitchEquipslot { get; set; }

}
