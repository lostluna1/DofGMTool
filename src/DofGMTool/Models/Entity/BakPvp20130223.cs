using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_pvp_20130223", DisableSyncStructure = true)]
public partial class BakPvp20130223
{

    [JsonProperty, Column(Name = "charac_no")]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "last_play_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime LastPlayTime { get; set; }

}
