using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "event_charac_mov_1th", DisableSyncStructure = true)]
public partial class EventCharacMov1th
{

    [JsonProperty, Column(Name = "id", IsPrimary = true, IsIdentity = true)]
    public int Id { get; set; }

    [JsonProperty, Column(Name = "charac_no")]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "m_id")]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "move_charac_no")]
    public int MoveCharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "move_check")]
    public int MoveCheck { get; set; } = 0;

    [JsonProperty, Column(Name = "move_server_id", DbType = "tinyint(4)")]
    public sbyte MoveServerId { get; set; } = 0;

    [JsonProperty, Column(Name = "server_id", DbType = "tinyint(4)")]
    public sbyte ServerId { get; set; } = 0;

}
