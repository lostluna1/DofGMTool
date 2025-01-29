using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_view_act8", DisableSyncStructure = true)]
	public partial class CharacViewAct8 {

		[JsonProperty, Column(Name = "m_id", IsPrimary = true)]
		public ulong MId { get; set; } = 0;

		[JsonProperty, Column(Name = "charac_slot_limit")]
		public byte CharacSlotLimit { get; set; } = 18;

		[JsonProperty, Column(Name = "hash_key", StringLength = 32, IsNullable = false)]
		public string HashKey { get; set; }

		[JsonProperty, Column(Name = "info", DbType = "blob")]
		public byte[] Info { get; set; }

		[JsonProperty, Column(Name = "slot_effect_count")]
		public byte SlotEffectCount { get; set; } = 18;

	}

}
