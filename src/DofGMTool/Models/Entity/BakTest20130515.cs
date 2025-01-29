using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_test_20130515", DisableSyncStructure = true)]
	public partial class BakTest20130515 {

		[JsonProperty, Column(Name = "a")]
		public uint A { get; set; } = 0;

	}

}
