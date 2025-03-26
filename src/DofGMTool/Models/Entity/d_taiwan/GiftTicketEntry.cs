using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "gift_ticket_entry", DisableSyncStructure = true)]
public partial class GiftTicketEntry
{

    [JsonProperty, Column(Name = "id", IsPrimary = true, IsIdentity = true)]
    public uint Id { get; set; }

    [JsonProperty, Column(Name = "buyer_check")]
    public uint BuyerCheck { get; set; } = 0;

    [JsonProperty, Column(Name = "buyer_code", StringLength = 21, IsNullable = false)]
    public required string BuyerCode { get; set; }

    [JsonProperty, Column(Name = "buyer_date")]
    public uint BuyerDate { get; set; } = 0;

    [JsonProperty, Column(Name = "buyer_id")]
    public uint BuyerId { get; set; } = 0;

    [JsonProperty, Column(Name = "gift_no")]
    public ushort GiftNo { get; set; } = 0;

    [JsonProperty, Column(Name = "message", StringLength = 200, IsNullable = false)]
    public required string Message { get; set; }

    [JsonProperty, Column(Name = "other_check")]
    public uint OtherCheck { get; set; } = 0;

    [JsonProperty, Column(Name = "other_code", StringLength = 21, IsNullable = false)]
    public required string OtherCode { get; set; }

    [JsonProperty, Column(Name = "other_date")]
    public uint OtherDate { get; set; } = 0;

    [JsonProperty, Column(Name = "other_id")]
    public uint OtherId { get; set; } = 0;

}
