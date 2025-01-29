using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "limit_npc_item", DisableSyncStructure = true)]
	public partial class LimitNpcItem {

		[JsonProperty, Column(Name = "item_index", IsPrimary = true)]
		public uint ItemIndex { get; set; } = 0;

		[JsonProperty, Column(Name = "max_count")]
		public uint MaxCount { get; set; } = 0;

		[JsonProperty, Column(Name = "sell_count")]
		public uint SellCount { get; set; } = 0;

	}

}
