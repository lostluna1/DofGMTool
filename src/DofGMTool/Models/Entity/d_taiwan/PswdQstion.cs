﻿using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "pswd_qstion", DisableSyncStructure = true)]
	public partial class PswdQstion {

		[JsonProperty, Column(Name = "q_no", DbType = "tinyint(4)", IsPrimary = true)]
		public sbyte QNo { get; set; } = 0;

		[JsonProperty, Column(Name = "q_text", StringLength = 20, IsNullable = false)]
		public string QText { get; set; }

	}

}
