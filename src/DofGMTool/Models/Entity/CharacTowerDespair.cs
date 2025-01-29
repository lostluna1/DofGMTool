using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_tower_despair", DisableSyncStructure = true)]
	public partial class CharacTowerDespair {

		[JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
		public int CharacNo { get; set; } = 0;

		[JsonProperty, Column(Name = "enter_count_by_week")]
		public int EnterCountByWeek { get; set; } = 0;

		[JsonProperty, Column(Name = "first_layer_start_date", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime FirstLayerStartDate { get; set; }

		[JsonProperty, Column(Name = "last_clear_date", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime LastClearDate { get; set; }

		[JsonProperty, Column(Name = "last_clear_layer", DbType = "tinyint(4)")]
		public sbyte LastClearLayer { get; set; } = 0;

		[JsonProperty, Column(Name = "m_date", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime MDate { get; set; }

		[JsonProperty, Column(Name = "today_enter_count", DbType = "tinyint(4)")]
		public sbyte TodayEnterCount { get; set; } = 0;

	}

}
