using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "event_dungeon_clear", DisableSyncStructure = true)]
public partial class EventDungeonClear
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public uint CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "clear_cnt")]
    public uint ClearCnt { get; set; } = 0;

    [JsonProperty, Column(Name = "update_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime UpdateTime { get; set; }

}
