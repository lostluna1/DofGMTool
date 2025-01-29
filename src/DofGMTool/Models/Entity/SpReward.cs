using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "sp_reward", DisableSyncStructure = true)]
	public partial class SpReward {

		[JsonProperty, Column(Name = "grade")]
		public int Grade { get; set; } = 0;

		[JsonProperty, Column(Name = "sp")]
		public int Sp { get; set; } = 0;

	}

}
