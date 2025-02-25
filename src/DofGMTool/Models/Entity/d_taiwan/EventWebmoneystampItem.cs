using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "event_webmoneystamp_item", DisableSyncStructure = true)]
	public partial class EventWebmoneystampItem {

		[JsonProperty, Column(Name = "m_id", IsPrimary = true)]
		public int MId { get; set; } = 0;

		[JsonProperty, Column(Name = "occ_time", IsPrimary = true)]
		public int OccTime { get; set; } = 0;

		[JsonProperty, Column(Name = "charac_no", DbType = "tinyint(4)")]
		public sbyte CharacNo { get; set; } = 0;

		[JsonProperty, Column(Name = "item_check")]
		public uint ItemCheck { get; set; } = 0;

		[JsonProperty, Column(Name = "item_no")]
		public uint ItemNo { get; set; } = 0;

		[JsonProperty, Column(Name = "server_id", DbType = "tinyint(4)")]
		public sbyte ServerId { get; set; } = 0;

	}

}
