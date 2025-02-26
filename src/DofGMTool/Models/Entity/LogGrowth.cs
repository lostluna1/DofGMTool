using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "log_growth", DisableSyncStructure = true)]
public partial class LogGrowth
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "server_info", IsPrimary = true)]
    public byte ServerInfo { get; set; } = 0;

    [JsonProperty, Column(Name = "charac_name", StringLength = 25, IsNullable = false)]
    public string CharacName { get; set; }

    [JsonProperty, Column(Name = "grow_type")]
    public byte GrowType { get; set; } = 0;

    [JsonProperty, Column(Name = "job")]
    public byte Job { get; set; } = 0;

    [JsonProperty, Column(Name = "occ_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime OccTime { get; set; }

}
