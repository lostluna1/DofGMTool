using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_log_point_history_20130221_2", DisableSyncStructure = true)]
public partial class BakLogPointHistory201302212
{

    [JsonProperty, Column(Name = "no", IsPrimary = true, IsIdentity = true)]
    public uint No { get; set; }

    [JsonProperty, Column(Name = "account_id", StringLength = 30, IsNullable = false)]
    public required string AccountId { get; set; }

    [JsonProperty, Column(Name = "cera_point")]
    public uint CeraPoint { get; set; } = 0;

    [JsonProperty, Column(Name = "charac_id", StringLength = 30, IsNullable = false)]
    public required string CharacId { get; set; }

    [JsonProperty, Column(Name = "charge_type", DbType = "tinyint(4)")]
    public sbyte ChargeType { get; set; } = 0;

    /// <summary>
    /// A(add), U(use)
    /// </summary>
    [JsonProperty, Column(Name = "command")]
    public BakLogPointHistory201302212COMMAND Command { get; set; }

    [JsonProperty, Column(Name = "free_charge_type", DbType = "tinyint(4)")]
    public sbyte FreeChargeType { get; set; } = 0;

    [JsonProperty, Column(Name = "reg_date", DbType = "datetime")]
    public DateTime RegDate { get; set; }

}

public enum BakLogPointHistory201302212COMMAND
{
    A = 1, U
}
