using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "member_key_option", DisableSyncStructure = true)]
public partial class MemberKeyOption
{

    [JsonProperty, Column(Name = "key_type", DbType = "tinyint(4)", IsPrimary = true)]
    public sbyte KeyType { get; set; } = 0;

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public ulong MId { get; set; } = 0;

    [JsonProperty, Column(Name = "key_option", DbType = "blob")]
    public byte[] KeyOption { get; set; }

}
