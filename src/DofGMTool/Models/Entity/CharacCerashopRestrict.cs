using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_cerashop_restrict", DisableSyncStructure = true)]
	public partial class CharacCerashopRestrict {

		[JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
		public uint CharacNo { get; set; } = 0;

		[JsonProperty, Column(Name = "ipg_no", IsPrimary = true)]
		public uint IpgNo { get; set; } = 0;

		[JsonProperty, Column(Name = "count")]
		public uint Count { get; set; } = 0;

		[JsonProperty, Column(Name = "end_date")]
		public uint EndDate { get; set; } = 0;

		[JsonProperty, Column(Name = "last_access_date")]
		public uint LastAccessDate { get; set; } = 0;

		[JsonProperty, Column(Name = "next_date")]
		public uint NextDate { get; set; } = 0;

	}

}
