using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "nexon_none_memner_restriction", DisableSyncStructure = true)]
	public partial class NexonNoneMemnerRestriction {

		[JsonProperty, Column(Name = "charac_id", DbType = "int(11) unsigned")]
		public uint CharacId { get; set; } = 0;

		[JsonProperty, Column(Name = "last_trade_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime LastTradeTime { get; set; }

		[JsonProperty, Column(Name = "m_id", DbType = "int(11) unsigned")]
		public uint MId { get; set; } = 0;

		[JsonProperty, Column(Name = "nexon_user", DbType = "tinyint(4)")]
		public sbyte NexonUser { get; set; } = 0;

		[JsonProperty, Column(Name = "total_trade_gold", DbType = "int(12) unsigned")]
		public uint TotalTradeGold { get; set; } = 0;

		[JsonProperty, Column(Name = "trade_count", DbType = "smallint(6) unsigned")]
		public ushort TradeCount { get; set; } = 0;

	}

}
