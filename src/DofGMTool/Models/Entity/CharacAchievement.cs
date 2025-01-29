using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_achievement", DisableSyncStructure = true)]
	public partial class CharacAchievement {

		[JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
		public uint CharacNo { get; set; } = 0;

		[JsonProperty, Column(Name = "achievement", DbType = "blob")]
		public byte[] Achievement { get; set; }

		[JsonProperty, Column(Name = "last_update_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime LastUpdateTime { get; set; }

	}

}
