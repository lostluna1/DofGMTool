using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "single_rank_avg", DisableSyncStructure = true)]
	public partial class SingleRankAvg {

		[JsonProperty, Column(Name = "dungeon_index", IsPrimary = true)]
		public short DungeonIndex { get; set; } = 0;

		[JsonProperty, Column(Name = "job", IsPrimary = true)]
		public short Job { get; set; } = 0;

		[JsonProperty, Column(Name = "level", IsPrimary = true)]
		public short Level { get; set; } = 0;

		[JsonProperty, Column(Name = "average")]
		public int Average { get; set; } = 0;

		[JsonProperty, Column(Name = "clear_count")]
		public long ClearCount { get; set; } = 0;

	}

}
