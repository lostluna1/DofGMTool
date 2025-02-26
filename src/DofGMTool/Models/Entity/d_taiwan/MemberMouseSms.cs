using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "member_mouse_sms", DisableSyncStructure = true)]
public partial class MemberMouseSms
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "cnt")]
    public byte Cnt { get; set; } = 0;

    [JsonProperty, Column(Name = "occ_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime OccTime { get; set; }

}
