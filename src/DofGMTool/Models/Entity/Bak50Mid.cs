using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_50_mid", DisableSyncStructure = true)]
	public partial class Bak50Mid {

		[JsonProperty, Column(Name = "m_id")]
		public uint MId { get; set; } = 0;

	}

}
