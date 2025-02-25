using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "guild_halloffame", DisableSyncStructure = true)]
	public partial class GuildHalloffame {

		[JsonProperty, Column(Name = "fame_id", IsPrimary = true)]
		public int FameId { get; set; } = 0;

		[JsonProperty, Column(Name = "server_id", DbType = "tinyint(4)", IsPrimary = true)]
		public sbyte ServerId { get; set; } = 0;

		[JsonProperty, Column(Name = "file_url", StringLength = 128, IsNullable = false)]
		public string FileUrl { get; set; } = "0";

		[JsonProperty, Column(Name = "guild_id")]
		public int GuildId { get; set; } = 0;

		[JsonProperty, Column(Name = "guild_name", StringLength = 40, IsNullable = false)]
		public string GuildName { get; set; }

		[JsonProperty, Column(Name = "main_flag", DbType = "tinyint(4)")]
		public sbyte MainFlag { get; set; } = 0;

		[JsonProperty, Column(Name = "open_flag", DbType = "tinyint(4)")]
		public sbyte OpenFlag { get; set; } = 0;

	}

}
