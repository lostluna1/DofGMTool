using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "tmp_charac", DisableSyncStructure = true)]
public partial class d_taiwan_TmpCharac
{

    [JsonProperty, Column(Name = "attack_speed", DbType = "smallint(6) unsigned")]
    public ushort AttackSpeed { get; set; } = 0;

    [JsonProperty, Column(Name = "cast_speed", DbType = "smallint(6) unsigned")]
    public ushort CastSpeed { get; set; } = 0;

    [JsonProperty, Column(Name = "charac_name", StringLength = 10, IsNullable = false)]
    public string CharacName { get; set; }

    [JsonProperty, Column(Name = "charac_no")]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "charac_weight")]
    public int CharacWeight { get; set; } = 0;

    [JsonProperty, Column(Name = "create_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime CreateTime { get; set; }

    [JsonProperty, Column(Name = "delete_flag", DbType = "tinyint(4)")]
    public sbyte DeleteFlag { get; set; } = 0;

    [JsonProperty, Column(Name = "delete_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime DeleteTime { get; set; }

    [JsonProperty, Column(Name = "dungeon_clear_point")]
    public int DungeonClearPoint { get; set; } = 0;

    [JsonProperty, Column(Name = "element_resist", DbType = "tinyblob")]
    public byte[] ElementResist { get; set; }

    [JsonProperty, Column(Name = "exp")]
    public int Exp { get; set; } = 0;

    [JsonProperty, Column(Name = "fatigue", DbType = "smallint(11)")]
    public short Fatigue { get; set; } = 0;

    [JsonProperty, Column(Name = "grow_type", DbType = "tinyint(4)")]
    public sbyte GrowType { get; set; } = 0;

    [JsonProperty, Column(Name = "guild_id")]
    public uint GuildId { get; set; } = 0;

    [JsonProperty, Column(Name = "guild_right", DbType = "tinyint(4)")]
    public sbyte GuildRight { get; set; } = 0;

    [JsonProperty, Column(Name = "hit_recovery")]
    public short HitRecovery { get; set; } = 0;

    [JsonProperty, Column(DbType = "tinyint(4) unsigned")]
    public byte HP { get; set; } = 0;

    [JsonProperty, Column(Name = "hp_regen")]
    public short HpRegen { get; set; } = 0;

    [JsonProperty, Column(Name = "inven_weight", DbType = "int(6)")]
    public int InvenWeight { get; set; } = 0;

    [JsonProperty, Column(Name = "job", DbType = "tinyint(4)")]
    public sbyte Job { get; set; } = 0;

    [JsonProperty, Column(Name = "jump")]
    public short Jump { get; set; } = 0;

    [JsonProperty, Column(Name = "last_play_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime LastPlayTime { get; set; }

    [JsonProperty, Column(Name = "lev", DbType = "tinyint(4)")]
    public sbyte Lev { get; set; } = 1;

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

    [JsonProperty, Column(Name = "move_speed", DbType = "smallint(6) unsigned")]
    public ushort MoveSpeed { get; set; } = 0;

    [JsonProperty, Column(Name = "mp_regen")]
    public short MpRegen { get; set; } = 0;

    [JsonProperty, Column(Name = "phy_attack", DbType = "smallint(6) unsigned")]
    public ushort PhyAttack { get; set; } = 0;

    [JsonProperty, Column(Name = "phy_defense", DbType = "smallint(6) unsigned")]
    public ushort PhyDefense { get; set; } = 0;

    [JsonProperty, Column(Name = "premium_fatigue", DbType = "smallint(11)")]
    public short PremiumFatigue { get; set; } = 0;

    [JsonProperty, Column(Name = "spec_property", DbType = "tinyblob")]
    public byte[] SpecProperty { get; set; }

    [JsonProperty, Column(Name = "village", DbType = "tinyint(4)")]
    public sbyte Village { get; set; } = 1;

}
