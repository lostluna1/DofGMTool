using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_view", DisableSyncStructure = true)]
public partial class CharacView
{

    [JsonProperty, Column(Name = "m_id", IsPrimary = true)]
    public uint MId { get; set; } = 0;

    [JsonProperty, Column(Name = "charac_count")]
    public byte CharacCount { get; set; } = 0;

    [JsonProperty, Column(Name = "charac_slot_limit")]
    public byte CharacSlotLimit { get; set; } = 18;

    [JsonProperty, Column(Name = "hash_key", StringLength = 32, IsNullable = false)]
    public required string HashKey { get; set; }

    [JsonProperty, Column(Name = "info", DbType = "blob")]
    public required byte[] Info { get; set; }

    [JsonProperty, Column(Name = "slot_effect_count")]
    public byte SlotEffectCount { get; set; } = 18;

}
