﻿using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

/// <summary>
/// recharge history
/// </summary>
[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_log_recharge_history_20130103", DisableSyncStructure = true)]
public partial class BakLogRechargeHistory20130103
{

    [JsonProperty, Column(Name = "tran_id", IsPrimary = true)]
    public ulong TranId { get; set; }

    [JsonProperty, Column(Name = "account_id", StringLength = 30, IsNullable = false)]
    public string AccountId { get; set; }

    [JsonProperty, Column(Name = "after_cera")]
    public uint AfterCera { get; set; }

    [JsonProperty, Column(Name = "befor_cera")]
    public uint BeforCera { get; set; }

    [JsonProperty, Column(Name = "cera")]
    public uint Cera { get; set; }

    [JsonProperty, Column(Name = "charac_id", StringLength = 30, IsNullable = false)]
    public string CharacId { get; set; }

    [JsonProperty, Column(Name = "charge_type")]
    public byte ChargeType { get; set; }

    [JsonProperty, Column(Name = "occ_date", DbType = "datetime")]
    public DateTime OccDate { get; set; }

    [JsonProperty, Column(Name = "tran_state")]
    public byte TranState { get; set; }

}
