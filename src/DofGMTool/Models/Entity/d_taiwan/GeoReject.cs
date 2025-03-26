using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "geo_reject", DisableSyncStructure = true)]
public partial class GeoReject
{

    [JsonProperty, Column(Name = "rej_ip", StringLength = 20, IsPrimary = true, IsNullable = false)]
    public required string RejIp { get; set; }

    [JsonProperty, Column(Name = "rej_c_code", StringLength = 4, IsNullable = false)]
    public required string RejCCode { get; set; }

    [JsonProperty, Column(Name = "rej_chk", DbType = "char(1)", IsNullable = false)]
    public string RejChk { get; set; } = "N";

    [JsonProperty, Column(Name = "rej_ip_count", DbType = "int(11) unsigned")]
    public uint RejIpCount { get; set; } = 0;

    [JsonProperty, Column(Name = "rej_last_date", DbType = "timestamp", InsertValueSql = "CURRENT_TIMESTAMP")]
    public DateTime RejLastDate { get; set; }

    [JsonProperty, Column(Name = "rej_src", InsertValueSql = "'w'")]
    public GeoRejectREJSRC RejSrc { get; set; }

}

public enum GeoRejectREJSRC
{
    w = 1, g
}
