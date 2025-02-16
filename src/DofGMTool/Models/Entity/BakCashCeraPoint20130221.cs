using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_cash_cera_point_20130221", DisableSyncStructure = true)]
	public partial class BakCashCeraPoint20130221 {

		[JsonProperty, Column(Name = "account", StringLength = 30, IsPrimary = true, IsNullable = false)]
		public string Account { get; set; }

		[JsonProperty, Column(Name = "cera_point")]
		public uint CeraPoint { get; set; }

		[JsonProperty, Column(Name = "mod_date", DbType = "datetime")]
		public DateTime ModDate { get; set; }

		[JsonProperty, Column(Name = "reg_date", DbType = "datetime")]
		public DateTime RegDate { get; set; }

	}

}
