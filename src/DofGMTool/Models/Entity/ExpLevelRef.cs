using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "exp_level_ref", DisableSyncStructure = true)]
	public partial class ExpLevelRef {

		[JsonProperty, Column(Name = "exp")]
		public uint Exp { get; set; } = 0;

		[JsonProperty, Column(Name = "lev", DbType = "int(11) unsigned")]
		public uint Lev { get; set; } = 0;

	}

}
