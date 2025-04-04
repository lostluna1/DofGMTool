﻿using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_quest", DisableSyncStructure = true)]
public partial class CharacQuest
{

    [JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "play_1")]
    public ushort Play1 { get; set; } = 0;

    [JsonProperty, Column(Name = "play_1_trigger")]
    public int Play1Trigger { get; set; } = 0;

    [JsonProperty, Column(Name = "play_10")]
    public ushort Play10 { get; set; } = 0;

    [JsonProperty, Column(Name = "play_10_trigger")]
    public int Play10Trigger { get; set; } = 0;

    [JsonProperty, Column(Name = "play_2")]
    public ushort Play2 { get; set; } = 0;

    [JsonProperty, Column(Name = "play_2_trigger")]
    public int Play2Trigger { get; set; } = 0;

    [JsonProperty, Column(Name = "play_3")]
    public ushort Play3 { get; set; } = 0;

    [JsonProperty, Column(Name = "play_3_trigger")]
    public int Play3Trigger { get; set; } = 0;

    [JsonProperty, Column(Name = "play_4")]
    public ushort Play4 { get; set; } = 0;

    [JsonProperty, Column(Name = "play_4_trigger")]
    public int Play4Trigger { get; set; } = 0;

    [JsonProperty, Column(Name = "play_5")]
    public ushort Play5 { get; set; } = 0;

    [JsonProperty, Column(Name = "play_5_trigger")]
    public int Play5Trigger { get; set; } = 0;

    [JsonProperty, Column(Name = "play_6")]
    public ushort Play6 { get; set; } = 0;

    [JsonProperty, Column(Name = "play_6_trigger")]
    public int Play6Trigger { get; set; } = 0;

    [JsonProperty, Column(Name = "play_7")]
    public ushort Play7 { get; set; } = 0;

    [JsonProperty, Column(Name = "play_7_trigger")]
    public int Play7Trigger { get; set; } = 0;

    [JsonProperty, Column(Name = "play_8")]
    public ushort Play8 { get; set; } = 0;

    [JsonProperty, Column(Name = "play_8_trigger")]
    public int Play8Trigger { get; set; } = 0;

    [JsonProperty, Column(Name = "play_9")]
    public ushort Play9 { get; set; } = 0;

    [JsonProperty, Column(Name = "play_9_trigger")]
    public int Play9Trigger { get; set; } = 0;

    [JsonProperty, Column(Name = "quest_10", DbType = "binary(64)", InsertValueSql = "                                                                ")]
    public required byte[] Quest10 { get; set; }

    [JsonProperty, Column(Name = "quest_15", DbType = "binary(64)", InsertValueSql = "                                                                ")]
    public required byte[] Quest15 { get; set; }

    [JsonProperty, Column(Name = "quest_20", DbType = "binary(64)", InsertValueSql = "                                                                ")]
    public required byte[] Quest20 { get; set; }

    [JsonProperty, Column(Name = "quest_30", DbType = "binary(64)", InsertValueSql = "                                                                ")]
    public required byte[] Quest30 { get; set; }

    [JsonProperty, Column(Name = "quest_40", DbType = "binary(64)", InsertValueSql = "                                                                ")]
    public required byte[] Quest40 { get; set; }

    [JsonProperty, Column(Name = "quest_40_ext", DbType = "binary(64)", InsertValueSql = "                                                                ")]
    public required byte[] Quest40Ext { get; set; }

    [JsonProperty, Column(Name = "quest_50", DbType = "binary(64)", InsertValueSql = "                                                                ")]
    public required byte[] Quest50 { get; set; }

    [JsonProperty, Column(Name = "quest_50_ext", DbType = "binary(64)", InsertValueSql = "                                                                ")]
    public required byte[] Quest50Ext { get; set; }

    [JsonProperty, Column(Name = "quest_60", DbType = "binary(64)", InsertValueSql = "                                                                ")]
    public required byte[] Quest60 { get; set; }

    [JsonProperty, Column(Name = "quest_60_ext", DbType = "binary(64)", InsertValueSql = "                                                                ")]
    public required byte[] Quest60Ext { get; set; }

    [JsonProperty, Column(Name = "quest_60_ext_2nd", DbType = "binary(64)", InsertValueSql = "                                                                ")]
    public required byte[] Quest60Ext2nd { get; set; }

    [JsonProperty, Column(Name = "quest_70", DbType = "binary(64)", InsertValueSql = "                                                                ")]
    public required byte[] Quest70 { get; set; }

    [JsonProperty, Column(Name = "quest_etc", DbType = "binary(64)", InsertValueSql = "                                                                ")]
    public required byte[] QuestEtc { get; set; }

    [JsonProperty, Column(Name = "quest_etc_ext", DbType = "binary(64)", InsertValueSql = "                                                                ")]
    public required byte[] QuestEtcExt { get; set; }

}
