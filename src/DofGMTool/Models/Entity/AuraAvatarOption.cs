using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "aura_avatar_option", DisableSyncStructure = true)]
	public partial class AuraAvatarOption {

		[JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
		public int CharacNo { get; set; } = 0;

		[JsonProperty, Column(Name = "option_type", DbType = "tinyint(4)", IsPrimary = true)]
		public sbyte OptionType { get; set; } = 0;

		[JsonProperty, Column(Name = "value_1")]
		public int Value1 { get; set; } = 0;

	}

}
