using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "geo_allow_country", DisableSyncStructure = true)]
public partial class GeoAllowCountry
{

    [JsonProperty, Column(Name = "country_code", StringLength = 10, IsPrimary = true, IsNullable = false)]
    public required string CountryCode { get; set; }

    [JsonProperty, Column(Name = "server_group", DbType = "tinyint(4)", IsPrimary = true)]
    public sbyte ServerGroup { get; set; }

    [JsonProperty, Column(Name = "reg_date", DbType = "datetime")]
    public DateTime RegDate { get; set; }

}
