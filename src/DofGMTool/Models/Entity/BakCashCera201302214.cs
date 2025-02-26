using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_cash_cera_20130221_4", DisableSyncStructure = true)]
public partial class BakCashCera201302214
{

    [JsonProperty, Column(Name = "account", StringLength = 30, IsPrimary = true, IsNullable = false)]
    public string Account { get; set; }

    [JsonProperty, Column(Name = "cera")]
    public uint Cera { get; set; }

    [JsonProperty, Column(Name = "mod_date", DbType = "datetime")]
    public DateTime ModDate { get; set; }

    [JsonProperty, Column(Name = "mod_tran")]
    public ulong ModTran { get; set; }

    [JsonProperty, Column(Name = "reg_date", DbType = "datetime")]
    public DateTime RegDate { get; set; }

}
