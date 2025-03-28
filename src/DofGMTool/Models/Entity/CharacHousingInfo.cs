﻿using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_housing_info", DisableSyncStructure = true)]
public partial class CharacHousingInfo
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public uint CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "decoration_inven", DbType = "binary(144)", InsertValueSql = "                                                                                                                                                ")]
    public required byte[] DecorationInven { get; set; }

    [JsonProperty, Column(Name = "installed")]
    public ushort Installed { get; set; } = 0;

    [JsonProperty, Column(Name = "version")]
    public ushort Version { get; set; } = 0;

}
