using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "member_white_account", DisableSyncStructure = true)]
public partial class MemberWhiteAccount
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public uint MId { get; set; }

    [JsonProperty, Column(Name = "reg_date", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime RegDate { get; set; }

}
