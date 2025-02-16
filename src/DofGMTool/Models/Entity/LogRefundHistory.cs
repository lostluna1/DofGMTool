using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "log_refund_history", DisableSyncStructure = true)]
	public partial class LogRefundHistory {

		[JsonProperty, Column(Name = "account_id", StringLength = 30, IsPrimary = true, IsNullable = false)]
		public string AccountId { get; set; }

		[JsonProperty, Column(Name = "tran_id", IsPrimary = true)]
		public ulong TranId { get; set; }

		[JsonProperty, Column(Name = "amount")]
		public uint Amount { get; set; }

		[JsonProperty, Column(Name = "occ_date", DbType = "datetime")]
		public DateTime OccDate { get; set; }

		[JsonProperty, Column(Name = "order_tran_id", StringLength = 35, IsNullable = false)]
		public string OrderTranId { get; set; }

		[JsonProperty, Column(Name = "query_user", StringLength = 45, IsNullable = false)]
		public string QueryUser { get; set; } = "None";

		[JsonProperty, Column(Name = "tran_state")]
		public byte TranState { get; set; }

	}

}
