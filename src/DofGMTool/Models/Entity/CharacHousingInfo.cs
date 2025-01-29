﻿using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_housing_info", DisableSyncStructure = true)]
	public partial class CharacHousingInfo {

		[JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
		public uint CharacNo { get; set; } = 0;

		[JsonProperty, Column(Name = "decoration_inven", DbType = "binary(144)", InsertValueSql = "                                                                                                                                                ")]
		public byte[] DecorationInven { get; set; }

		[JsonProperty, Column(Name = "installed")]
		public ushort Installed { get; set; } = 0;

		[JsonProperty, Column(Name = "version")]
		public ushort Version { get; set; } = 0;

	}

}
