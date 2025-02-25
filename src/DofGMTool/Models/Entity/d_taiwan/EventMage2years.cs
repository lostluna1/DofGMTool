using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "event_mage_2years", DisableSyncStructure = true)]
	public partial class EventMage2years {

		[JsonProperty, Column(Name = "charac_no", IsPrimary = true, IsIdentity = true)]
		public int CharacNo { get; set; }

		[JsonProperty, Column(Name = "m_id", IsPrimary = true)]
		public int MId { get; set; } = 0;

		[JsonProperty, Column(Name = "server_info", IsPrimary = true)]
		public byte ServerInfo { get; set; } = 0;

		[JsonProperty, Column(Name = "charac_name", StringLength = 100, IsNullable = false)]
		public string CharacName { get; set; }

		[JsonProperty, Column(Name = "create_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime CreateTime { get; set; }

		[JsonProperty, Column(Name = "delete_flag", DbType = "tinyint(4)")]
		public sbyte DeleteFlag { get; set; } = 0;

		[JsonProperty, Column(Name = "delete_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime DeleteTime { get; set; }

	}

}
