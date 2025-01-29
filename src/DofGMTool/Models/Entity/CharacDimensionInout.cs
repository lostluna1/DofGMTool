using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_dimension_inout", DisableSyncStructure = true)]
	public partial class CharacDimensionInout {

		[JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
		public int CharacNo { get; set; } = 0;

		[JsonProperty, Column(Name = "dungeon1", DbType = "tinyint(4)")]
		public sbyte Dungeon1 { get; set; } = 0;

		[JsonProperty, Column(Name = "dungeon10", DbType = "tinyint(4)")]
		public sbyte Dungeon10 { get; set; } = 0;

		[JsonProperty, Column(Name = "dungeon2", DbType = "tinyint(4)")]
		public sbyte Dungeon2 { get; set; } = 0;

		[JsonProperty, Column(Name = "dungeon3", DbType = "tinyint(4)")]
		public sbyte Dungeon3 { get; set; } = 0;

		[JsonProperty, Column(Name = "dungeon4", DbType = "tinyint(4)")]
		public sbyte Dungeon4 { get; set; } = 0;

		[JsonProperty, Column(Name = "dungeon5", DbType = "tinyint(4)")]
		public sbyte Dungeon5 { get; set; } = 0;

		[JsonProperty, Column(Name = "dungeon6", DbType = "tinyint(4)")]
		public sbyte Dungeon6 { get; set; } = 0;

		[JsonProperty, Column(Name = "dungeon7", DbType = "tinyint(4)")]
		public sbyte Dungeon7 { get; set; } = 0;

		[JsonProperty, Column(Name = "dungeon8", DbType = "tinyint(4)")]
		public sbyte Dungeon8 { get; set; } = 0;

		[JsonProperty, Column(Name = "dungeon9", DbType = "tinyint(4)")]
		public sbyte Dungeon9 { get; set; } = 0;

	}

}
