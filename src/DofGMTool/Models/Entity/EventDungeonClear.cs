using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "event_dungeon_clear", DisableSyncStructure = true)]
	public partial class EventDungeonClear {

		[JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
		public uint CharacNo { get; set; } = 0;

		[JsonProperty, Column(Name = "clear_cnt")]
		public uint ClearCnt { get; set; } = 0;

		[JsonProperty, Column(Name = "update_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime UpdateTime { get; set; }

	}

}
