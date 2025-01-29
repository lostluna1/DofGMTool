using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "event_condition_info", DisableSyncStructure = true)]
	public partial class EventConditionInfo {

		[JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
		public uint CharacNo { get; set; } = 0;

		[JsonProperty, Column(Name = "current_step")]
		public byte CurrentStep { get; set; } = 0;

		[JsonProperty, Column(Name = "reward_step")]
		public byte RewardStep { get; set; } = 0;

		[JsonProperty, Column(Name = "update_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime UpdateTime { get; set; }

	}

}
