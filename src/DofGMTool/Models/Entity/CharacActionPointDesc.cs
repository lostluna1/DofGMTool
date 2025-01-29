using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_action_point_desc", DisableSyncStructure = true)]
	public partial class CharacActionPointDesc {

		[JsonProperty, Column(Name = "action_group_index", IsPrimary = true)]
		public int ActionGroupIndex { get; set; } = 0;

		[JsonProperty, Column(Name = "action_index", IsPrimary = true)]
		public int ActionIndex { get; set; } = 0;

		[JsonProperty, Column(Name = "action_group_name", StringLength = 128)]
		public string ActionGroupName { get; set; }

	}

}
