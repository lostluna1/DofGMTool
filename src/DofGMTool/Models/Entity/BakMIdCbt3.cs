using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_m_id_cbt_3", DisableSyncStructure = true)]
	public partial class BakMIdCbt3 {

		[JsonProperty, Column(Name = "m_id")]
		public int MId { get; set; } = 0;

	}

}
