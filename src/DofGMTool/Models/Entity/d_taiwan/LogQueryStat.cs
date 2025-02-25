using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "log_query_stat", DisableSyncStructure = true)]
	public partial class LogQueryStat {

		[JsonProperty, Column(Name = "gc_no", IsPrimary = true)]
		public uint GcNo { get; set; } = 0;

		[JsonProperty, Column(Name = "occ_time", DbType = "datetime", IsPrimary = true, InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime OccTime { get; set; }

		[JsonProperty, Column(Name = "q_id", IsPrimary = true)]
		public ushort QId { get; set; } = 0;

		[JsonProperty, Column(Name = "response_time")]
		public uint ResponseTime { get; set; } = 0;

		[JsonProperty, Column(Name = "total")]
		public uint Total { get; set; } = 0;

	}

}
