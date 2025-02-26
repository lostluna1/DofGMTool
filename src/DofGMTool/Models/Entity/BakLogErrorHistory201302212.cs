﻿using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_log_error_history_20130221_2", DisableSyncStructure = true)]
public partial class BakLogErrorHistory201302212
{

    [JsonProperty, Column(Name = "no", IsPrimary = true, IsIdentity = true)]
    public uint No { get; set; }

    [JsonProperty, Column(Name = "error_id", DbType = "int(10)")]
    public int ErrorId { get; set; }

    [JsonProperty, Column(Name = "error_msg", IsNullable = false)]
    public string ErrorMsg { get; set; }

    [JsonProperty, Column(Name = "error_query", StringLength = 512, IsNullable = false)]
    public string ErrorQuery { get; set; }

    [JsonProperty, Column(Name = "occ_date", DbType = "datetime")]
    public DateTime OccDate { get; set; }

    [JsonProperty, Column(Name = "proc_line", DbType = "int(10)")]
    public int ProcLine { get; set; }

    [JsonProperty, Column(Name = "proc_name", StringLength = 45, IsNullable = false)]
    public string ProcName { get; set; }

}
