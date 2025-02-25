using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "event_goldcard_entry2", DisableSyncStructure = true)]
	public partial class EventGoldcardEntry2 {

		[JsonProperty, Column(Name = "m_id", IsPrimary = true)]
		public int MId { get; set; } = 0;

		[JsonProperty, Column(Name = "occ_date", IsPrimary = true)]
		public int OccDate { get; set; } = 0;

		[JsonProperty, Column(Name = "charac_no")]
		public int CharacNo { get; set; } = 0;

		[JsonProperty, Column(Name = "item_check")]
		public int ItemCheck { get; set; } = 0;

		[JsonProperty, Column(Name = "item_no", DbType = "int(11) unsigned")]
		public uint ItemNo { get; set; } = 0;

		[JsonProperty, Column(Name = "server_id", DbType = "tinyint(4)")]
		public sbyte ServerId { get; set; } = 0;

	}

}
