﻿using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "member_info_detail", DisableSyncStructure = true)]
public partial class MemberInfoDetail
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "address", StringLength = 80, IsNullable = false)]
    public required string Address { get; set; }

    [JsonProperty, Column(Name = "address_detail", StringLength = 70, IsNullable = false)]
    public required string AddressDetail { get; set; }

    [JsonProperty, Column(Name = "occ_date", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime OccDate { get; set; }

    [JsonProperty, Column(Name = "zipcode", StringLength = 7, IsNullable = false)]
    public required string Zipcode { get; set; }

}
