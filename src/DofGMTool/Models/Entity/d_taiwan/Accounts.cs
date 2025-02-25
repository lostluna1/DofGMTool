﻿using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "accounts", DisableSyncStructure = true)]
	public partial class Accounts {

		[JsonProperty, Column(IsPrimary = true, IsIdentity = true)]
		public int UID { get; set; }

		[JsonProperty, Column(Name = "accountname", IsNullable = false)]
		public string Accountname { get; set; }

		[JsonProperty, Column(Name = "billing", DbType = "int(8)")]
		public int? Billing { get; set; } = 0;

		[JsonProperty, Column(Name = "dzuid", DbType = "int(8)")]
		public int? Dzuid { get; set; }

		[JsonProperty, Column(Name = "password", IsNullable = false)]
		public string Password { get; set; }

		[JsonProperty, Column(Name = "qq")]
		public string Qq { get; set; }

		[JsonProperty, Column(IsNullable = false)]
		public string VIP { get; set; }

	}

}
