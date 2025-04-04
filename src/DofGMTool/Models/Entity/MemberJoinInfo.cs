﻿using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "member_join_info", DisableSyncStructure = true)]
public partial class d_taiwan_MemberJoinInfo
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public uint MId { get; set; } = 0;

    [JsonProperty, Column(Name = "contry_code")]
    public byte ContryCode { get; set; } = 0;

    [JsonProperty, Column(Name = "error_type")]
    public byte ErrorType { get; set; } = 0;

    [JsonProperty, Column(Name = "game_use_history")]
    public byte GameUseHistory { get; set; } = 0;

    [JsonProperty, Column(Name = "ip", StringLength = 15, IsNullable = false)]
    public required string Ip { get; set; }

    [JsonProperty, Column(Name = "login_ip", StringLength = 15, IsNullable = false)]
    public required string LoginIp { get; set; }

    [JsonProperty, Column(Name = "login_time")]
    public int LoginTime { get; set; } = 0;

    [JsonProperty, Column(Name = "reg_date")]
    public int RegDate { get; set; } = 0;

}
