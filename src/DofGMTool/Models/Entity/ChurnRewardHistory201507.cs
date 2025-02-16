using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "churn_reward_history_201507", DisableSyncStructure = true)]
	public partial class ChurnRewardHistory201507 {

		[JsonProperty, Column(Name = "m_id", IsPrimary = true)]
		public uint MId { get; set; } = 0;

		[JsonProperty, Column(Name = "occ_time", DbType = "datetime", IsPrimary = true, InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime OccTime { get; set; }

		[JsonProperty, Column(Name = "add_info")]
		public uint AddInfo { get; set; } = 0;

		[JsonProperty, Column(Name = "cera")]
		public uint Cera { get; set; } = 0;

		[JsonProperty, Column(Name = "charac_no")]
		public uint CharacNo { get; set; } = 0;

		[JsonProperty, Column(Name = "item_id")]
		public uint ItemId { get; set; } = 0;

		[JsonProperty, Column(Name = "luck_point")]
		public uint LuckPoint { get; set; } = 0;

		[JsonProperty, Column(Name = "reward_order")]
		public uint RewardOrder { get; set; } = 0;

		[JsonProperty, Column(Name = "server_id", DbType = "tinyint(4)")]
		public sbyte ServerId { get; set; } = 0;

	}

}
