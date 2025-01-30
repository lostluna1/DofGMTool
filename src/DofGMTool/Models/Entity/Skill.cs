using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "skill", DisableSyncStructure = true)]
public partial class Skill
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "lethe_flag", DbType = "tinyint(4)")]
    public sbyte LetheFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "lethe_flag_2nd", DbType = "tinyint(4)")]
    public sbyte LetheFlag2nd { get; set; } = 0;

    [JsonProperty, Column(Name = "remain_sfp_1st", DbType = "int(11) unsigned")]
    public uint RemainSfp1st { get; set; } = 0;

    [JsonProperty, Column(Name = "remain_sfp_2nd", DbType = "int(11) unsigned")]
    public uint RemainSfp2nd { get; set; } = 0;

    [JsonProperty, Column(Name = "remain_sp", DbType = "int(11) unsigned")]
    public uint RemainSp { get; set; } = 0;

    [JsonProperty, Column(Name = "remain_sp_2nd", DbType = "int(11) unsigned")]
    public uint RemainSp2nd { get; set; } = 0;

    [JsonProperty, Column(Name = "request_sp", DbType = "blob")]
    public byte[] RequestSp { get; set; }

    [JsonProperty, Column(Name = "request_sp_2nd", DbType = "blob")]
    public byte[] RequestSp2nd { get; set; }

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

    [JsonProperty, Column(Name = "sp_garbage", DbType = "int(11) unsigned")]
    public uint SpGarbage { get; set; } = 0;

    [JsonProperty, Column(Name = "used_sp", DbType = "int(11) unsigned")]
    public uint UsedSp { get; set; } = 0;

}
