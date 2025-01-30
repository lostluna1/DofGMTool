using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "pvp_grade_ref", DisableSyncStructure = true)]
public partial class PvpGradeRef
{

    [JsonProperty, Column(Name = "grade", IsPrimary = true)]
    public int Grade { get; set; } = 0;

    [JsonProperty, Column(Name = "limit_pts")]
    public int LimitPts { get; set; } = 0;

}
