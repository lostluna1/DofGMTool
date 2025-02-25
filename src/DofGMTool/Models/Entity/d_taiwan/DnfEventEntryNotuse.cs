using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "dnf_event_entry_notuse", DisableSyncStructure = true)]
	public partial class DnfEventEntryNotuse {

		[JsonProperty, Column(Name = "event_id", IsPrimary = true)]
		public int EventId { get; set; } = 0;

		[JsonProperty, Column(Name = "m_id", IsPrimary = true)]
		public int MId { get; set; } = 0;

		[JsonProperty, Column(Name = "charac_no")]
		public int CharacNo { get; set; } = 0;

		[JsonProperty, Column(Name = "obtain_date", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime ObtainDate { get; set; }

		[JsonProperty, Column(Name = "occ_date", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime OccDate { get; set; }

		[JsonProperty, Column(Name = "server_id", DbType = "tinyint(4)")]
		public sbyte ServerId { get; set; } = 0;

	}

}
