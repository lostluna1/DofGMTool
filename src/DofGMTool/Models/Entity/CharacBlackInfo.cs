using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_black_info", DisableSyncStructure = true)]
public partial class CharacBlackInfo
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public uint CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "black_point")]
    public ushort BlackPoint { get; set; } = 0;

    [JsonProperty, Column(Name = "offset_point")]
    public ushort OffsetPoint { get; set; } = 0;

    [JsonProperty, Column(Name = "problem_child_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime ProblemChildTime { get; set; }

}
