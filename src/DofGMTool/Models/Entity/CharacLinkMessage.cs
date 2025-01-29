using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_link_message", DisableSyncStructure = true)]
	public partial class CharacLinkMessage {

		[JsonProperty, Column(Name = "m_id", IsPrimary = true)]
		public uint MId { get; set; } = 0;

		[JsonProperty, Column(Name = "message_flag", DbType = "tinyint(4)")]
		public sbyte MessageFlag { get; set; } = 0;

	}

}
