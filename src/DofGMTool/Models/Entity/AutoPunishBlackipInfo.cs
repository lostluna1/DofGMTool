using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "auto_punish_blackip_info", DisableSyncStructure = true)]
	public partial class AutoPunishBlackipInfo {

		[JsonProperty, Column(Name = "end_ip", IsPrimary = true)]
		public byte EndIp { get; set; } = 0;

		[JsonProperty, Column(Name = "ip", StringLength = 11, IsPrimary = true, IsNullable = false)]
		public string Ip { get; set; }

		[JsonProperty, Column(Name = "start_ip", IsPrimary = true)]
		public byte StartIp { get; set; } = 0;

		[JsonProperty, Column(Name = "apply_flag", DbType = "tinyint(4)")]
		public sbyte ApplyFlag { get; set; } = 0;

		[JsonProperty, Column(Name = "reg_date", DbType = "datetime")]
		public DateTime RegDate { get; set; }

	}

}
