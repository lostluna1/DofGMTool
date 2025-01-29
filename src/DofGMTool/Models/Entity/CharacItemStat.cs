using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_item_stat", DisableSyncStructure = true)]
	public partial class CharacItemStat {

		[JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
		public int CharacNo { get; set; } = 0;

		[JsonProperty, Column(Name = "check_flag", DbType = "blob")]
		public byte[] CheckFlag { get; set; }

		[JsonProperty, Column(Name = "cooltime_item", DbType = "blob")]
		public byte[] CooltimeItem { get; set; }

		[JsonProperty, Column(Name = "effect_item", DbType = "blob")]
		public byte[] EffectItem { get; set; }

	}

}
