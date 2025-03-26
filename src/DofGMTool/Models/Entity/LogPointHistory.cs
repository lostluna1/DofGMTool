using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "log_point_history", DisableSyncStructure = true)]
public partial class LogPointHistory
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
    public LogPointHistoryCOMMAND Command { get; set; }

    [JsonProperty, Column(Name = "free_charge_type", DbType = "tinyint(4)")]
    public sbyte FreeChargeType { get; set; } = 0;

    [JsonProperty, Column(Name = "item_id")]
    public uint ItemId { get; set; } = 0;

    [JsonProperty, Column(Name = "query_user", StringLength = 45, IsNullable = false)]
    public string QueryUser { get; set; } = "None";

    [JsonProperty, Column(Name = "reg_date", DbType = "datetime")]
    public DateTime RegDate { get; set; }

}

public enum LogPointHistoryCOMMAND
{
    A = 1, U
}
