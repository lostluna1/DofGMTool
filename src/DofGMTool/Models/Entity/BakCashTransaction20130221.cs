﻿using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_cash_transaction_20130221", DisableSyncStructure = true)]
public partial class BakCashTransaction20130221
{

    [JsonProperty, Column(Name = "tran_id", IsPrimary = true, IsIdentity = true)]
    public long TranId { get; set; }

    [JsonProperty, Column(Name = "dummy", DbType = "char(1)", IsNullable = false)]
    public string Dummy { get; set; }

}
