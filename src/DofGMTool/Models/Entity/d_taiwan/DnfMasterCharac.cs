using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "dnf_master_charac", DisableSyncStructure = true)]
	public partial class DnfMasterCharac {

		[JsonProperty, Column(Name = "global_type", DbType = "tinyint(4)", IsPrimary = true)]
		public sbyte GlobalType { get; set; } = 0;

		[JsonProperty, Column(Name = "m_id", IsPrimary = true)]
		public int MId { get; set; } = 0;

		[JsonProperty, Column(Name = "server_id", DbType = "tinyint(4)", IsPrimary = true)]
		public sbyte ServerId { get; set; } = 0;

		[JsonProperty, Column(Name = "charac_name", StringLength = 20, IsNullable = false)]
		public string CharacName { get; set; }

		[JsonProperty, Column(Name = "charac_no")]
		public int CharacNo { get; set; } = 0;

		[JsonProperty, Column(Name = "job", DbType = "tinyint(4)")]
		public sbyte Job { get; set; } = 0;

		[JsonProperty, Column(Name = "lev", DbType = "tinyint(4)")]
		public sbyte Lev { get; set; } = 0;

	}

}
