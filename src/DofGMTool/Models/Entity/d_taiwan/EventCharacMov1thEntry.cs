using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "event_charac_mov_1th_entry", DisableSyncStructure = true)]
	public partial class EventCharacMov1thEntry {

		[JsonProperty, Column(Name = "m_id", IsPrimary = true)]
		public int MId { get; set; } = 0;

		[JsonProperty, Column(Name = "it_no")]
		public int ItNo { get; set; } = 0;

		[JsonProperty, Column(Name = "item_check")]
		public int ItemCheck { get; set; } = 0;

		[JsonProperty, Column(Name = "occ_time")]
		public int OccTime { get; set; } = 0;

	}

}
