using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "pvp_grade_ref", DisableSyncStructure = true)]
	public partial class PvpGradeRef {

		[JsonProperty, Column(Name = "grade", IsPrimary = true)]
		public int Grade { get; set; } = 0;

		[JsonProperty, Column(Name = "limit_pts")]
		public int LimitPts { get; set; } = 0;

	}

}
