using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_m_id_cbt", DisableSyncStructure = true)]
	public partial class BakMIdCbt {

		[JsonProperty, Column(Name = "charac_no")]
		public int CharacNo { get; set; } = 0;

		[JsonProperty, Column(Name = "create_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime CreateTime { get; set; }

		[JsonProperty, Column(Name = "m_id")]
		public int MId { get; set; } = 0;

	}

}
