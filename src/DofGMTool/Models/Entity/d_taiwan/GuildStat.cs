using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "guild_stat", DisableSyncStructure = true)]
	public partial class GuildStat {

		[JsonProperty, Column(Name = "lev", IsPrimary = true)]
		public byte Lev { get; set; } = 0;

		[JsonProperty, Column(Name = "occ_date", DbType = "date", IsPrimary = true, InsertValueSql = "0000-00-00")]
		public DateTime OccDate { get; set; }

		[JsonProperty, Column(Name = "server_id", DbType = "tinyint(4)", IsPrimary = true)]
		public sbyte ServerId { get; set; } = 0;

		[JsonProperty, Column(Name = "acc_create_no")]
		public int AccCreateNo { get; set; } = 0;

		[JsonProperty, Column(Name = "acc_member_no")]
		public int AccMemberNo { get; set; } = 0;

		[JsonProperty, Column(Name = "avg_lev")]
		public float AvgLev { get; set; } = 0f;

		[JsonProperty, Column(Name = "avg_master_lev")]
		public float AvgMasterLev { get; set; } = 0f;

		[JsonProperty, Column(Name = "create_no")]
		public int CreateNo { get; set; } = 0;

		[JsonProperty, Column(Name = "member_no")]
		public int MemberNo { get; set; } = 0;

	}

}
