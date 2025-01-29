using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_link_bonus", DisableSyncStructure = true)]
	public partial class CharacLinkBonus {

		[JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
		public uint CharacNo { get; set; } = 0;

		[JsonProperty, Column(Name = "exp")]
		public uint Exp { get; set; } = 0;

		[JsonProperty, Column(Name = "gold")]
		public uint Gold { get; set; } = 0;

		[JsonProperty, Column(Name = "mercenary_area", DbType = "tinyint(4)")]
		public sbyte MercenaryArea { get; set; } = -1;

		[JsonProperty, Column(Name = "mercenary_finish_time")]
		public int MercenaryFinishTime { get; set; } = 0;

		[JsonProperty, Column(Name = "mercenary_period", DbType = "tinyint(4)")]
		public sbyte MercenaryPeriod { get; set; } = -1;

		[JsonProperty, Column(Name = "mercenary_start_time")]
		public int MercenaryStartTime { get; set; } = 0;

	}

}
