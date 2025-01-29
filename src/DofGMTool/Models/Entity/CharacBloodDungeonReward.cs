using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_blood_dungeon_reward", DisableSyncStructure = true)]
	public partial class CharacBloodDungeonReward {

		[JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
		public uint CharacNo { get; set; } = 0;

		[JsonProperty, Column(Name = "week_occ_date", DbType = "date", IsPrimary = true, InsertValueSql = "0000-00-00")]
		public DateTime WeekOccDate { get; set; }

		[JsonProperty, Column(Name = "enter_count")]
		public uint EnterCount { get; set; } = 0;

		[JsonProperty, Column(Name = "last_play_date", DbType = "date", InsertValueSql = "0000-00-00")]
		public DateTime LastPlayDate { get; set; }

		[JsonProperty, Column(Name = "rank")]
		public byte Rank { get; set; } = 0;

		[JsonProperty, Column(Name = "reward")]
		public byte Reward { get; set; } = 0;

		[JsonProperty, Column(Name = "reward_gold")]
		public uint RewardGold { get; set; } = 0;

		[JsonProperty, Column(Name = "reward_item_id")]
		public uint RewardItemId { get; set; } = 0;

		[JsonProperty, Column(Name = "week_enter_count")]
		public uint WeekEnterCount { get; set; } = 0;

		[JsonProperty, Column(Name = "week_point")]
		public uint WeekPoint { get; set; } = 0;

		[JsonProperty, Column(Name = "week_use_gold")]
		public uint WeekUseGold { get; set; } = 0;

	}

}
