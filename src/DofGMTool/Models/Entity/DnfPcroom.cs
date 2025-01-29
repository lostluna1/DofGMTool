using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "dnf_pcroom", DisableSyncStructure = true)]
	public partial class DnfPcroom {

		[JsonProperty, Column(Name = "ip_no", IsPrimary = true, IsIdentity = true)]
		public int IpNo { get; set; }

		[JsonProperty, Column(Name = "address", StringLength = 150, IsNullable = false)]
		public string Address { get; set; }

		[JsonProperty, Column(Name = "district", StringLength = 20, IsNullable = false)]
		public string District { get; set; }

		[JsonProperty, Column(Name = "end_ip")]
		public byte EndIp { get; set; } = 0;

		[JsonProperty, Column(Name = "firm_name", StringLength = 50, IsNullable = false)]
		public string FirmName { get; set; }

		[JsonProperty, Column(Name = "ip", StringLength = 11, IsNullable = false)]
		public string Ip { get; set; }

		[JsonProperty, Column(Name = "leader", StringLength = 30, IsNullable = false)]
		public string Leader { get; set; }

		[JsonProperty, Column(Name = "start_ip")]
		public byte StartIp { get; set; } = 0;

		[JsonProperty, Column(Name = "telephone", StringLength = 20, IsNullable = false)]
		public string Telephone { get; set; }

	}

}
