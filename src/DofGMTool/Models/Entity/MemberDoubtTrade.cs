using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "member_doubt_trade", DisableSyncStructure = true)]
	public partial class MemberDoubtTrade {

		[JsonProperty, Column(Name = "m_id", IsPrimary = true)]
		public int MId { get; set; } = 0;

		[JsonProperty, Column(Name = "last_update_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime LastUpdateTime { get; set; }

		[JsonProperty, Column(Name = "over_count")]
		public ushort OverCount { get; set; } = 0;

	}

}
