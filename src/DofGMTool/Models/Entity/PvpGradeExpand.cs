using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "pvp_grade_expand", DisableSyncStructure = true)]
public partial class PvpGradeExpand
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "last_play_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime LastPlayTime { get; set; }

    [JsonProperty, Column(Name = "pvp_grade")]
    public int PvpGrade { get; set; } = 0;

    [JsonProperty, Column(Name = "pvp_point")]
    public int PvpPoint { get; set; } = 0;

}
