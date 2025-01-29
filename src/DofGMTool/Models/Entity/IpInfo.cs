using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "ip_info", DisableSyncStructure = true)]
	public partial class IpInfo {

		[JsonProperty, Column(Name = "no", IsPrimary = true, IsIdentity = true)]
		public uint No { get; set; }

		[JsonProperty, Column(Name = "charge_flag", DbType = "tinyint(4)")]
		public sbyte ChargeFlag { get; set; } = 0;

		[JsonProperty, Column(Name = "end_ip")]
		public byte EndIp { get; set; } = 0;

		[JsonProperty, Column(Name = "end_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime EndTime { get; set; }

		[JsonProperty, Column(Name = "ip", StringLength = 11, IsNullable = false)]
		public string Ip { get; set; }

		[JsonProperty, Column(Name = "ip_check")]
		public byte IpCheck { get; set; } = 0;

		[JsonProperty, Column(Name = "m_id")]
		public uint MId { get; set; } = 0;

		[JsonProperty, Column(Name = "occ_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime OccTime { get; set; }

		[JsonProperty, Column(Name = "settle_no")]
		public uint SettleNo { get; set; } = 0;

		[JsonProperty, Column(Name = "speed_no")]
		public uint SpeedNo { get; set; } = 0;

		[JsonProperty, Column(Name = "start_ip")]
		public byte StartIp { get; set; } = 0;

		[JsonProperty, Column(Name = "start_time", DbType = "datetime", InsertValueSql = "0000-00-00 00:00:00")]
		public DateTime StartTime { get; set; }

		[JsonProperty, Column(Name = "vendor_no")]
		public uint VendorNo { get; set; } = 0;

	}

}
