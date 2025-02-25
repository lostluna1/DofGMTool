using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "admin_member", DisableSyncStructure = true)]
	public partial class AdminMember {

		[JsonProperty, Column(Name = "no", DbType = "int(20)", IsPrimary = true, IsIdentity = true)]
		public int No { get; set; }

		[JsonProperty, Column(Name = "comment", StringLength = -1)]
		public string Comment { get; set; }

		[JsonProperty, Column(Name = "confirm", DbType = "char(1)")]
		public string Confirm { get; set; } = "0";

		[JsonProperty, Column(Name = "email")]
		public string Email { get; set; }

		[JsonProperty, Column(Name = "level", StringLength = 2000, IsNullable = false)]
		public string Level { get; set; }

		[JsonProperty, Column(Name = "level_group1", StringLength = 2, IsNullable = false)]
		public string LevelGroup1 { get; set; } = "_";

		[JsonProperty, Column(Name = "level_group2", StringLength = 2, IsNullable = false)]
		public string LevelGroup2 { get; set; } = "_";

		[JsonProperty, Column(Name = "level_group3", StringLength = 2, IsNullable = false)]
		public string LevelGroup3 { get; set; } = "_";

		[JsonProperty, Column(Name = "level_group4", StringLength = 2, IsNullable = false)]
		public string LevelGroup4 { get; set; } = "_";

		[JsonProperty, Column(Name = "level_group5", StringLength = 2, IsNullable = false)]
		public string LevelGroup5 { get; set; } = "_";

		[JsonProperty, Column(Name = "level_group6", StringLength = 2, IsNullable = false)]
		public string LevelGroup6 { get; set; } = "_";

		[JsonProperty, Column(Name = "msn", StringLength = 50)]
		public string Msn { get; set; }

		[JsonProperty, Column(Name = "name", StringLength = 20, IsNullable = false)]
		public string Name { get; set; }

		[JsonProperty, Column(Name = "password", StringLength = 20, IsNullable = false)]
		public string Password { get; set; }

		[JsonProperty, Column(Name = "phone")]
		public string Phone { get; set; }

		[JsonProperty, Column(Name = "reg_date", DbType = "int(13)")]
		public int? RegDate { get; set; }

		[JsonProperty, Column(Name = "user_id", StringLength = 20, IsNullable = false)]
		public string UserId { get; set; }

	}

}
