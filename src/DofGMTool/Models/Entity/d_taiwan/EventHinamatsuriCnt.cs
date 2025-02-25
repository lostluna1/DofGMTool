using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "event_hinamatsuri_cnt", DisableSyncStructure = true)]
	public partial class EventHinamatsuriCnt {

		[JsonProperty, Column(Name = "cnt")]
		public int Cnt { get; set; } = 0;

	}

}
