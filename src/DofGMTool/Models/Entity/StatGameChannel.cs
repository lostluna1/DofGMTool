using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "stat_game_channel", DisableSyncStructure = true)]
public partial class StatGameChannel
{

    [JsonProperty, Column(Name = "gc_channel", StringLength = 10, IsNullable = false)]
    public required string GcChannel { get; set; }

    [JsonProperty, Column(Name = "gc_now")]
    public short GcNow { get; set; } = 0;

    [JsonProperty, Column(Name = "gc_up_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime GcUpTime { get; set; }

}
