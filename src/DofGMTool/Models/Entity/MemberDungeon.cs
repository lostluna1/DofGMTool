using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "member_dungeon", DisableSyncStructure = true)]
	public partial class MemberDungeon {

		[JsonProperty, Column(Name = "m_id", IsPrimary = true)]
		public uint MId { get; set; } = 0;

		[JsonProperty, Column(Name = "dungeon", StringLength = -1, IsNullable = false)]
		public string Dungeon { get; set; }

	}

}
