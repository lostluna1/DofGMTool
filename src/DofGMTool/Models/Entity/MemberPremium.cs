using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "member_premium", DisableSyncStructure = true)]
	public partial class MemberPremium {

		[JsonProperty, Column(Name = "event_id", IsPrimary = true)]
		public int EventId { get; set; } = 0;

		[JsonProperty, Column(Name = "m_id", IsPrimary = true)]
		public int MId { get; set; } = 0;

		[JsonProperty, Column(Name = "pre_type", IsPrimary = true)]
		public byte PreType { get; set; } = 0;

		[JsonProperty, Column(Name = "server_id", IsPrimary = true)]
		public byte ServerId { get; set; } = 0;

		[JsonProperty, Column(Name = "service_start", DbType = "datetime", IsPrimary = true, InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime ServiceStart { get; set; }

		[JsonProperty, Column(Name = "service_end", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime ServiceEnd { get; set; }

	}

}
