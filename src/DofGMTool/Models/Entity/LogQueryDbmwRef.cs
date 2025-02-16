using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "log_query_dbmw_ref", DisableSyncStructure = true)]
	public partial class LogQueryDbmwRef {

		[JsonProperty, Column(Name = "q_id", IsPrimary = true, IsIdentity = true)]
		public ushort QId { get; set; }

		[JsonProperty, Column(Name = "query", StringLength = -1, IsNullable = false)]
		public string Query { get; set; }

		[JsonProperty, Column(Name = "query_hash", StringLength = 16, IsNullable = false)]
		public string QueryHash { get; set; }

	}

}
