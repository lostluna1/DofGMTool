using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "geo_allow_country", DisableSyncStructure = true)]
	public partial class GeoAllowCountry {

		[JsonProperty, Column(Name = "country_code", StringLength = 10, IsPrimary = true, IsNullable = false)]
		public string CountryCode { get; set; }

		[JsonProperty, Column(Name = "server_group", DbType = "tinyint(4)", IsPrimary = true)]
		public sbyte ServerGroup { get; set; }

		[JsonProperty, Column(Name = "reg_date", DbType = "datetime")]
		public DateTime RegDate { get; set; }

	}

}
