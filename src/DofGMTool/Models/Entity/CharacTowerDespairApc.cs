using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_tower_despair_apc", DisableSyncStructure = true)]
	public partial class CharacTowerDespairApc {

		[JsonProperty, Column(Name = "reg_date", DbType = "date", IsPrimary = true, InsertValueSql = "0000-00-00")]
		public DateTime RegDate { get; set; }

		[JsonProperty, Column(Name = "seq", IsPrimary = true)]
		public int Seq { get; set; } = 0;

		[JsonProperty, Column(Name = "charac_no")]
		public int CharacNo { get; set; } = 0;

	}

}
