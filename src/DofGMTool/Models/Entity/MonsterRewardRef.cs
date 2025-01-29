using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "monster_reward_ref", DisableSyncStructure = true)]
	public partial class MonsterRewardRef {

		[JsonProperty, Column(Name = "exp")]
		public int Exp { get; set; } = 0;

		[JsonProperty, Column(Name = "level", DbType = "smallint(11)")]
		public short Level { get; set; } = 0;

	}

}
