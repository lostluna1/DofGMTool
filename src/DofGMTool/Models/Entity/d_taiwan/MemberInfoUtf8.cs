using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "member_info_utf8", DisableSyncStructure = true)]
	public partial class MemberInfoUtf8 {

		[JsonProperty, Column(Name = "m_id", IsPrimary = true)]
		public int MId { get; set; } = 0;

		[JsonProperty, Column(Name = "email", StringLength = 50, IsNullable = false)]
		public string Email { get; set; }

		[JsonProperty, Column(Name = "email_yn", InsertValueSql = "'y'")]
		public MemberInfoUtf8EMAILYN EmailYn { get; set; }

		[JsonProperty, Column(Name = "first_ssn", StringLength = 6, IsNullable = false)]
		public string FirstSsn { get; set; }

		[JsonProperty, Column(Name = "hangame_flag", DbType = "tinyint(4)")]
		public sbyte HangameFlag { get; set; } = 0;

		[JsonProperty, Column(Name = "hanmon_flag", DbType = "tinyint(4)")]
		public sbyte HanmonFlag { get; set; } = 0;

		[JsonProperty, Column(Name = "last_play_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime LastPlayTime { get; set; }

		[JsonProperty, Column(Name = "mobile_no", StringLength = 15, IsNullable = false)]
		public string MobileNo { get; set; }

		[JsonProperty, Column(Name = "nickname", StringLength = 16, IsNullable = false)]
		public string Nickname { get; set; }

		[JsonProperty, Column(Name = "passwd", StringLength = 32, IsNullable = false)]
		public string Passwd { get; set; }

		[JsonProperty, Column(Name = "q_answer", StringLength = 30, IsNullable = false)]
		public string QAnswer { get; set; }

		[JsonProperty, Column(Name = "q_no", DbType = "tinyint(4)")]
		public sbyte QNo { get; set; } = 0;

		[JsonProperty, Column(Name = "reg_date")]
		public int RegDate { get; set; } = 0;

		[JsonProperty, Column(Name = "second_ssn", StringLength = 7, IsNullable = false)]
		public string SecondSsn { get; set; }

		[JsonProperty, Column(Name = "slot")]
		public uint Slot { get; set; } = 8;

		[JsonProperty, Column(Name = "ssn_check")]
		public byte SsnCheck { get; set; } = 0;

		[JsonProperty, Column(Name = "state", DbType = "tinyint(4)")]
		public sbyte State { get; set; } = 1;

		[JsonProperty, Column(Name = "updt_date", DbType = "timestamp", InsertValueSql = "CURRENT_TIMESTAMP")]
		public DateTime UpdtDate { get; set; }

		[JsonProperty, Column(Name = "user_id", StringLength = 30)]
		public string UserId { get; set; }

		[JsonProperty, Column(Name = "user_name", StringLength = 10, IsNullable = false)]
		public string UserName { get; set; }

	}

	public enum MemberInfoUtf8EMAILYN {
		y = 1, n
	}
}
