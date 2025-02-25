using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "dnf_gamein_notice", DisableSyncStructure = true)]
	public partial class DnfGameinNotice {

		[JsonProperty, Column(Name = "no", IsPrimary = true, IsIdentity = true)]
		public int No { get; set; }

		[JsonProperty, Column(Name = "img_name", StringLength = 250, IsNullable = false)]
		public string ImgName { get; set; }

		[JsonProperty, Column(Name = "open_flag", InsertValueSql = "'n'")]
		public DnfGameinNoticeOPENFLAG? OpenFlag { get; set; }

		[JsonProperty, Column(Name = "reg_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime RegTime { get; set; }

		[JsonProperty, Column(Name = "server_id", DbType = "tinyint(4)")]
		public sbyte ServerId { get; set; } = 0;

	}

	public enum DnfGameinNoticeOPENFLAG {
		y = 1, n
	}
}
