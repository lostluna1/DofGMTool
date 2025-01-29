using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_option", DisableSyncStructure = true)]
	public partial class CharacOption {

		[JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
		public int CharacNo { get; set; } = 0;

		[JsonProperty, Column(Name = "best_clear_time", DbType = "blob")]
		public byte[] BestClearTime { get; set; }

		[JsonProperty, Column(Name = "blue_marble_enter_count")]
		public byte BlueMarbleEnterCount { get; set; } = 0;

		[JsonProperty, Column(Name = "charac_inform_notice", IsNullable = false)]
		public string CharacInformNotice { get; set; }

		[JsonProperty, Column(Name = "options", DbType = "blob")]
		public byte[] Options { get; set; }

	}

}
