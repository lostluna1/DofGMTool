using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "event_goldcard_cnt", DisableSyncStructure = true)]
public partial class EventGoldcardCnt
{

    [JsonProperty, Column(Name = "item_no", DbType = "int(10)", IsPrimary = true)]
    public int ItemNo { get; set; } = 0;

    [JsonProperty, Column(Name = "occ_date", DbType = "date", IsPrimary = true, InsertValueSql = "0000-00-00")]
    public DateTime OccDate { get; set; }

    [JsonProperty, Column(Name = "cnt")]
    public int Cnt { get; set; } = 0;

}
