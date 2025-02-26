using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

/// <summary>
/// issue transaction history
/// </summary>
[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_log_issue_tran_history_20130219", DisableSyncStructure = true)]
public partial class BakLogIssueTranHistory20130219
{

    [JsonProperty, Column(Name = "tran_id", IsPrimary = true)]
    public ulong TranId { get; set; }

    [JsonProperty, Column(Name = "occ_date", DbType = "datetime")]
    public DateTime OccDate { get; set; }

    [JsonProperty, Column(Name = "tran_type")]
    public byte TranType { get; set; }

}
