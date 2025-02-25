﻿using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "geo_reject", DisableSyncStructure = true)]
	public partial class GeoReject {

		[JsonProperty, Column(Name = "rej_ip", StringLength = 20, IsPrimary = true, IsNullable = false)]
		public string RejIp { get; set; }

		[JsonProperty, Column(Name = "rej_c_code", StringLength = 4, IsNullable = false)]
		public string RejCCode { get; set; }

		[JsonProperty, Column(Name = "rej_chk", DbType = "char(1)", IsNullable = false)]
		public string RejChk { get; set; } = "N";

		[JsonProperty, Column(Name = "rej_ip_count", DbType = "int(11) unsigned")]
		public uint RejIpCount { get; set; } = 0;

		[JsonProperty, Column(Name = "rej_last_date", DbType = "timestamp", InsertValueSql = "CURRENT_TIMESTAMP")]
		public DateTime RejLastDate { get; set; }

		[JsonProperty, Column(Name = "rej_src", InsertValueSql = "'w'")]
		public GeoRejectREJSRC RejSrc { get; set; }

	}

	public enum GeoRejectREJSRC {
		w = 1, g
	}
}
