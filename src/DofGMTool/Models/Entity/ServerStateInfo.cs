﻿using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "server_state_info", DisableSyncStructure = true)]
public partial class ServerStateInfo
{

    [JsonProperty, Column(Name = "category", IsPrimary = true)]
    public int Category { get; set; } = -1;

    [JsonProperty, Column(Name = "code", IsPrimary = true)]
    public int Code { get; set; } = -1;

    [JsonProperty, Column(Name = "end_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime EndTime { get; set; }

    [JsonProperty, Column(Name = "start_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime StartTime { get; set; }

    [JsonProperty, Column(Name = "state", DbType = "binary(12)", InsertValueSql = "            ")]
    public required byte[] State { get; set; }

}
