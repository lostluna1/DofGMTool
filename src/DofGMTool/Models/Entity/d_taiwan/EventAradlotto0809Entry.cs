using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "event_aradlotto_0809_entry", DisableSyncStructure = true)]
public partial class EventAradlotto0809Entry
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "lotto_num", DbType = "char(7)", IsNullable = false)]
    public required string LottoNum { get; set; }

    [JsonProperty, Column(Name = "occ_date")]
    public int OccDate { get; set; } = 0;

}
