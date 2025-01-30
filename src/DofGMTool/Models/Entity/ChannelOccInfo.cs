using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "channel_occ_info", DisableSyncStructure = true)]
public partial class ChannelOccInfo
{

    [JsonProperty, Column(Name = "age", IsPrimary = true)]
    public byte Age { get; set; } = 0;

    [JsonProperty, Column(Name = "gc_no", IsPrimary = true)]
    public uint GcNo { get; set; } = 0;

    [JsonProperty, Column(Name = "occ_num")]
    public short OccNum { get; set; } = 0;

}
