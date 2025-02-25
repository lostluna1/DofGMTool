using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "game_channel", DisableSyncStructure = true)]
public partial class d_taiwan_GameChannel
{

    [JsonProperty, Column(Name = "gc_no", DbType = "int(11) unsigned", IsPrimary = true, IsIdentity = true)]
    public uint GcNo { get; set; }

    [JsonProperty, Column(Name = "gc_ch_group", DbType = "smallint(5)")]
    public short GcChGroup { get; set; } = 0;

    [JsonProperty, Column(Name = "gc_channel", DbType = "char(16)", IsNullable = false)]
    public string GcChannel { get; set; }

    [JsonProperty, Column(Name = "gc_channeltype", DbType = "char(0)", IsNullable = false)]
    public string GcChanneltype { get; set; }

    [JsonProperty, Column(Name = "gc_game")]
    public byte GcGame { get; set; } = 0;

    [JsonProperty, Column(Name = "gc_ip", DbType = "char(32)", IsNullable = false)]
    public string GcIp { get; set; }

    [JsonProperty, Column(Name = "gc_max")]
    public ushort GcMax { get; set; } = 0;

    [JsonProperty, Column(Name = "gc_now")]
    public ushort GcNow { get; set; } = 0;

    [JsonProperty, Column(Name = "gc_port")]
    public ushort GcPort { get; set; } = 0;

}
