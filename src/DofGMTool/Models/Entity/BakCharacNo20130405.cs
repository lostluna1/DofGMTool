using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_charac_no_20130405", DisableSyncStructure = true)]
	public partial class BakCharacNo20130405 {

		[JsonProperty, Column(Name = "charac_no")]
		public int CharacNo { get; set; } = 0;

		[JsonProperty, Column(Name = "last_play_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime LastPlayTime { get; set; }

		[JsonProperty, Column(Name = "lev", DbType = "tinyint(4)")]
		public sbyte Lev { get; set; } = 1;

		[JsonProperty, Column(Name = "m_id")]
		public int MId { get; set; } = 0;

		[JsonProperty, Column(Name = "server_info")]
		public byte ServerInfo { get; set; } = 0;

	}

}
