using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_cash_cera_point_20130221_3", DisableSyncStructure = true)]
public partial class BakCashCeraPoint201302213
{

    [JsonProperty, Column(Name = "account", StringLength = 30, IsPrimary = true, IsNullable = false)]
    public required string Account { get; set; }

    [JsonProperty, Column(Name = "cera_point")]
    public uint CeraPoint { get; set; }

    [JsonProperty, Column(Name = "mod_date", DbType = "datetime")]
    public DateTime ModDate { get; set; }

    [JsonProperty, Column(Name = "reg_date", DbType = "datetime")]
    public DateTime RegDate { get; set; }

}
