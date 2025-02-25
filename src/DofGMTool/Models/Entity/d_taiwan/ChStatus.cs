using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "ch_status", DisableSyncStructure = true)]
	public partial class ChStatus {

		[JsonProperty, Column(Name = "gc_group")]
		public byte GcGroup { get; set; } = 1;

		[JsonProperty, Column(Name = "gc_status")]
		public byte GcStatus { get; set; } = 0;

	}

}
