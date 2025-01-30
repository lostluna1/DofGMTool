using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_link_message", DisableSyncStructure = true)]
public partial class CharacLinkMessage
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public uint MId { get; set; } = 0;

    [JsonProperty, Column(Name = "message_flag", DbType = "tinyint(4)")]
    public sbyte MessageFlag { get; set; } = 0;

}
