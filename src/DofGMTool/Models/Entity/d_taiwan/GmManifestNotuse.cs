﻿using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "gm_manifest_notuse", DisableSyncStructure = true)]
public partial class GmManifestNotuse
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "level")]
    public byte Level { get; set; } = 0;

}
