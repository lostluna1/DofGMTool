using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "geo_country_code", DisableSyncStructure = true)]
public partial class GeoCountryCode
{

    [JsonProperty, Column(Name = "code_no", IsPrimary = true)]
    public int CodeNo { get; set; }

    [JsonProperty, Column(Name = "country", IsNullable = false)]
    public string Country { get; set; }

    [JsonProperty, Column(Name = "country_code_a2", StringLength = 10, IsNullable = false)]
    public string CountryCodeA2 { get; set; }

    [JsonProperty, Column(Name = "country_code_a3", StringLength = 10, IsNullable = false)]
    public string CountryCodeA3 { get; set; }

}
