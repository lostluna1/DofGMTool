using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "bak_cash_sequence_20130219", DisableSyncStructure = true)]
	public partial class BakCashSequence20130219 {

		[JsonProperty, Column(Name = "sequence_id", IsPrimary = true, IsIdentity = true)]
		public long SequenceId { get; set; }

		[JsonProperty, Column(Name = "dummy", DbType = "char(1)", IsNullable = false)]
		public string Dummy { get; set; }

	}

}
