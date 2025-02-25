using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "event_quizquiz_stamp", DisableSyncStructure = true)]
	public partial class EventQuizquizStamp {

		[JsonProperty, Column(Name = "degree", DbType = "tinyint(4)", IsPrimary = true)]
		public sbyte Degree { get; set; } = 0;

		[JsonProperty, Column(Name = "m_id", IsPrimary = true)]
		public int MId { get; set; } = 0;

		[JsonProperty, Column(Name = "occ_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime OccTime { get; set; }

		[JsonProperty, Column(Name = "stamp")]
		public int Stamp { get; set; } = 0;

	}

}
