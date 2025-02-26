using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "log_transaction_history", DisableSyncStructure = true)]
public partial class LogTransactionHistory
{

    [JsonProperty, Column(Name = "tran_id", IsPrimary = true)]
    public ulong TranId { get; set; }

    [JsonProperty, Column(Name = "occ_date", DbType = "datetime")]
    public DateTime OccDate { get; set; }

    [JsonProperty, Column(Name = "tran_type")]
    public byte TranType { get; set; }

}
