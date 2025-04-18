﻿using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

/// <summary>
/// gift history
/// </summary>
[JsonObject(MemberSerialization.OptIn), Table(Name = "log_gift_history", DisableSyncStructure = true)]
public partial class LogGiftHistory
{

    [JsonProperty, Column(Name = "tran_id", IsPrimary = true)]
    public ulong TranId { get; set; }

    [JsonProperty, Column(Name = "cera")]
    public uint Cera { get; set; }

    [JsonProperty, Column(Name = "item_id")]
    public uint ItemId { get; set; }

    [JsonProperty, Column(Name = "occ_date", DbType = "datetime")]
    public DateTime OccDate { get; set; }

    [JsonProperty, Column(Name = "query_user", StringLength = 45, IsNullable = false)]
    public string QueryUser { get; set; } = "None";

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
