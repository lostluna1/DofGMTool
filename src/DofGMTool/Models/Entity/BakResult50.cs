using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_result_50", DisableSyncStructure = true)]
	public partial class BakResult50 {

		[JsonProperty, Column(Name = "charac_no")]
		public int CharacNo { get; set; } = 0;

		[JsonProperty, Column(Name = "lev", DbType = "tinyint(4)")]
		public sbyte Lev { get; set; } = 1;

		[JsonProperty, Column(Name = "m_id")]
		public int MId { get; set; } = 0;

		[JsonProperty, Column(Name = "server_info")]
		public byte ServerInfo { get; set; } = 0;

	}

}
