using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "auto_punish_second_log", DisableSyncStructure = true)]
	public partial class AutoPunishSecondLog {

		[JsonProperty, Column(Name = "hack_m_id", IsPrimary = true)]
		public int HackMId { get; set; } = 0;

		[JsonProperty, Column(Name = "m_id", IsPrimary = true)]
		public int MId { get; set; } = 0;

		[JsonProperty, Column(Name = "occ_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime OccTime { get; set; }

		[JsonProperty, Column(Name = "trade_cnt")]
		public uint TradeCnt { get; set; } = 0;

		[JsonProperty, Column(Name = "trade_gold")]
		public ulong TradeGold { get; set; } = 0;

	}

}
