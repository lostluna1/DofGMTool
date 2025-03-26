using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "dnf_pcroom", DisableSyncStructure = true)]
public partial class d_taiwan_DnfPcroom
{
    [JsonProperty, Column(Name = "ip_no", IsPrimary = true, IsIdentity = true)]
    public int IpNo { get; set; }

    [JsonProperty, Column(Name = "address", StringLength = 75, IsNullable = false)]
    public required string Address { get; set; }

    [JsonProperty, Column(Name = "district", StringLength = 10, IsNullable = false)]
    public required string District { get; set; }

    [JsonProperty, Column(Name = "end_ip", StringLength = 7, IsNullable = false)]
    public required string EndIp { get; set; }

    [JsonProperty, Column(Name = "firm_name", StringLength = 25, IsNullable = false)]
    public required string FirmName { get; set; }

    [JsonProperty, Column(Name = "leader", StringLength = 15, IsNullable = false)]
    public required string Leader { get; set; }

    [JsonProperty, Column(Name = "start_ip", StringLength = 7, IsNullable = false)]
    public required string StartIp { get; set; }

    [JsonProperty, Column(Name = "telephone", StringLength = 10, IsNullable = false)]
    public required string Telephone { get; set; }
}

