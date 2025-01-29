using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_m_id_20130405", DisableSyncStructure = true)]
	public partial class BakMId20130405 {

		[JsonProperty, Column(Name = "m_id")]
		public uint MId { get; set; } = 0;

	}

}
