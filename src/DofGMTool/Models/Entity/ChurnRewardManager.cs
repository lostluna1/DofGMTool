using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "churn_reward_manager", DisableSyncStructure = true)]
	public partial class ChurnRewardManager {

		[JsonProperty, Column(Name = "max_day", DbType = "tinyint(4)", IsPrimary = true)]
		public sbyte MaxDay { get; set; } = 0;

		[JsonProperty, Column(Name = "max_val", IsPrimary = true)]
		public uint MaxVal { get; set; } = 0;

		[JsonProperty, Column(Name = "min_day", DbType = "tinyint(4)", IsPrimary = true)]
		public sbyte MinDay { get; set; } = 0;

		[JsonProperty, Column(Name = "min_val", IsPrimary = true)]
		public uint MinVal { get; set; } = 0;

		[JsonProperty, Column(Name = "quest_id", DbType = "tinyint(4)", IsPrimary = true)]
		public sbyte QuestId { get; set; } = 0;

		[JsonProperty, Column(Name = "add_info")]
		public uint AddInfo { get; set; } = 0;

		[JsonProperty, Column(Name = "item_id")]
		public uint ItemId { get; set; } = 0;

		[JsonProperty, Column(Name = "luck_point")]
		public uint LuckPoint { get; set; } = 0;

	}

}
