using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_tower_rank_top5", DisableSyncStructure = true)]
	public partial class CharacTowerRankTop5 {

		[JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
		public int CharacNo { get; set; } = 0;

		[JsonProperty, Column(Name = "part_type", DbType = "tinyint(4)", IsPrimary = true)]
		public sbyte PartType { get; set; } = 0;

		[JsonProperty, Column(Name = "tower_index", IsPrimary = true)]
		public byte TowerIndex { get; set; } = 0;

		[JsonProperty, Column(Name = "member_info", DbType = "char(128)", IsNullable = false)]
		public string MemberInfo { get; set; }

		[JsonProperty, Column(Name = "rank")]
		public ushort Rank { get; set; } = 0;

	}

}
