using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "slang_list_name", DisableSyncStructure = true)]
	public partial class SlangListName {

		[JsonProperty, Column(Name = "slang", StringLength = 153, IsPrimary = true, IsNullable = false)]
		public string Slang { get; set; }

	}

}
