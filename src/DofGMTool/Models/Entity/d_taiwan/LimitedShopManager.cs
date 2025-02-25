using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "limited_shop_manager", DisableSyncStructure = true)]
	public partial class LimitedShopManager {

		[JsonProperty, Column(Name = "ipg_no", IsPrimary = true)]
		public uint IpgNo { get; set; } = 0;

		[JsonProperty, Column(Name = "no", IsPrimary = true, IsIdentity = true)]
		public uint No { get; set; }

		[JsonProperty, Column(Name = "server_id", IsPrimary = true)]
		public byte ServerId { get; set; } = 0;

		[JsonProperty, Column(Name = "avatar_period_type", DbType = "tinyint(4)")]
		public sbyte AvatarPeriodType { get; set; } = -1;

		[JsonProperty, Column(Name = "cera_price")]
		public uint CeraPrice { get; set; } = 0;

		[JsonProperty, Column(Name = "cond_acc_create_time_begin")]
		public uint CondAccCreateTimeBegin { get; set; } = 0;

		[JsonProperty, Column(Name = "cond_acc_create_time_end")]
		public uint CondAccCreateTimeEnd { get; set; } = 0;

		[JsonProperty, Column(Name = "cond_cha_create_time_begin")]
		public uint CondChaCreateTimeBegin { get; set; } = 0;

		[JsonProperty, Column(Name = "cond_cha_create_time_end")]
		public uint CondChaCreateTimeEnd { get; set; } = 0;

		[JsonProperty, Column(Name = "cond_charac_job")]
		public byte CondCharacJob { get; set; } = 0;

		[JsonProperty, Column(Name = "cond_lev_begin")]
		public byte CondLevBegin { get; set; } = 0;

		[JsonProperty, Column(Name = "cond_lev_end")]
		public byte CondLevEnd { get; set; } = 0;

		[JsonProperty, Column(Name = "end_time")]
		public uint EndTime { get; set; } = 0;

		[JsonProperty, Column(Name = "gold_price")]
		public uint GoldPrice { get; set; } = 0;

		[JsonProperty, Column(Name = "item_cnt")]
		public uint ItemCnt { get; set; } = 0;

		[JsonProperty, Column(Name = "item_no")]
		public uint ItemNo { get; set; } = 0;

		[JsonProperty, Column(Name = "npc_idx")]
		public uint NpcIdx { get; set; } = 0;

		[JsonProperty, Column(Name = "occ_time")]
		public uint OccTime { get; set; } = 0;

		[JsonProperty, Column(Name = "pos_flag", DbType = "char(1)", IsNullable = false)]
		public string PosFlag { get; set; } = "0";

		[JsonProperty, Column(Name = "range_section")]
		public byte RangeSection { get; set; } = 0;

		[JsonProperty, Column(Name = "real_end_time")]
		public uint RealEndTime { get; set; } = 0;

		[JsonProperty, Column(Name = "reason_etc", StringLength = 200, IsNullable = false)]
		public string ReasonEtc { get; set; }

		[JsonProperty, Column(Name = "reason_stop", StringLength = 200, IsNullable = false)]
		public string ReasonStop { get; set; }

		[JsonProperty, Column(Name = "restrict_no")]
		public uint RestrictNo { get; set; } = 0;

		[JsonProperty, Column(Name = "sell_cnt")]
		public uint SellCnt { get; set; } = 0;

		[JsonProperty, Column(Name = "start_time")]
		public uint StartTime { get; set; } = 0;

		[JsonProperty, Column(Name = "status_flag")]
		public byte StatusFlag { get; set; } = 0;

		[JsonProperty, Column(Name = "title", StringLength = 50, IsNullable = false)]
		public string Title { get; set; }

		[JsonProperty, Column(Name = "total_cnt")]
		public int TotalCnt { get; set; } = 0;

	}

}
