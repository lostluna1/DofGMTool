using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_housing_water_history", DisableSyncStructure = true)]
	public partial class CharacHousingWaterHistory {

		[JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
		public uint CharacNo { get; set; } = 0;

		[JsonProperty, Column(Name = "give_time", DbType = "timestamp", IsPrimary = true, InsertValueSql = "CURRENT_TIMESTAMP")]
		public DateTime GiveTime { get; set; }

		[JsonProperty, Column(Name = "give_charac_name", StringLength = 20, IsNullable = false)]
		public string GiveCharacName { get; set; }

	}

}
