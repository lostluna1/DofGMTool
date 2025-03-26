using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "account_cargo", DisableSyncStructure = false)]
public partial class AccountCargo
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public ulong MId { get; set; } = 0;

    [JsonProperty, Column(Name = "capacity")]
    public byte Capacity { get; set; } = 0;

    [JsonProperty, Column(Name = "cargo", DbType = "blob", IsNullable = true)]
    public byte[]? Cargo { get; set; }

    [JsonProperty, Column(Name = "money", DbType = "int(11) unsigned")]
    public uint Money { get; set; } = 0;

    [JsonProperty, Column(Name = "occ_time", DbType = "datetime")]
    public DateTime OccTime { get; set; }

}
