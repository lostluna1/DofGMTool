using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "dnf_game_message", DisableSyncStructure = true)]
public partial class DnfGameMessage
{

    [JsonProperty, Column(Name = "no", IsPrimary = true, IsIdentity = true)]
    public uint No { get; set; }

    [JsonProperty, Column(Name = "display_type", DbType = "tinyint(4)")]
    public sbyte DisplayType { get; set; } = 1;

    [JsonProperty, Column(Name = "end_h")]
    public byte EndH { get; set; } = 0;

    [JsonProperty, Column(Name = "message")]
    public string Message { get; set; }

    [JsonProperty, Column(Name = "occ_date", DbType = "date", InsertValueSql = "0000-00-00")]
    public DateTime OccDate { get; set; }

    [JsonProperty, Column(Name = "start_h")]
    public byte StartH { get; set; } = 0;

}
