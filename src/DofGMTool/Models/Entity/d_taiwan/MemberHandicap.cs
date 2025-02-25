using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "member_handicap", DisableSyncStructure = true)]
	public partial class MemberHandicap {

		[JsonProperty, Column(Name = "cap_type", IsPrimary = true)]
		public byte CapType { get; set; } = 0;

		[JsonProperty, Column(Name = "event_id", IsPrimary = true)]
		public int EventId { get; set; } = 0;

		[JsonProperty, Column(Name = "m_id", IsPrimary = true)]
		public int MId { get; set; } = 0;

		[JsonProperty, Column(Name = "server_id", DbType = "tinyint(4)", IsPrimary = true)]
		public sbyte ServerId { get; set; } = 0;

		[JsonProperty, Column(Name = "start_time", DbType = "datetime", IsPrimary = true, InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime StartTime { get; set; }

		[JsonProperty, Column(Name = "end_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime EndTime { get; set; }

		[JsonProperty, Column(Name = "handicap_value")]
		public int HandicapValue { get; set; } = 0;

	}

}
