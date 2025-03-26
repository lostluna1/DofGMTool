using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_dnf_item_info", DisableSyncStructure = true)]
public partial class BakDnfItemInfo
{

    [JsonProperty, Column(Name = "it_no", DbType = "mediumint(8) unsigned", IsPrimary = true)]
    public uint ItNo { get; set; } = 0;

    [JsonProperty, Column(Name = "att_active_status")]
    public short AttActiveStatus { get; set; } = 0;

    [JsonProperty, Column(Name = "att_active_status_pow")]
    public short AttActiveStatusPow { get; set; } = 0;

    [JsonProperty, Column(Name = "att_active_status_ratio")]
    public float AttActiveStatusRatio { get; set; } = 0f;

    [JsonProperty, Column(Name = "att_backforce")]
    public short AttBackforce { get; set; } = 0;

    [JsonProperty, Column(Name = "att_defenseIgnore", DbType = "tinyint(4)")]
    public sbyte AttDefenseIgnore { get; set; } = 0;

    [JsonProperty, Column(Name = "att_element", InsertValueSql = "'Void'")]
    public BakDnfItemInfoATTELEMENT AttElement { get; set; }

    [JsonProperty, Column(Name = "att_hp_drain", DbType = "tinyint(4)")]
    public sbyte AttHpDrain { get; set; } = 0;

    [JsonProperty, Column(Name = "att_mp_drain", DbType = "tinyint(4)")]
    public sbyte AttMpDrain { get; set; } = 0;

    [JsonProperty, Column(Name = "att_speed")]
    public short AttSpeed { get; set; } = 0;

    [JsonProperty, Column(Name = "att_upforce")]
    public short AttUpforce { get; set; } = 0;

    [JsonProperty, Column(Name = "cash")]
    public ushort Cash { get; set; } = 0;

    [JsonProperty, Column(Name = "class")]
    public byte Class { get; set; } = 0;

    [JsonProperty, Column(Name = "cooltime")]
    public short Cooltime { get; set; } = 0;

    [JsonProperty, Column(Name = "create_ratio")]
    public float CreateRatio { get; set; } = 0f;

    [JsonProperty, Column(Name = "criticalhit_rate")]
    public float CriticalhitRate { get; set; } = 0f;

    [JsonProperty, Column(Name = "durability")]
    public short Durability { get; set; } = 0;

    [JsonProperty, Column(Name = "equip_mag_att")]
    public short EquipMagAtt { get; set; } = 0;

    [JsonProperty, Column(Name = "equip_mag_def")]
    public short EquipMagDef { get; set; } = 0;

    [JsonProperty, Column(Name = "equip_phy_att")]
    public short EquipPhyAtt { get; set; } = 0;

    [JsonProperty, Column(Name = "equip_phy_def")]
    public short EquipPhyDef { get; set; } = 0;

    [JsonProperty, Column(Name = "hit_recovery")]
    public short HitRecovery { get; set; } = 0;

    [JsonProperty, Column(Name = "hp_max")]
    public short HpMax { get; set; } = 0;

    [JsonProperty, Column(Name = "hp_regenrate")]
    public short HpRegenrate { get; set; } = 0;

    [JsonProperty, Column(Name = "inven_max")]
    public short InvenMax { get; set; } = 0;

    [JsonProperty, Column(Name = "it_eng_name", StringLength = 50, IsNullable = false)]
    public string? ItEngName { get; set; }

    [JsonProperty, Column(Name = "it_explain", StringLength = 60, IsNullable = false)]
    public string? ItExplain { get; set; }

    [JsonProperty, Column(Name = "it_name", StringLength = 25, IsNullable = false)]
    public string? ItName { get; set; }

    [JsonProperty, Column(Name = "jewel_type", StringLength = 5, IsNullable = false)]
    public string? JewelType { get; set; }

    [JsonProperty, Column(Name = "job", StringLength = 12, IsNullable = false)]
    public string? Job { get; set; }

    [JsonProperty, Column(Name = "jump")]
    public short Jump { get; set; } = 0;

    [JsonProperty, Column(Name = "level")]
    public byte Level { get; set; } = 0;

    [JsonProperty, Column(Name = "mag_att")]
    public short MagAtt { get; set; } = 0;

    [JsonProperty, Column(Name = "mag_def")]
    public short MagDef { get; set; } = 0;

    [JsonProperty, Column(Name = "master_type")]
    public byte MasterType { get; set; } = 0;

    [JsonProperty, Column(Name = "medal")]
    public ushort Medal { get; set; } = 0;

    [JsonProperty, Column(Name = "mov_speed")]
    public short MovSpeed { get; set; } = 0;

    [JsonProperty, Column(Name = "mp_max")]
    public short MpMax { get; set; } = 0;

    [JsonProperty, Column(Name = "mp_regenrate")]
    public short MpRegenrate { get; set; } = 0;

    [JsonProperty, Column(Name = "phy_att")]
    public short PhyAtt { get; set; } = 0;

    [JsonProperty, Column(Name = "phy_def")]
    public short PhyDef { get; set; } = 0;

    [JsonProperty, Column(Name = "price")]
    public ushort Price { get; set; } = 0;

    [JsonProperty, Column(Name = "quest")]
    public short Quest { get; set; } = 0;

    [JsonProperty, Column(Name = "rarity")]
    public byte Rarity { get; set; } = 0;

    [JsonProperty, Column(Name = "ref_all", DbType = "tinyint(4)")]
    public sbyte RefAll { get; set; } = 0;

    [JsonProperty, Column(Name = "ref_all_stat", DbType = "tinyint(4)")]
    public sbyte RefAllStat { get; set; } = 0;

    [JsonProperty, Column(Name = "ref_bleeding", DbType = "tinyint(4)")]
    public sbyte RefBleeding { get; set; } = 0;

    [JsonProperty, Column(Name = "ref_blind", DbType = "tinyint(4)")]
    public sbyte RefBlind { get; set; } = 0;

    [JsonProperty, Column(Name = "ref_confuse", DbType = "tinyint(4)")]
    public sbyte RefConfuse { get; set; } = 0;

    [JsonProperty, Column(Name = "ref_cus", DbType = "tinyint(4)")]
    public sbyte RefCus { get; set; } = 0;

    [JsonProperty, Column(Name = "ref_dark", DbType = "tinyint(4)")]
    public sbyte RefDark { get; set; } = 0;

    [JsonProperty, Column(Name = "ref_deadlystrike", DbType = "tinyint(4)")]
    public sbyte RefDeadlystrike { get; set; } = 0;

    [JsonProperty, Column(Name = "ref_deekement", DbType = "tinyint(4)")]
    public sbyte RefDeekement { get; set; } = 0;

    [JsonProperty, Column(Name = "ref_fire", DbType = "tinyint(4)")]
    public sbyte RefFire { get; set; } = 0;

    [JsonProperty, Column(Name = "ref_freeze", DbType = "tinyint(4)")]
    public sbyte RefFreeze { get; set; } = 0;

    [JsonProperty, Column(Name = "ref_hold", DbType = "tinyint(4)")]
    public sbyte RefHold { get; set; } = 0;

    [JsonProperty, Column(Name = "ref_light", DbType = "tinyint(4)")]
    public sbyte RefLight { get; set; } = 0;

    [JsonProperty, Column(Name = "ref_lite", DbType = "tinyint(4)")]
    public sbyte RefLite { get; set; } = 0;

    [JsonProperty, Column(Name = "ref_pierce")]
    public short RefPierce { get; set; } = 0;

    [JsonProperty, Column(Name = "ref_poison", DbType = "tinyint(4)")]
    public sbyte RefPoison { get; set; } = 0;

    [JsonProperty, Column(Name = "ref_sleep", DbType = "tinyint(4)")]
    public sbyte RefSleep { get; set; } = 0;

    [JsonProperty, Column(Name = "ref_slow", DbType = "tinyint(4)")]
    public sbyte RefSlow { get; set; } = 0;

    [JsonProperty, Column(Name = "ref_ston", DbType = "tinyint(4)")]
    public sbyte RefSton { get; set; } = 0;

    [JsonProperty, Column(Name = "ref_stuck")]
    public short RefStuck { get; set; } = 0;

    [JsonProperty, Column(Name = "ref_stun", DbType = "tinyint(4)")]
    public sbyte RefStun { get; set; } = 0;

    [JsonProperty, Column(Name = "ref_water", DbType = "tinyint(4)")]
    public sbyte RefWater { get; set; } = 0;

    [JsonProperty, Column(Name = "revert", StringLength = 5, IsNullable = false)]
    public string? Revert { get; set; }

    [JsonProperty, Column(Name = "set_type", InsertValueSql = "'n'")]
    public BakDnfItemInfoSETTYPE SetType { get; set; }

    [JsonProperty, Column(Name = "skill")]
    public ushort Skill { get; set; } = 0;

    [JsonProperty, Column(Name = "skill_levelup", StringLength = 25, IsNullable = false)]
    public string? SkillLevelup { get; set; }

    [JsonProperty, Column(Name = "stuck_rate")]
    public float StuckRate { get; set; } = 0f;

    [JsonProperty, Column(Name = "sub_type")]
    public ushort SubType { get; set; } = 0;

    [JsonProperty, Column(Name = "url", StringLength = 64, IsNullable = false)]
    public string? Url { get; set; }

    [JsonProperty, Column(Name = "weight")]
    public short Weight { get; set; } = 0;

}

public enum BakDnfItemInfoATTELEMENT
{
    Void = 1, Fire, Water, Dark, Light
}
public enum BakDnfItemInfoSETTYPE
{
    n = 1, y
}
