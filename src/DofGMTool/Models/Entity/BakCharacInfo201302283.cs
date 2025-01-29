using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_charac_info_20130228_3", DisableSyncStructure = true)]
	public partial class BakCharacInfo201302283 {

		[JsonProperty, Column(DbType = "bigint(21)")]
		public long CNT { get; set; } = 0;

		[JsonProperty, Column(Name = "m_id")]
		public int MId { get; set; } = 0;

		[JsonProperty, Column(Name = "user_id", StringLength = 30, IsNullable = false)]
		public string UserId { get; set; }

	}

}
