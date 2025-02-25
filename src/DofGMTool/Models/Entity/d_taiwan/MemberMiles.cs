using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "member_miles", DisableSyncStructure = true)]
	public partial class MemberMiles {

		[JsonProperty, Column(Name = "m_id", IsPrimary = true)]
		public int MId { get; set; } = 0;

		[JsonProperty, Column(Name = "daily_miles")]
		public short DailyMiles { get; set; } = 0;

		[JsonProperty, Column(Name = "miles")]
		public int Miles { get; set; } = 0;

	}

}
