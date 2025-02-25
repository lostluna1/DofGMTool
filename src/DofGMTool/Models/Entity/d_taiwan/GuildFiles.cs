using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "guild_files", DisableSyncStructure = true)]
	public partial class GuildFiles {

		[JsonProperty, Column(Name = "gf_no", DbType = "tinyint(4)", IsPrimary = true, IsIdentity = true)]
		public sbyte GfNo { get; set; }

		[JsonProperty, Column(Name = "gno", IsPrimary = true)]
		public int Gno { get; set; } = 0;

		[JsonProperty, Column(Name = "file_location", StringLength = 100, IsNullable = false)]
		public string FileLocation { get; set; }

		[JsonProperty, Column(Name = "file_server", StringLength = 50, IsNullable = false)]
		public string FileServer { get; set; }

	}

}
