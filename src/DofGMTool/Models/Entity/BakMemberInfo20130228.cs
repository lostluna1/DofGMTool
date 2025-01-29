using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_member_info_20130228", DisableSyncStructure = true)]
	public partial class BakMemberInfo20130228 {

		[JsonProperty, Column(Name = "m_id")]
		public uint MId { get; set; } = 0;

		[JsonProperty, Column(Name = "user_id", StringLength = 30, IsNullable = false)]
		public string UserId { get; set; }

		[JsonProperty, Column(Name = "user_name", StringLength = 10, IsNullable = false)]
		public string UserName { get; set; }

	}

}
