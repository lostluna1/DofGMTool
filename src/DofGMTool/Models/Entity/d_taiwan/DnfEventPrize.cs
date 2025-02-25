using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "dnf_event_prize", DisableSyncStructure = true)]
	public partial class DnfEventPrize {

		[JsonProperty, Column(Name = "m_id", IsPrimary = true)]
		public int MId { get; set; } = 0;

		[JsonProperty, Column(Name = "prize_id", IsPrimary = true)]
		public int PrizeId { get; set; } = 0;

		[JsonProperty, Column(Name = "check_time")]
		public int CheckTime { get; set; } = 0;

	}

}
