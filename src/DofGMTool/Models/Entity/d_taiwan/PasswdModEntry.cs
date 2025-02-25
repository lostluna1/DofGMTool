using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "passwd_mod_entry", DisableSyncStructure = true)]
	public partial class PasswdModEntry {

		[JsonProperty, Column(Name = "m_id", IsPrimary = true)]
		public int MId { get; set; } = 0;

		[JsonProperty, Column(Name = "occ_time", DbType = "datetime", IsPrimary = true, InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime OccTime { get; set; }

		[JsonProperty, Column(Name = "ip", StringLength = 15, IsNullable = false)]
		public string Ip { get; set; }

		[JsonProperty, Column(Name = "pre_passwd", StringLength = 32, IsNullable = false)]
		public string PrePasswd { get; set; }

	}

}
