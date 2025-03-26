using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "cs_table2", DisableSyncStructure = true)]
public partial class CsTable2
{

    [JsonProperty, Column(Name = "account_id", DbType = "char(30)", IsNullable = false)]
    public required string AccountId { get; set; }

    [JsonProperty, Column(Name = "charac_id", DbType = "char(30)", IsNullable = false)]
    public required string CharacId { get; set; }

}
