﻿using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_log_item_refund_history_20130221_3", DisableSyncStructure = true)]
public partial class BakLogItemRefundHistory201302213
{

    [JsonProperty, Column(Name = "pf_rel_id", IsPrimary = true, IsIdentity = true)]
    public uint PfRelId { get; set; }

    [JsonProperty, Column(Name = "account_id", DbType = "char(30)", IsNullable = false)]
    public required string AccountId { get; set; }

    [JsonProperty, Column(Name = "admin_id", StringLength = 30, IsNullable = false)]
    public required string AdminId { get; set; }

    [JsonProperty, Column(Name = "occ_date", DbType = "datetime")]
    public DateTime OccDate { get; set; }

    [JsonProperty, Column(Name = "purchase_tran_id")]
    public ulong PurchaseTranId { get; set; }

    [JsonProperty, Column(Name = "reason", IsNullable = false)]
    public required string Reason { get; set; }

    [JsonProperty, Column(Name = "recharge_tran_id")]
    public ulong RechargeTranId { get; set; }

}
