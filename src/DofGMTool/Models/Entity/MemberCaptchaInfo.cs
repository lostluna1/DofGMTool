using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "member_captcha_info", DisableSyncStructure = true)]
	public partial class MemberCaptchaInfo {

		[JsonProperty, Column(Name = "m_id", IsPrimary = true)]
		public uint MId { get; set; } = 0;

		[JsonProperty, Column(Name = "cert_time")]
		public uint CertTime { get; set; } = 0;

		[JsonProperty, Column(Name = "fail_count")]
		public byte FailCount { get; set; } = 0;

	}

}
