using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "gift_ticket_entry", DisableSyncStructure = true)]
	public partial class GiftTicketEntry {

		[JsonProperty, Column(Name = "id", IsPrimary = true, IsIdentity = true)]
		public uint Id { get; set; }

		[JsonProperty, Column(Name = "buyer_check")]
		public uint BuyerCheck { get; set; } = 0;

		[JsonProperty, Column(Name = "buyer_code", StringLength = 21, IsNullable = false)]
		public string BuyerCode { get; set; }

		[JsonProperty, Column(Name = "buyer_date")]
		public uint BuyerDate { get; set; } = 0;

		[JsonProperty, Column(Name = "buyer_id")]
		public uint BuyerId { get; set; } = 0;

		[JsonProperty, Column(Name = "gift_no")]
		public ushort GiftNo { get; set; } = 0;

		[JsonProperty, Column(Name = "message", StringLength = 200, IsNullable = false)]
		public string Message { get; set; }

		[JsonProperty, Column(Name = "other_check")]
		public uint OtherCheck { get; set; } = 0;

		[JsonProperty, Column(Name = "other_code", StringLength = 21, IsNullable = false)]
		public string OtherCode { get; set; }

		[JsonProperty, Column(Name = "other_date")]
		public uint OtherDate { get; set; } = 0;

		[JsonProperty, Column(Name = "other_id")]
		public uint OtherId { get; set; } = 0;

	}

}
