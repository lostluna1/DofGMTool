using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "cash_cera_point", DisableSyncStructure = true)]
public partial class CashCeraPoint
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
