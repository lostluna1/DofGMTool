using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "member_passwd_mod", DisableSyncStructure = true)]
public partial class MemberPasswdMod
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "cnt")]
    public byte Cnt { get; set; } = 0;

    [JsonProperty, Column(Name = "first_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime FirstTime { get; set; }

    [JsonProperty, Column(Name = "last_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime LastTime { get; set; }

}
