using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "dnf_event_log", DisableSyncStructure = true)]
public partial class DnfEventLog
{

    [JsonProperty, Column(Name = "log_id", IsPrimary = true, IsIdentity = true)]
    public uint LogId { get; set; }

    [JsonProperty, Column(Name = "end_time")]
    public int EndTime { get; set; } = 0;

    [JsonProperty, Column(Name = "etc", StringLength = 100, IsNullable = false)]
    public string Etc { get; set; }

    [JsonProperty, Column(Name = "event_flag")]
    public sbyte? EventFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "event_type")]
    public byte EventType { get; set; } = 0;

    [JsonProperty, Column(Name = "expl", StringLength = 200, IsNullable = false)]
    public string Expl { get; set; }

    [JsonProperty, Column(Name = "m_id")]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "occ_time")]
    public int OccTime { get; set; } = 0;

    [JsonProperty, Column(Name = "parameter1")]
    public uint Parameter1 { get; set; } = 0;

    [JsonProperty, Column(Name = "parameter2")]
    public uint Parameter2 { get; set; } = 0;

    [JsonProperty, Column(Name = "server_id")]
    public byte ServerId { get; set; } = 0;

    [JsonProperty, Column(Name = "start_time")]
    public int StartTime { get; set; } = 0;

}
