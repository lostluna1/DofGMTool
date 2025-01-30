using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "game_channel", DisableSyncStructure = true)]
public partial class GameChannel
{

    [JsonProperty, Column(Name = "gc_no", DbType = "int(11) unsigned", IsPrimary = true, IsIdentity = true)]
    public uint GcNo { get; set; }

    [JsonProperty, Column(Name = "gc_at_gunner_cnt")]
    public ushort GcAtGunnerCnt { get; set; } = 0;

    [JsonProperty, Column(Name = "gc_ch_group", DbType = "smallint(5)")]
    public short GcChGroup { get; set; } = 0;

    [JsonProperty, Column(Name = "gc_channel", StringLength = 32, IsNullable = false)]
    public string GcChannel { get; set; }

    [JsonProperty, Column(Name = "gc_channeltype", StringLength = 25, IsNullable = false)]
    public string GcChanneltype { get; set; }

    [JsonProperty, Column(Name = "gc_fighter_cnt")]
    public ushort GcFighterCnt { get; set; } = 0;

    [JsonProperty, Column(Name = "gc_game")]
    public byte GcGame { get; set; } = 0;

    [JsonProperty, Column(Name = "gc_gunner_cnt")]
    public ushort GcGunnerCnt { get; set; } = 0;

    [JsonProperty, Column(Name = "gc_hangame")]
    public ushort GcHangame { get; set; } = 0;

    [JsonProperty, Column(Name = "gc_ip", StringLength = 64, IsNullable = false)]
    public string GcIp { get; set; }

    [JsonProperty, Column(Name = "gc_mage_cnt")]
    public ushort GcMageCnt { get; set; } = 0;

    [JsonProperty, Column(Name = "gc_max")]
    public ushort GcMax { get; set; } = 0;

    [JsonProperty, Column(Name = "gc_nexon")]
    public ushort GcNexon { get; set; } = 0;

    [JsonProperty, Column(Name = "gc_now")]
    public ushort GcNow { get; set; } = 0;

    [JsonProperty, Column(Name = "gc_port")]
    public ushort GcPort { get; set; } = 0;

    [JsonProperty, Column(Name = "gc_priest_cnt")]
    public ushort GcPriestCnt { get; set; } = 0;

    [JsonProperty, Column(Name = "gc_swordman_cnt")]
    public ushort GcSwordmanCnt { get; set; } = 0;

    [JsonProperty, Column(Name = "gc_thief_cnt")]
    public ushort GcThiefCnt { get; set; } = 0;

    [JsonProperty, Column(Name = "gc_type", DbType = "tinyint(4)")]
    public sbyte GcType { get; set; } = 0;

    [JsonProperty, Column(Name = "gc_up_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime GcUpTime { get; set; }

}
