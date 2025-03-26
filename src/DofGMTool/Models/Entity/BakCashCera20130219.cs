using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_cash_cera_20130219", DisableSyncStructure = true)]
public partial class BakCashCera20130219
{

    [JsonProperty, Column(Name = "account", StringLength = 30, IsPrimary = true, IsNullable = false)]
    public required string Account { get; set; }

    [JsonProperty, Column(Name = "cera")]
    public uint Cera { get; set; }

    [JsonProperty, Column(Name = "mod_date", DbType = "datetime")]
    public DateTime ModDate { get; set; }

    [JsonProperty, Column(Name = "mod_tran")]
    public ulong ModTran { get; set; }

    [JsonProperty, Column(Name = "reg_date", DbType = "datetime")]
    public DateTime RegDate { get; set; }

}
