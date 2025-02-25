using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "guild_member_introduce", DisableSyncStructure = true)]
	public partial class GuildMemberIntroduce {

		[JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
		public int CharacNo { get; set; } = 0;

		[JsonProperty, Column(Name = "guild_id", IsPrimary = true)]
		public int GuildId { get; set; } = 0;

		[JsonProperty, Column(Name = "introduce", StringLength = 200, IsNullable = false)]
		public string Introduce { get; set; }

	}

}
