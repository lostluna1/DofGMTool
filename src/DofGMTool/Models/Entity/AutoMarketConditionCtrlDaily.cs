using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "auto_market_condition_ctrl_daily", DisableSyncStructure = true)]
	public partial class AutoMarketConditionCtrlDaily {

		[JsonProperty, Column(Name = "occ_time", DbType = "date", IsPrimary = true, InsertValueSql = "0000-00-00")]
		public DateTime OccTime { get; set; }

		[JsonProperty, Column(Name = "auction_gold")]
		public ulong AuctionGold { get; set; } = 0;

		[JsonProperty, Column(Name = "durability_phase")]
		public uint DurabilityPhase { get; set; } = 0;

		[JsonProperty, Column(Name = "gold_phase")]
		public int GoldPhase { get; set; } = 0;

		[JsonProperty, Column(Name = "item_phase")]
		public int ItemPhase { get; set; } = 0;

		[JsonProperty, Column(Name = "optimum_gold_supply")]
		public ulong OptimumGoldSupply { get; set; } = 0;

		[JsonProperty, Column(Name = "over_gold")]
		public ulong OverGold { get; set; } = 0;

		[JsonProperty, Column(Name = "total_gold")]
		public ulong TotalGold { get; set; } = 0;

	}

}
