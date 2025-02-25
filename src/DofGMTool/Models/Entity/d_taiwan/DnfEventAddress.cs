using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "dnf_event_address", DisableSyncStructure = true)]
	public partial class DnfEventAddress {

		[JsonProperty, Column(Name = "event_id", IsPrimary = true)]
		public int EventId { get; set; } = 0;

		[JsonProperty, Column(Name = "m_id", IsPrimary = true)]
		public int MId { get; set; } = 0;

		[JsonProperty, Column(Name = "address", StringLength = 150, IsNullable = false)]
		public string Address { get; set; }

		[JsonProperty, Column(Name = "occ_date", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime OccDate { get; set; }

		[JsonProperty, Column(Name = "phone_no", StringLength = 15, IsNullable = false)]
		public string PhoneNo { get; set; }

		[JsonProperty, Column(Name = "zipcode", StringLength = 7, IsNullable = false)]
		public string Zipcode { get; set; }

	}

}
