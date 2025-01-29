using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "auction_history", DisableSyncStructure = true)]
	public partial class AuctionHistory {

		[JsonProperty, Column(Name = "auction_id", IsPrimary = true)]
		public ulong AuctionId { get; set; } = 0;

		[JsonProperty, Column(Name = "add_info")]
		public int? AddInfo { get; set; }

		[JsonProperty, Column(Name = "amplify_option")]
		public byte AmplifyOption { get; set; } = 0;

		[JsonProperty, Column(Name = "amplify_value", DbType = "mediumint(8) unsigned")]
		public uint AmplifyValue { get; set; } = 0;

		[JsonProperty, Column(Name = "buyer_id")]
		public int? BuyerId { get; set; }

		[JsonProperty, Column(Name = "buyer_postal_id")]
		public uint? BuyerPostalId { get; set; }

		[JsonProperty, Column(Name = "endurance")]
		public ushort? Endurance { get; set; }

		[JsonProperty, Column(Name = "event_type", DbType = "tinyint(4)")]
		public sbyte? EventType { get; set; }

		[JsonProperty, Column(Name = "extend_info")]
		public uint? ExtendInfo { get; set; }

		[JsonProperty, Column(Name = "item_id")]
		public uint? ItemId { get; set; }

		[JsonProperty, Column(Name = "occ_time", DbType = "datetime")]
		public DateTime? OccTime { get; set; }

		[JsonProperty, Column(Name = "owner_id")]
		public int? OwnerId { get; set; }

		[JsonProperty, Column(Name = "owner_postal_id")]
		public uint? OwnerPostalId { get; set; }

		[JsonProperty, Column(Name = "price")]
		public int? Price { get; set; }

		[JsonProperty, Column(Name = "seal_cnt")]
		public byte? SealCnt { get; set; }

		[JsonProperty, Column(Name = "seal_flag", DbType = "tinyint(4)")]
		public sbyte? SealFlag { get; set; }

		[JsonProperty, Column(Name = "start_time", DbType = "datetime")]
		public DateTime? StartTime { get; set; }

		[JsonProperty, Column(Name = "unit_price", DbType = "int(11) unsigned")]
		public uint UnitPrice { get; set; } = 0;

		[JsonProperty, Column(Name = "upgrade")]
		public byte? Upgrade { get; set; }

	}

}
