using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_titlebook", DisableSyncStructure = true)]
	public partial class CharacTitlebook {

		[JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
		public uint CharacNo { get; set; } = 0;

		[JsonProperty, Column(Name = "despair", DbType = "blob")]
		public byte[] Despair { get; set; }

		[JsonProperty, Column(Name = "event", DbType = "blob")]
		public byte[] Event { get; set; }

		[JsonProperty, Column(Name = "general_section", DbType = "blob")]
		public byte[] GeneralSection { get; set; }

		[JsonProperty, Column(Name = "specific_section", DbType = "blob")]
		public byte[] SpecificSection { get; set; }

	}

}
