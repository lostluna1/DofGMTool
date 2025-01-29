using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "log_num_occupations", DisableSyncStructure = true)]
	public partial class LogNumOccupations {

		[JsonProperty, Column(Name = "occ_time", DbType = "datetime", IsPrimary = true, InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime OccTime { get; set; }

		[JsonProperty, Column(Name = "num_login_per_min", DbType = "mediumint(8) unsigned")]
		public uint NumLoginPerMin { get; set; } = 0;

		[JsonProperty, Column(Name = "num_logout_per_min", DbType = "mediumint(8) unsigned")]
		public uint NumLogoutPerMin { get; set; } = 0;

		[JsonProperty, Column(Name = "num_occupations_charscreen", DbType = "mediumint(8) unsigned")]
		public uint NumOccupationsCharscreen { get; set; } = 0;

		[JsonProperty, Column(Name = "num_occupations_seriaroom", DbType = "mediumint(8) unsigned")]
		public uint NumOccupationsSeriaroom { get; set; } = 0;

	}

}
