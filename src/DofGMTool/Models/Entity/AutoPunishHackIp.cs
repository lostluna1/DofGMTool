using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "auto_punish_hack_ip", DisableSyncStructure = true)]
	public partial class AutoPunishHackIp {

		[JsonProperty, Column(Name = "c_class_ip", StringLength = 12, IsPrimary = true, IsNullable = false)]
		public string CClassIp { get; set; }

		[JsonProperty, Column(Name = "hack_sub_type", IsPrimary = true)]
		public ushort HackSubType { get; set; } = 0;

		[JsonProperty, Column(Name = "hack_type", IsPrimary = true)]
		public ushort HackType { get; set; } = 0;

		[JsonProperty, Column(Name = "occ_date", DbType = "date", IsPrimary = true, InsertValueSql = "0000-00-00")]
		public DateTime OccDate { get; set; }

		[JsonProperty, Column(Name = "cnt")]
		public uint Cnt { get; set; } = 0;

	}

}
