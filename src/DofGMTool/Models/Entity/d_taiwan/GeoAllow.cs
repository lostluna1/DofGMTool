using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "geo_allow", DisableSyncStructure = true)]
public partial class GeoAllow
{

    [JsonProperty, Column(Name = "allow_ip", StringLength = 20, IsPrimary = true, IsNullable = false)]
    public required string AllowIp { get; set; }

    [JsonProperty, Column(Name = "allow_c_code", StringLength = 4, IsNullable = false)]
    public required string AllowCCode { get; set; }

    [JsonProperty, Column(Name = "allow_date", DbType = "timestamp", InsertValueSql = "CURRENT_TIMESTAMP")]
    public DateTime AllowDate { get; set; }

}
