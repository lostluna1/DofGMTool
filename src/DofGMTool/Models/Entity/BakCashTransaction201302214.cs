using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_cash_transaction_20130221_4", DisableSyncStructure = true)]
	public partial class BakCashTransaction201302214 {

		[JsonProperty, Column(Name = "tran_id", IsPrimary = true, IsIdentity = true)]
		public long TranId { get; set; }

		[JsonProperty, Column(Name = "dummy", DbType = "char(1)", IsNullable = false)]
		public string Dummy { get; set; }

	}

}
