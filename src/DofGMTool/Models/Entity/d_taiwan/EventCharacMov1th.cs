using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "event_charac_mov_1th", DisableSyncStructure = true)]
	public partial class EventCharacMov1th {

		[JsonProperty, Column(Name = "id", IsPrimary = true, IsIdentity = true)]
		public int Id { get; set; }

		[JsonProperty, Column(Name = "charac_no")]
		public int CharacNo { get; set; } = 0;

		[JsonProperty, Column(Name = "m_id")]
		public int MId { get; set; } = 0;

		[JsonProperty, Column(Name = "move_charac_no")]
		public int MoveCharacNo { get; set; } = 0;

		[JsonProperty, Column(Name = "move_check")]
		public int MoveCheck { get; set; } = 0;

		[JsonProperty, Column(Name = "move_server_id", DbType = "tinyint(4)")]
		public sbyte MoveServerId { get; set; } = 0;

		[JsonProperty, Column(Name = "server_id", DbType = "tinyint(4)")]
		public sbyte ServerId { get; set; } = 0;

	}

}
