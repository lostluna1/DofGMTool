using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "hack_cleanpad_ratio_info", DisableSyncStructure = true)]
public partial class HackCleanpadRatioInfo
{

    [JsonProperty, Column(Name = "hack_type", IsPrimary = true)]
    public ushort HackType { get; set; } = 0;

    [JsonProperty, Column(Name = "reg_date", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime RegDate { get; set; }

    [JsonProperty, Column(Name = "value")]
    public uint Value { get; set; } = 0;

}
