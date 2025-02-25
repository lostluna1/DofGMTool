using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "test", DisableSyncStructure = true)]
	public partial class Test {

		[JsonProperty, Column(Name = "a")]
		public int? A { get; set; }

		[JsonProperty, Column(Name = "b", DbType = "datetime")]
		public DateTime? B { get; set; }

	}

}
