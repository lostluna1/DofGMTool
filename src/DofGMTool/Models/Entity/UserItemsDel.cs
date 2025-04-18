﻿using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace DofGMTool.Models;

[JsonObject(MemberSerialization.OptIn), Table(Name = "user_items_del", DisableSyncStructure = true)]
public partial class UserItemsDel
{

    [JsonProperty, Column(Name = "sdate", DbType = "date", IsPrimary = true, InsertValueSql = "0000-00-00")]
    public DateTime Sdate { get; set; }

    [JsonProperty, Column(Name = "ui_id", IsPrimary = true)]
    public int UiId { get; set; } = 0;

    [JsonProperty, Column(Name = "ability_no", DbType = "tinyint(4)")]
    public sbyte AbilityNo { get; set; } = 0;

    [JsonProperty, Column(Name = "charac_no")]
    public int CharacNo { get; set; } = 0;

    [JsonProperty, Column(Name = "clear_avatar_id")]
    public int ClearAvatarId { get; set; } = 0;

    [JsonProperty, Column(Name = "color1")]
    public ushort Color1 { get; set; } = 0;

    [JsonProperty, Column(Name = "color2")]
    public ushort Color2 { get; set; } = 0;

    [JsonProperty, Column(Name = "emblem_endurance")]
    public ushort EmblemEndurance { get; set; } = 0;

    [JsonProperty, Column(Name = "expire_date", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime ExpireDate { get; set; }

    [JsonProperty, Column(Name = "hidden_option")]
    public ushort HiddenOption { get; set; } = 0;

    [JsonProperty, Column(Name = "ipg_agency_no", StringLength = 32, IsNullable = false)]
    public required string IpgAgencyNo { get; set; }

    [JsonProperty, Column(Name = "it_id")]
    public int ItId { get; set; } = 0;

    [JsonProperty, Column(Name = "item_lock_key", DbType = "tinyint(4)")]
    public sbyte ItemLockKey { get; set; } = 0;

    [JsonProperty, Column(Name = "jewel_socket", DbType = "varbinary(30)")]
    public required byte[] JewelSocket { get; set; }

    [JsonProperty, Column(Name = "m_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime MTime { get; set; }

    [JsonProperty, Column(Name = "obtain_from", DbType = "tinyint(4)")]
    public sbyte? ObtainFrom { get; set; }

    [JsonProperty, Column(Name = "reg_date", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
    public DateTime RegDate { get; set; }

    [JsonProperty, Column(Name = "slot")]
    public int Slot { get; set; } = 0;

    [JsonProperty, Column(Name = "stat")]
    public byte Stat { get; set; } = 0;

    [JsonProperty, Column(Name = "to_ipg_agency_no", StringLength = 32, IsNullable = false)]
    public required string ToIpgAgencyNo { get; set; }

    [JsonProperty, Column(Name = "trade_restrict")]
    public byte TradeRestrict { get; set; } = 0;

}
