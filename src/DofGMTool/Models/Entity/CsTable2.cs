using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "cs_table2", DisableSyncStructure = true)]
	public partial class CsTable2 {

		[JsonProperty, Column(Name = "account_id", DbType = "char(30)", IsNullable = false)]
		public string AccountId { get; set; }

		[JsonProperty, Column(Name = "charac_id", DbType = "char(30)", IsNullable = false)]
		public string CharacId { get; set; }

	}

}
