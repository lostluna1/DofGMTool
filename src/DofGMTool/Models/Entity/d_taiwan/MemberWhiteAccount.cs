using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "member_white_account", DisableSyncStructure = true)]
	public partial class MemberWhiteAccount {

		[JsonProperty, Column(Name = "m_id", IsPrimary = true)]
		public uint MId { get; set; }

		[JsonProperty, Column(Name = "reg_date", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime RegDate { get; set; }

	}

}
