using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "village_attacked_charac_point_rank", DisableSyncStructure = true)]
	public partial class VillageAttackedCharacPointRank {

		[JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
		public uint CharacNo { get; set; } = 0;

		[JsonProperty, Column(Name = "occ_date", DbType = "date", IsPrimary = true, InsertValueSql = "0000-00-00")]
		public DateTime OccDate { get; set; }

		[JsonProperty, Column(Name = "server_info", IsPrimary = true)]
		public byte ServerInfo { get; set; } = 0;

		[JsonProperty, Column(Name = "hunting_point")]
		public uint HuntingPoint { get; set; } = 0;

		[JsonProperty, Column(Name = "rank")]
		public byte Rank { get; set; } = 0;

	}

}
