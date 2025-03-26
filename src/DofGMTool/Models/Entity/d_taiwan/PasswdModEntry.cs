using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "passwd_mod_entry", DisableSyncStructure = true)]
public partial class PasswdModEntry
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "occ_time", DbType = "datetime", IsPrimary = true, InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime OccTime { get; set; }

    [JsonProperty, Column(Name = "ip", StringLength = 15, IsNullable = false)]
    public required string Ip { get; set; }

    [JsonProperty, Column(Name = "pre_passwd", StringLength = 32, IsNullable = false)]
    public required string PrePasswd { get; set; }

}
