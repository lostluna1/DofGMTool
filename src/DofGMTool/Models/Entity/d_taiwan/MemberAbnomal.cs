using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "member_abnomal", DisableSyncStructure = true)]
	public partial class MemberAbnomal {

		[JsonProperty, Column(Name = "user_id", StringLength = 12, IsPrimary = true, IsNullable = false)]
		public string UserId { get; set; }

		[JsonProperty, Column(Name = "overlab_count")]
		public short OverlabCount { get; set; } = 0;

	}

}
