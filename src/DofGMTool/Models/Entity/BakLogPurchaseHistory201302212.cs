using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	/// <summary>
	/// purchase history
	/// </summary>
	[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_log_purchase_history_20130221_2", DisableSyncStructure = true)]
	public partial class BakLogPurchaseHistory201302212 {

		[JsonProperty, Column(Name = "tran_id", IsPrimary = true)]
		public ulong TranId { get; set; }

		[JsonProperty, Column(Name = "account_id", DbType = "char(30)", IsNullable = false)]
		public string AccountId { get; set; }

		[JsonProperty, Column(Name = "after_cera")]
		public uint AfterCera { get; set; }

		[JsonProperty, Column(Name = "befor_cera")]
		public uint BeforCera { get; set; }

		[JsonProperty, Column(Name = "cera")]
		public uint Cera { get; set; }

		[JsonProperty, Column(Name = "charac_id", DbType = "char(30)", IsNullable = false)]
		public string CharacId { get; set; }

		[JsonProperty, Column(Name = "item_id")]
		public uint ItemId { get; set; }

		[JsonProperty, Column(Name = "occ_date", DbType = "datetime")]
		public DateTime OccDate { get; set; }

		[JsonProperty, Column(Name = "tran_state")]
		public byte TranState { get; set; }

	}

}
