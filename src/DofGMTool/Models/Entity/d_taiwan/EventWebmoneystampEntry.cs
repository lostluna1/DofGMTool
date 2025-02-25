using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "event_webmoneystamp_entry", DisableSyncStructure = true)]
	public partial class EventWebmoneystampEntry {

		[JsonProperty, Column(Name = "m_id", IsPrimary = true)]
		public int MId { get; set; } = 0;

		[JsonProperty, Column(Name = "attend_point")]
		public ushort AttendPoint { get; set; } = 0;

		[JsonProperty, Column(Name = "entry_item", DbType = "tinyint(4)")]
		public sbyte EntryItem { get; set; } = 0;

		[JsonProperty, Column(Name = "last_attend_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime LastAttendTime { get; set; }

		[JsonProperty, Column(Name = "occ_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime OccTime { get; set; }

		[JsonProperty, Column(Name = "return_flag", DbType = "tinyint(4)")]
		public sbyte ReturnFlag { get; set; } = 0;

	}

}
