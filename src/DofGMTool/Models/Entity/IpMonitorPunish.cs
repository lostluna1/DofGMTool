using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "ip_monitor_punish", DisableSyncStructure = true)]
	public partial class IpMonitorPunish {

		[JsonProperty, Column(Name = "ip", StringLength = 15, IsPrimary = true, IsNullable = false)]
		public string Ip { get; set; }

		[JsonProperty, Column(Name = "type", DbType = "tinyint(4)", IsPrimary = true)]
		public sbyte Type { get; set; } = 0;

		[JsonProperty, Column(Name = "end_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime EndTime { get; set; }

		[JsonProperty, Column(Name = "m_id_cnt")]
		public ushort MIdCnt { get; set; } = 0;

		[JsonProperty, Column(Name = "start_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime StartTime { get; set; }

	}

}
