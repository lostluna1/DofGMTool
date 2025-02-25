using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "guild_stat_month", DisableSyncStructure = true)]
	public partial class GuildStatMonth {

		[JsonProperty, Column(Name = "lev", IsPrimary = true)]
		public byte Lev { get; set; } = 0;

		[JsonProperty, Column(Name = "occ_date", DbType = "date", IsPrimary = true, InsertValueSql = "0000-00-00")]
		public DateTime OccDate { get; set; }

		[JsonProperty, Column(Name = "server_id", DbType = "tinyint(4)", IsPrimary = true)]
		public sbyte ServerId { get; set; } = 0;

		[JsonProperty, Column(Name = "avg_guild_point")]
		public int AvgGuildPoint { get; set; } = 0;

		[JsonProperty, Column(Name = "avg_guild_point_acc")]
		public int AvgGuildPointAcc { get; set; } = 0;

	}

}
