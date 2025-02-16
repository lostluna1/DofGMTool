using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "allow_proxy_user", DisableSyncStructure = true)]
	public partial class AllowProxyUser {

		[JsonProperty, Column(Name = "m_id", IsPrimary = true)]
		public uint MId { get; set; } = 0;

	}

}
