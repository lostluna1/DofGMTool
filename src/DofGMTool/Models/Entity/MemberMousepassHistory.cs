using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "member_mousepass_history", DisableSyncStructure = true)]
	public partial class MemberMousepassHistory {

		[JsonProperty, Column(Name = "m_id")]
		public int MId { get; set; } = 0;

		[JsonProperty, Column(Name = "modify_type", DbType = "tinyint(4)")]
		public sbyte ModifyType { get; set; } = 0;

		[JsonProperty, Column(Name = "occ_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime OccTime { get; set; }

		[JsonProperty, Column(Name = "pre_mousepass", StringLength = 32, IsNullable = false)]
		public string PreMousepass { get; set; }

	}

}
