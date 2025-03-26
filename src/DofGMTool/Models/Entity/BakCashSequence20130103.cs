using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_cash_sequence_20130103", DisableSyncStructure = true)]
public partial class BakCashSequence20130103
{

    [JsonProperty, Column(Name = "sequence_id", IsPrimary = true, IsIdentity = true)]
    public long SequenceId { get; set; }

    [JsonProperty, Column(Name = "dummy", DbType = "char(1)", IsNullable = false)]
    public required string Dummy { get; set; }

}
