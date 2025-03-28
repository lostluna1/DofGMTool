﻿using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "limit_create_character", DisableSyncStructure = true)]
public partial class LimitCreateCharacter
{

    [JsonProperty, Column(Name = "m_id", DbType = "int(11) unsigned", IsPrimary = true)]
    public uint MId { get; set; } = 0;

    [JsonProperty, Column(Name = "count", DbType = "int(11) unsigned")]
    public uint Count { get; set; } = 0;

    [JsonProperty, Column(Name = "last_access_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime LastAccessTime { get; set; }

}
