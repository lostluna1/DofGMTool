using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "member_game_option_1", DisableSyncStructure = true)]
public partial class MemberGameOption1
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "option_1", DbType = "blob")]
    public byte[] Option1 { get; set; }

    [JsonProperty, Column(Name = "option_2", DbType = "blob")]
    public byte[] Option2 { get; set; }

    [JsonProperty, Column(Name = "option_3", DbType = "blob")]
    public byte[] Option3 { get; set; }

}
