﻿using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "guild_event", DisableSyncStructure = true)]
	public partial class GuildEvent {

		[JsonProperty, Column(Name = "gno", IsPrimary = true)]
		public int Gno { get; set; } = 0;

		[JsonProperty, Column(Name = "ann_date", DbType = "date", InsertValueSql = "0000-00-00")]
		public DateTime AnnDate { get; set; }

		[JsonProperty, Column(Name = "end_date", DbType = "date", InsertValueSql = "0000-00-00")]
		public DateTime EndDate { get; set; }

		[JsonProperty, Column(Name = "page_url", StringLength = 100, IsNullable = false)]
		public string PageUrl { get; set; }

		[JsonProperty, Column(Name = "stt_date", DbType = "date", InsertValueSql = "0000-00-00")]
		public DateTime SttDate { get; set; }

	}

}
