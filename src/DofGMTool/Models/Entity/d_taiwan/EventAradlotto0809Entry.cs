using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "event_aradlotto_0809_entry", DisableSyncStructure = true)]
	public partial class EventAradlotto0809Entry {

		[JsonProperty, Column(Name = "m_id", IsPrimary = true)]
		public int MId { get; set; } = 0;

		[JsonProperty, Column(Name = "lotto_num", DbType = "char(7)", IsNullable = false)]
		public string LottoNum { get; set; }

		[JsonProperty, Column(Name = "occ_date")]
		public int OccDate { get; set; } = 0;

	}

}
