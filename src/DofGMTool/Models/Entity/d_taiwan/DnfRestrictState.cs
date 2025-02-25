using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "dnf_restrict_state", DisableSyncStructure = true)]
	public partial class DnfRestrictState {

		[JsonProperty, Column(Name = "category", IsPrimary = true)]
		public int Category { get; set; }

		[JsonProperty, Column(Name = "restrict_code", IsPrimary = true)]
		public int RestrictCode { get; set; }

		[JsonProperty, Column(Name = "server_group", IsPrimary = true)]
		public int ServerGroup { get; set; }

		[JsonProperty, Column(Name = "mod_date", DbType = "datetime")]
		public DateTime ModDate { get; set; }

		[JsonProperty, Column(Name = "reg_date", DbType = "datetime")]
		public DateTime RegDate { get; set; }

		[JsonProperty, Column(Name = "restrict_value", DbType = "char(1)", IsNullable = false)]
		public string RestrictValue { get; set; }

	}

}
