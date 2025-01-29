using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_tower_record", DisableSyncStructure = true)]
	public partial class CharacTowerRecord {

		[JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
		public int CharacNo { get; set; } = 0;

		[JsonProperty, Column(Name = "member_info_1", DbType = "char(32)", IsNullable = false)]
		public string MemberInfo1 { get; set; }

		[JsonProperty, Column(Name = "member_info_2", DbType = "char(64)", IsNullable = false)]
		public string MemberInfo2 { get; set; }

		[JsonProperty, Column(Name = "member_info_3", DbType = "char(96)", IsNullable = false)]
		public string MemberInfo3 { get; set; }

		[JsonProperty, Column(Name = "member_info_4", DbType = "char(128)", IsNullable = false)]
		public string MemberInfo4 { get; set; }

		[JsonProperty, Column(Name = "occ_time_1", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime OccTime1 { get; set; }

		[JsonProperty, Column(Name = "occ_time_2", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime OccTime2 { get; set; }

		[JsonProperty, Column(Name = "occ_time_3", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime OccTime3 { get; set; }

		[JsonProperty, Column(Name = "occ_time_4", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime OccTime4 { get; set; }

		[JsonProperty, Column(Name = "play_time_1")]
		public uint PlayTime1 { get; set; } = 0;

		[JsonProperty, Column(Name = "play_time_2")]
		public uint PlayTime2 { get; set; } = 0;

		[JsonProperty, Column(Name = "play_time_3")]
		public uint PlayTime3 { get; set; } = 0;

		[JsonProperty, Column(Name = "play_time_4")]
		public uint PlayTime4 { get; set; } = 0;

		[JsonProperty, Column(Name = "stage_1")]
		public byte Stage1 { get; set; } = 0;

		[JsonProperty, Column(Name = "stage_2")]
		public byte Stage2 { get; set; } = 0;

		[JsonProperty, Column(Name = "stage_3")]
		public byte Stage3 { get; set; } = 0;

		[JsonProperty, Column(Name = "stage_4")]
		public byte Stage4 { get; set; } = 0;

		[JsonProperty, Column(Name = "tower_index")]
		public byte TowerIndex { get; set; } = 0;

	}

}
