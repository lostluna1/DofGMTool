using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "login_history", DisableSyncStructure = true)]
	public partial class LoginHistory {

		[JsonProperty, Column(Name = "m_id")]
		public int MId { get; set; } = 0;

		[JsonProperty, Column(Name = "occ_time")]
		public int OccTime { get; set; } = 0;

		[JsonProperty, Column(Name = "trigger", DbType = "tinyint(4)")]
		public sbyte Trigger { get; set; } = 0;

	}

}
