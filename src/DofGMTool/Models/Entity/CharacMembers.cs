using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_members", DisableSyncStructure = true)]
public partial class CharacMembers
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "create_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime CreateTime { get; set; }

    [JsonProperty, Column(Name = "delete_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime DeleteTime { get; set; }

    [JsonProperty, Column(Name = "exp")]
    public int Exp { get; set; } = 0;

    [JsonProperty, Column(Name = "master_no")]
    public int MasterNo { get; set; } = 0;

}
