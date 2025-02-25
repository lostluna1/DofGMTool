using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "geo_allow", DisableSyncStructure = true)]
	public partial class GeoAllow {

		[JsonProperty, Column(Name = "allow_ip", StringLength = 20, IsPrimary = true, IsNullable = false)]
		public string AllowIp { get; set; }

		[JsonProperty, Column(Name = "allow_c_code", StringLength = 4, IsNullable = false)]
		public string AllowCCode { get; set; }

		[JsonProperty, Column(Name = "allow_date", DbType = "timestamp", InsertValueSql = "CURRENT_TIMESTAMP")]
		public DateTime AllowDate { get; set; }

	}

}
