using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "postal", DisableSyncStructure = false)]
public partial class _Postal
{

    [JsonProperty, Column(Name = "postal_id", IsPrimary = true, IsIdentity = true)]
    public uint PostalId { get; set; }

    [JsonProperty, Column(Name = "add_info")]
    public int AddInfo { get; set; } = 0;

    [JsonProperty, Column(Name = "amplify_option")]
    public byte AmplifyOption { get; set; } = 0;

    [JsonProperty, Column(Name = "amplify_value", DbType = "mediumint(8) unsigned")]
    public uint AmplifyValue { get; set; } = 0;

    [JsonProperty, Column(Name = "auction_id")]
    public ulong AuctionId { get; set; } = 0;

    [JsonProperty, Column(Name = "avata_flag", DbType = "tinyint(4)")]
    public sbyte AvataFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "creature_flag", DbType = "tinyint(4)")]
    public sbyte CreatureFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "delete_flag")]
    public byte DeleteFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "endurance")]
    public ushort Endurance { get; set; } = 0;

    [JsonProperty, Column(Name = "extend_info")]
    public int ExtendInfo { get; set; } = 0;

    [JsonProperty, Column(Name = "gold")]
    public uint Gold { get; set; } = 0;

    [JsonProperty, Column(Name = "ipg_db_id", DbType = "tinyint(4)")]
    public sbyte IpgDbId { get; set; } = 0;

    [JsonProperty, Column(Name = "ipg_nexon_id", StringLength = 32, IsNullable = false)]
    public string IpgNexonId { get; set; }

    [JsonProperty, Column(Name = "ipg_transaction_id")]
    public int IpgTransactionId { get; set; } = 0;

    [JsonProperty, Column(Name = "item_guid", DbType = "varbinary(10)",IsNullable =true)]
    public byte[]? ItemGuid { get; set; }

    [JsonProperty, Column(Name = "item_id")]
    public uint ItemId { get; set; } = 0;

    [JsonProperty, Column(Name = "letter_id")]
    public int LetterId { get; set; } = 0;

    [JsonProperty, Column(Name = "occ_time", DbType = "datetime")]
    public DateTime OccTime { get; set; }

    [JsonProperty, Column(Name = "postal")]
    public int Postal { get; set; } = 0;

    [JsonProperty, Column(Name = "random_option", DbType = "varbinary(14)")]
    public byte[] RandomOption { get; set; }

    [JsonProperty, Column(Name = "receive_charac_no")]
    public int ReceiveCharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "receive_time", DbType = "datetime")]
    public DateTime ReceiveTime { get; set; }

    [JsonProperty, Column(Name = "seal_flag", DbType = "tinyint(4)")]
    public sbyte SealFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "send_charac_name", StringLength = 20, IsNullable = false)]
    public string SendCharacName { get; set; }

    [JsonProperty, Column(Name = "send_charac_no")]
    public int SendCharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "seperate_upgrade")]
    public byte SeperateUpgrade { get; set; } = 0;

    [JsonProperty, Column(Name = "type")]
    public byte Type { get; set; } = 0;

    [JsonProperty, Column(Name = "unlimit_flag", DbType = "tinyint(4)")]
    public sbyte UnlimitFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "upgrade")]
    public int Upgrade { get; set; } = 0;

}
