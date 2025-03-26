using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

/// <summary>
/// gift history
/// </summary>
[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_log_gift_history_20130221_4", DisableSyncStructure = true)]
public partial class BakLogGiftHistory201302214
{

    [JsonProperty, Column(Name = "tran_id", IsPrimary = true)]
    public ulong TranId { get; set; }

    [JsonProperty, Column(Name = "cera")]
    public uint Cera { get; set; }

    [JsonProperty, Column(Name = "item_id")]
    public uint ItemId { get; set; }

    [JsonProperty, Column(Name = "occ_date", DbType = "datetime")]
    public DateTime OccDate { get; set; }

    [JsonProperty, Column(Name = "recv_account_id", StringLength = 30, IsNullable = false)]
    public required string RecvAccountId { get; set; }

    [JsonProperty, Column(Name = "recv_after_cera")]
    public uint RecvAfterCera { get; set; }

    [JsonProperty, Column(Name = "recv_befor_cera")]
    public uint RecvBeforCera { get; set; }

    [JsonProperty, Column(Name = "send_account_id", StringLength = 30, IsNullable = false)]
    public required string SendAccountId { get; set; }

    [JsonProperty, Column(Name = "send_after_cera")]
    public uint SendAfterCera { get; set; }

    [JsonProperty, Column(Name = "send_befor_cera")]
    public uint SendBeforCera { get; set; }

    [JsonProperty, Column(Name = "send_charac_id", StringLength = 30, IsNullable = false)]
    public required string SendCharacId { get; set; }

    [JsonProperty, Column(Name = "tran_state")]
    public byte TranState { get; set; }

}
