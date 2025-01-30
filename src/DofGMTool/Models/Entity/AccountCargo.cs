using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "account_cargo", DisableSyncStructure = true)]
public partial class AccountCargo
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public ulong MId { get; set; } = 0;

    [JsonProperty, Column(Name = "capacity")]
    public byte Capacity { get; set; } = 0;

    [JsonProperty, Column(Name = "cargo", DbType = "blob")]
    public byte[] Cargo { get; set; }

    [JsonProperty, Column(Name = "money", DbType = "int(11) unsigned")]
    public uint Money { get; set; } = 0;

    [JsonProperty, Column(Name = "occ_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime OccTime { get; set; }

}
