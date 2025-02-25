using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "guild_visit", DisableSyncStructure = true)]
	public partial class GuildVisit {

		[JsonProperty, Column(Name = "guild_id", IsPrimary = true)]
		public int GuildId { get; set; } = 0;

		[JsonProperty, Column(Name = "server_id", DbType = "tinyint(4)")]
		public sbyte ServerId { get; set; } = 0;

		[JsonProperty, Column(Name = "today_visit")]
		public int TodayVisit { get; set; } = 0;

		[JsonProperty, Column(Name = "total_visit")]
		public int TotalVisit { get; set; } = 0;

	}

}
