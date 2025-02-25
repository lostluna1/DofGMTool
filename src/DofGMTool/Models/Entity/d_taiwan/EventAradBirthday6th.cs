using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "event_arad_birthday_6th", DisableSyncStructure = true)]
	public partial class EventAradBirthday6th {

		[JsonProperty, Column(Name = "server", IsPrimary = true)]
		public uint Server { get; set; } = 0;

		[JsonProperty, Column(Name = "point")]
		public uint Point { get; set; } = 0;

	}

}
