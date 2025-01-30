using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "skill_fair_pvp", DisableSyncStructure = true)]
public partial class SkillFairPvp
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public uint CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "lethe_flag", DbType = "tinyint(4)")]
    public sbyte LetheFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "lethe_flag_2nd", DbType = "tinyint(4)")]
    public sbyte LetheFlag2nd { get; set; } = 0;

    [JsonProperty, Column(Name = "remain_sfp_1st")]
    public ushort RemainSfp1st { get; set; } = 0;

    [JsonProperty, Column(Name = "remain_sfp_2nd")]
    public ushort RemainSfp2nd { get; set; } = 0;

    [JsonProperty, Column(Name = "remain_sp")]
    public uint RemainSp { get; set; } = 0;

    [JsonProperty, Column(Name = "remain_sp_2nd")]
    public uint RemainSp2nd { get; set; } = 0;

    [JsonProperty, Column(Name = "script_version", DbType = "tinyint(4)")]
    public sbyte ScriptVersion { get; set; } = 0;

    [JsonProperty, Column(Name = "skill_command", DbType = "blob")]
    public byte[] SkillCommand { get; set; }

    [JsonProperty, Column(Name = "skill_slot", DbType = "blob")]
    public byte[] SkillSlot { get; set; }

    [JsonProperty, Column(Name = "skill_slot_2nd", DbType = "blob")]
    public byte[] SkillSlot2nd { get; set; }

    [JsonProperty, Column(Name = "skill_slot_lethe", DbType = "blob")]
    public byte[] SkillSlotLethe { get; set; }

    [JsonProperty, Column(Name = "skill_slot_lethe_2nd", DbType = "blob")]
    public byte[] SkillSlotLethe2nd { get; set; }

    [JsonProperty, Column(Name = "sp_garbage")]
    public uint SpGarbage { get; set; } = 0;

    [JsonProperty, Column(Name = "used_sp")]
    public uint UsedSp { get; set; } = 0;

}
