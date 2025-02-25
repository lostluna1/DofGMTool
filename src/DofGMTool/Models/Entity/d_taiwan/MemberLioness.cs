using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "member_lioness", DisableSyncStructure = true)]
	public partial class MemberLioness {

		[JsonProperty, Column(Name = "user_id", StringLength = 30, IsNullable = false)]
		public string UserId { get; set; }

	}

}
