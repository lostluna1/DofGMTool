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

		[JsonProperty, Column(Name = "id", DbType = "int(111)", IsPrimary = true, IsIdentity = true)]
		public int Id { get; set; }

		[JsonProperty, Column(Name = "hashs", StringLength = 16, IsNullable = false)]
		public string Hashs { get; set; }

	}

}
