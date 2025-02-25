using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "event_pandora_entry_200905", DisableSyncStructure = true)]
	public partial class EventPandoraEntry200905 {

		[JsonProperty, Column(Name = "m_id", DbType = "int(11) unsigned", IsPrimary = true)]
		public uint MId { get; set; } = 0;

		[JsonProperty, Column(Name = "occ_date", DbType = "date", IsPrimary = true, InsertValueSql = "0000-00-00")]
		public DateTime OccDate { get; set; }

		[JsonProperty, Column(Name = "server_id", DbType = "tinyint(4) unsigned", IsPrimary = true)]
		public byte ServerId { get; set; } = 0;

		[JsonProperty, Column(Name = "charac_no", DbType = "int(11) unsigned")]
		public uint CharacNo { get; set; } = 0;

	}

}
