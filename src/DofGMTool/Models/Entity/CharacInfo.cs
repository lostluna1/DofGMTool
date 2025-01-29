using FreeSql.DataAnnotations;
using Newtonsoft.Json;
//using SqlSugar;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_info", DisableSyncStructure = true)]
public partial class CharacInfo
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true, IsIdentity = true)]
    public int CharacNo { get; set; }

    [JsonProperty, Column(Name = "attack_speed", DbType = "smallint(6) unsigned")]
    public ushort AttackSpeed { get; set; } = 0;

    [JsonProperty, Column(Name = "cast_speed", DbType = "smallint(6) unsigned")]
    public ushort CastSpeed { get; set; } = 0;

    [JsonProperty, Column(Name = "charac_name", DbType = "varchar", StringLength = 20, IsNullable = false)]
    public string CharacName { get; set; }

    [JsonProperty, Column(Name = "charac_weight")]
    public int CharacWeight { get; set; } = 0;

    [JsonProperty, Column(Name = "competition_area", DbType = "tinyint(2)")]
    public sbyte CompetitionArea { get; set; } = -1;

    [JsonProperty, Column(Name = "competition_period", DbType = "tinyint(2)")]
    public sbyte CompetitionPeriod { get; set; } = -1;

    //[JsonProperty, Column(Name = "create_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    //public DateTime CreateTime { get; set; }

    [JsonProperty, Column(Name = "delete_flag", DbType = "tinyint(4)")]
    public sbyte DeleteFlag { get; set; } = 0;

    //[JsonProperty, Column(Name = "delete_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    //public DateTime DeleteTime { get; set; }

    [JsonProperty, Column(Name = "dungeon_clear_point")]
    public int DungeonClearPoint { get; set; } = 0;

    [JsonProperty, Column(Name = "element_resist", DbType = "tinyblob")]
    public byte[] ElementResist { get; set; }

    [JsonProperty, Column(Name = "event_charac_level", DbType = "tinyint(4)")]
    public sbyte EventCharacLevel { get; set; } = 0;

    [JsonProperty, Column(Name = "exp")]
    public int Exp { get; set; } = 0;

    [JsonProperty, Column(Name = "expert_job")]
    public byte ExpertJob { get; set; } = 0;

    [JsonProperty, Column(Name = "fatigue")]
    public short Fatigue { get; set; } = 0;

    [JsonProperty, Column(Name = "finish_time")]
    public int FinishTime { get; set; } = 0;

    [JsonProperty, Column(Name = "grow_type", DbType = "tinyint(4)")]
    public sbyte GrowType { get; set; } = 0;

    [JsonProperty, Column(Name = "guild_id")]
    public uint GuildId { get; set; } = 0;

    [JsonProperty, Column(Name = "guild_right", DbType = "tinyint(4)")]
    public sbyte GuildRight { get; set; } = 0;

    [JsonProperty, Column(Name = "guild_secede", DbType = "tinyint(2)")]
    public sbyte GuildSecede { get; set; } = 0;

    [JsonProperty, Column(Name = "hit_recovery")]
    public short HitRecovery { get; set; } = 0;

    [JsonProperty]
    public byte HP { get; set; } = 0;

    [JsonProperty, Column(Name = "hp_regen")]
    public short HpRegen { get; set; } = 0;

    [JsonProperty, Column(Name = "inven_weight", DbType = "int(6)")]
    public int InvenWeight { get; set; } = 0;

    [JsonProperty, Column(Name = "job", DbType = "tinyint(4)")]
    public sbyte Job { get; set; } = 0;

    [JsonProperty, Column(Name = "jump")]
    public short Jump { get; set; } = 0;

    //[JsonProperty, Column(Name = "last_play_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    //public DateTime LastPlayTime { get; set; }

    [JsonProperty, Column(Name = "lev", DbType = "tinyint(4)")]
    public sbyte Lev { get; set; } = 1;

    [JsonProperty, Column(Name = "link_charac_no")]
    public uint LinkCharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "m_id")]
    public int MId { get; set; } = 0;

    [JsonProperty, Column(Name = "mag_attack", DbType = "smallint(6) unsigned")]
    public ushort MagAttack { get; set; } = 0;

    [JsonProperty, Column(Name = "mag_defense", DbType = "smallint(6) unsigned")]
    public ushort MagDefense { get; set; } = 0;

    [JsonProperty, Column(Name = "max_fatigue")]
    public short MaxFatigue { get; set; } = 70;

    [JsonProperty, Column(Name = "max_premium_fatigue")]
    public short MaxPremiumFatigue { get; set; } = 0;

    [JsonProperty, Column(Name = "maxHP", DbType = "smallint(6) unsigned")]
    public ushort MaxHP { get; set; } = 0;

    [JsonProperty, Column(Name = "maxMP", DbType = "smallint(6) unsigned")]
    public ushort MaxMP { get; set; } = 0;

    [JsonProperty, Column(Name = "member_flag", DbType = "tinyint(4)")]
    public sbyte MemberFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "mercenary_area", DbType = "tinyint(4)")]
    public sbyte MercenaryArea { get; set; } = -1;

    [JsonProperty, Column(Name = "mercenary_finish_time")]
    public int MercenaryFinishTime { get; set; } = 0;

    [JsonProperty, Column(Name = "mercenary_period", DbType = "tinyint(4)")]
    public sbyte MercenaryPeriod { get; set; } = -1;

    [JsonProperty, Column(Name = "mercenary_start_time")]
    public int MercenaryStartTime { get; set; } = 0;

    [JsonProperty, Column(Name = "move_speed", DbType = "smallint(6) unsigned")]
    public ushort MoveSpeed { get; set; } = 0;

    [JsonProperty, Column(Name = "mp_regen")]
    public short MpRegen { get; set; } = 0;

    [JsonProperty, Column(Name = "phy_attack", DbType = "smallint(6) unsigned")]
    public ushort PhyAttack { get; set; } = 0;

    [JsonProperty, Column(Name = "phy_defense", DbType = "smallint(6) unsigned")]
    public ushort PhyDefense { get; set; } = 0;

    [JsonProperty, Column(Name = "premium_fatigue")]
    public short PremiumFatigue { get; set; } = 0;

    [JsonProperty, Column(Name = "sex", DbType = "tinyint(4)")]
    public sbyte Sex { get; set; } = 1;

    [JsonProperty, Column(Name = "skill_tree_index", DbType = "tinyint(4)")]
    public sbyte SkillTreeIndex { get; set; } = -1;

    [JsonProperty, Column(Name = "spec_property", DbType = "tinyblob")]
    public byte[] SpecProperty { get; set; }

    [JsonProperty, Column(Name = "start_time")]
    public int StartTime { get; set; } = 0;

    [JsonProperty, Column(Name = "village", DbType = "tinyint(4)")]
    public sbyte Village { get; set; } = 1;

    [JsonProperty, Column(IsNullable = false)]
    public string VIP { get; set; }

}

/*
[SugarTable("charac_info")]
public partial class CharacInfoSqlSugar
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "charac_no")]
    public int CharacNo
    {
        get; set;
    }

    [SugarColumn(ColumnName = "attack_speed", ColumnDataType = "smallint(6) unsigned")]
    public ushort AttackSpeed { get; set; } = 0;

    [SugarColumn(ColumnName = "cast_speed", ColumnDataType = "smallint(6) unsigned")]
    public ushort CastSpeed { get; set; } = 0;

    [SugarColumn(ColumnName = "charac_name", ColumnDataType = "varchar", Length = 20, IsNullable = false)]
    public string CharacName
    {
        get; set;
    }

    [SugarColumn(ColumnName = "charac_weight")]
    public int CharacWeight { get; set; } = 0;

    [SugarColumn(ColumnName = "competition_area", ColumnDataType = "tinyint(2)")]
    public sbyte CompetitionArea { get; set; } = -1;

    [SugarColumn(ColumnName = "competition_period", ColumnDataType = "tinyint(2)")]
    public sbyte CompetitionPeriod { get; set; } = -1;

    [SugarColumn(ColumnName = "delete_flag", ColumnDataType = "tinyint(4)")]
    public sbyte DeleteFlag { get; set; } = 0;

    [SugarColumn(ColumnName = "dungeon_clear_point")]
    public int DungeonClearPoint { get; set; } = 0;

    [SugarColumn(ColumnName = "element_resist", ColumnDataType = "tinyblob")]
    public byte[] ElementResist
    {
        get; set;
    }

    [SugarColumn(ColumnName = "event_charac_level", ColumnDataType = "tinyint(4)")]
    public sbyte EventCharacLevel { get; set; } = 0;

    [SugarColumn(ColumnName = "exp")]
    public int Exp { get; set; } = 0;

    [SugarColumn(ColumnName = "expert_job")]
    public byte ExpertJob { get; set; } = 0;

    [SugarColumn(ColumnName = "fatigue")]
    public short Fatigue { get; set; } = 0;

    [SugarColumn(ColumnName = "finish_time")]
    public int FinishTime { get; set; } = 0;

    [SugarColumn(ColumnName = "grow_type", ColumnDataType = "tinyint(4)")]
    public sbyte GrowType { get; set; } = 0;

    [SugarColumn(ColumnName = "guild_id")]
    public uint GuildId { get; set; } = 0;

    [SugarColumn(ColumnName = "guild_right", ColumnDataType = "tinyint(4)")]
    public sbyte GuildRight { get; set; } = 0;

    [SugarColumn(ColumnName = "guild_secede", ColumnDataType = "tinyint(2)")]
    public sbyte GuildSecede { get; set; } = 0;

    [SugarColumn(ColumnName = "hit_recovery")]
    public short HitRecovery { get; set; } = 0;

    [SugarColumn(ColumnName = "hp")]
    public byte HP { get; set; } = 0;

    [SugarColumn(ColumnName = "hp_regen")]
    public short HpRegen { get; set; } = 0;

    [SugarColumn(ColumnName = "inven_weight", ColumnDataType = "int(6)")]
    public int InvenWeight { get; set; } = 0;

    [SugarColumn(ColumnName = "job", ColumnDataType = "tinyint(4)")]
    public sbyte Job { get; set; } = 0;

    [SugarColumn(ColumnName = "jump")]
    public short Jump { get; set; } = 0;

    [SugarColumn(ColumnName = "lev", ColumnDataType = "tinyint(4)")]
    public sbyte Lev { get; set; } = 1;

    [SugarColumn(ColumnName = "link_charac_no")]
    public uint LinkCharacNo { get; set; } = 0;

    [SugarColumn(ColumnName = "m_id")]
    public int MId { get; set; } = 0;

    [SugarColumn(ColumnName = "mag_attack", ColumnDataType = "smallint(6) unsigned")]
    public ushort MagAttack { get; set; } = 0;

    [SugarColumn(ColumnName = "mag_defense", ColumnDataType = "smallint(6) unsigned")]
    public ushort MagDefense { get; set; } = 0;

    [SugarColumn(ColumnName = "max_fatigue")]
    public short MaxFatigue { get; set; } = 70;

    [SugarColumn(ColumnName = "max_premium_fatigue")]
    public short MaxPremiumFatigue { get; set; } = 0;

    [SugarColumn(ColumnName = "maxHP", ColumnDataType = "smallint(6) unsigned")]
    public ushort MaxHP { get; set; } = 0;

    [SugarColumn(ColumnName = "maxMP", ColumnDataType = "smallint(6) unsigned")]
    public ushort MaxMP { get; set; } = 0;

    [SugarColumn(ColumnName = "member_flag", ColumnDataType = "tinyint(4)")]
    public sbyte MemberFlag { get; set; } = 0;

    [SugarColumn(ColumnName = "mercenary_area", ColumnDataType = "tinyint(4)")]
    public sbyte MercenaryArea { get; set; } = -1;

    [SugarColumn(ColumnName = "mercenary_finish_time")]
    public int MercenaryFinishTime { get; set; } = 0;

    [SugarColumn(ColumnName = "mercenary_period", ColumnDataType = "tinyint(4)")]
    public sbyte MercenaryPeriod { get; set; } = -1;

    [SugarColumn(ColumnName = "mercenary_start_time")]
    public int MercenaryStartTime { get; set; } = 0;

    [SugarColumn(ColumnName = "move_speed", ColumnDataType = "smallint(6) unsigned")]
    public ushort MoveSpeed { get; set; } = 0;

    [SugarColumn(ColumnName = "mp_regen")]
    public short MpRegen { get; set; } = 0;

    [SugarColumn(ColumnName = "phy_attack", ColumnDataType = "smallint(6) unsigned")]
    public ushort PhyAttack { get; set; } = 0;

    [SugarColumn(ColumnName = "phy_defense", ColumnDataType = "smallint(6) unsigned")]
    public ushort PhyDefense { get; set; } = 0;

    [SugarColumn(ColumnName = "premium_fatigue")]
    public short PremiumFatigue { get; set; } = 0;

    [SugarColumn(ColumnName = "sex", ColumnDataType = "tinyint(4)")]
    public sbyte Sex { get; set; } = 1;

    [SugarColumn(ColumnName = "skill_tree_index", ColumnDataType = "tinyint(4)")]
    public sbyte SkillTreeIndex { get; set; } = -1;

    [SugarColumn(ColumnName = "spec_property", ColumnDataType = "tinyblob")]
    public byte[] SpecProperty
    {
        get; set;
    }

    [SugarColumn(ColumnName = "start_time")]
    public int StartTime { get; set; } = 0;

    [SugarColumn(ColumnName = "village", ColumnDataType = "tinyint(4)")]
    public sbyte Village { get; set; } = 1;

    [SugarColumn(IsNullable = false)]
    public string VIP
    {
        get; set;
    }
}*/