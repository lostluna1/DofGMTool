using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "guild_halloffame_html", DisableSyncStructure = true)]
	public partial class GuildHalloffameHtml {

		[JsonProperty, Column(Name = "fame_id", IsPrimary = true)]
		public int FameId { get; set; } = 0;

		[JsonProperty, Column(Name = "html", StringLength = -1, IsNullable = false)]
		public string Html { get; set; }

		[JsonProperty, Column(Name = "title", StringLength = 100, IsNullable = false)]
		public string Title { get; set; }

	}

}
