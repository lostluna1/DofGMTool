using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "quest_category", DisableSyncStructure = true)]
	public partial class QuestCategory {

		[JsonProperty, Column(Name = "quest_idx", IsPrimary = true)]
		public int QuestIdx { get; set; } = 0;

		[JsonProperty, Column(Name = "quest_name", StringLength = 30, IsNullable = false)]
		public string QuestName { get; set; }

	}

}
