using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_log_transaction_history_20130221_4", DisableSyncStructure = true)]
	public partial class BakLogTransactionHistory201302214 {

		[JsonProperty, Column(Name = "tran_id", IsPrimary = true)]
		public ulong TranId { get; set; }

		[JsonProperty, Column(Name = "occ_date", DbType = "datetime")]
		public DateTime OccDate { get; set; }

		[JsonProperty, Column(Name = "tran_type")]
		public byte TranType { get; set; }

	}

}
