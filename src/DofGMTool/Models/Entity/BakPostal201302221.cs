using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_postal_20130222_1", DisableSyncStructure = true)]
public partial class BakPostal201302221
{

    [JsonProperty, Column(Name = "item_id")]
    public uint ItemId { get; set; } = 0;

    [JsonProperty, Column(Name = "occ_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime OccTime { get; set; }

    [JsonProperty, Column(Name = "receive_charac_no")]
    public int ReceiveCharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "send_charac_name", StringLength = 20, IsNullable = false)]
    public required string SendCharacName { get; set; }

    [JsonProperty, Column(Name = "send_charac_no")]
    public int SendCharacNo { get; set; } = 0;

}
