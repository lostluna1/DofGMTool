using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "news_bbs", DisableSyncStructure = true)]
	public partial class NewsBbs {

		[JsonProperty, Column(Name = "bbs_code", DbType = "tinyint(4)", IsPrimary = true)]
		public sbyte BbsCode { get; set; } = 0;

		[JsonProperty, Column(Name = "emph_yn", DbType = "tinyint(1)", IsPrimary = true)]
		public sbyte EmphYn { get; set; } = 0;

		[JsonProperty, Column(Name = "no", IsPrimary = true, IsIdentity = true)]
		public int No { get; set; }

		[JsonProperty, Column(Name = "body", StringLength = -1, IsNullable = false)]
		public string Body { get; set; }

		[JsonProperty, Column(Name = "file_name", StringLength = 50)]
		public string FileName { get; set; }

		[JsonProperty, Column(Name = "hits")]
		public short Hits { get; set; } = 0;

		[JsonProperty, Column(Name = "html_yn", DbType = "tinyint(1)")]
		public sbyte? HtmlYn { get; set; } = 0;

		[JsonProperty, Column(Name = "next_no")]
		public int NextNo { get; set; } = 0;

		[JsonProperty, Column(Name = "prev_no")]
		public int PrevNo { get; set; } = 0;

		[JsonProperty, Column(Name = "reg_date")]
		public int RegDate { get; set; } = 0;

		[JsonProperty, Column(Name = "subject", StringLength = 50, IsNullable = false)]
		public string Subject { get; set; }

		[JsonProperty, Column(Name = "updt_date")]
		public int? UpdtDate { get; set; }

		[JsonProperty, Column(Name = "use_yn", DbType = "tinyint(1)")]
		public sbyte UseYn { get; set; } = 1;

		[JsonProperty, Column(Name = "user_id", StringLength = 12, IsNullable = false)]
		public string UserId { get; set; }

	}

}
