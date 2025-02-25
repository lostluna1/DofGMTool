using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "test2", DisableSyncStructure = true)]
	public partial class Test2 {

		[JsonProperty, Column(Name = "a")]
		public uint A { get; set; }

	}

}
