using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_quest_ref", DisableSyncStructure = true)]
	public partial class CharacQuestRef {

		[JsonProperty, Column(Name = "origin_idx", IsPrimary = true)]
		public int OriginIdx { get; set; } = 0;

		[JsonProperty, Column(Name = "mapped_idx")]
		public int MappedIdx { get; set; } = 0;

	}

}
