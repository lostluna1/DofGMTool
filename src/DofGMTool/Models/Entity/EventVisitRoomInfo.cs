using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "event_visit_room_info", DisableSyncStructure = true)]
	public partial class EventVisitRoomInfo {

		[JsonProperty, Column(Name = "charac_no", DbType = "int(11) unsigned", IsPrimary = true)]
		public uint CharacNo { get; set; } = 0;

		[JsonProperty, Column(Name = "update_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime UpdateTime { get; set; }

		[JsonProperty, Column(Name = "visit_charac_no", DbType = "blob")]
		public byte[] VisitCharacNo { get; set; }

		[JsonProperty, Column(Name = "visit_cnt", DbType = "tinyint(4) unsigned")]
		public byte VisitCnt { get; set; } = 0;

	}

}
