using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "max_count_v2", DisableSyncStructure = true)]
public partial class MaxCountV2
{

    [JsonProperty, Column(Name = "mc_date", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime McDate { get; set; }

    [JsonProperty, Column(Name = "num_login_per_min")]
    public uint NumLoginPerMin { get; set; } = 0;

    [JsonProperty, Column(Name = "num_logout_per_min")]
    public uint NumLogoutPerMin { get; set; } = 0;

    [JsonProperty, Column(Name = "num_occupations_charscreen")]
    public uint NumOccupationsCharscreen { get; set; } = 0;

    [JsonProperty, Column(Name = "num_occupations_seriaroom")]
    public uint NumOccupationsSeriaroom { get; set; } = 0;

    [JsonProperty, Column(Name = "server_info")]
    public byte ServerInfo { get; set; } = 0;

}
