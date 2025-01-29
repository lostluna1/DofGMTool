using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "new_charac_quest", DisableSyncStructure = true)]
	public partial class NewCharacQuest {

		[JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
		public uint CharacNo { get; set; } = 0;

		[JsonProperty, Column(Name = "auto_clear")]
		public byte AutoClear { get; set; } = 0;

		[JsonProperty, Column(Name = "clear_quest", DbType = "blob")]
		public byte[] ClearQuest { get; set; }

		[JsonProperty, Column(Name = "play_1")]
		public ushort Play1 { get; set; } = 0;

		[JsonProperty, Column(Name = "play_1_trigger")]
		public uint Play1Trigger { get; set; } = 0;

		[JsonProperty, Column(Name = "play_10")]
		public ushort Play10 { get; set; } = 0;

		[JsonProperty, Column(Name = "play_10_trigger")]
		public uint Play10Trigger { get; set; } = 0;

		[JsonProperty, Column(Name = "play_11")]
		public ushort Play11 { get; set; } = 0;

		[JsonProperty, Column(Name = "play_11_trigger")]
		public uint Play11Trigger { get; set; } = 0;

		[JsonProperty, Column(Name = "play_12")]
		public ushort Play12 { get; set; } = 0;

		[JsonProperty, Column(Name = "play_12_trigger")]
		public uint Play12Trigger { get; set; } = 0;

		[JsonProperty, Column(Name = "play_13")]
		public ushort Play13 { get; set; } = 0;

		[JsonProperty, Column(Name = "play_13_trigger")]
		public uint Play13Trigger { get; set; } = 0;

		[JsonProperty, Column(Name = "play_14")]
		public ushort Play14 { get; set; } = 0;

		[JsonProperty, Column(Name = "play_14_trigger")]
		public uint Play14Trigger { get; set; } = 0;

		[JsonProperty, Column(Name = "play_15")]
		public ushort Play15 { get; set; } = 0;

		[JsonProperty, Column(Name = "play_15_trigger")]
		public uint Play15Trigger { get; set; } = 0;

		[JsonProperty, Column(Name = "play_16")]
		public ushort Play16 { get; set; } = 0;

		[JsonProperty, Column(Name = "play_16_trigger")]
		public uint Play16Trigger { get; set; } = 0;

		[JsonProperty, Column(Name = "play_17")]
		public ushort Play17 { get; set; } = 0;

		[JsonProperty, Column(Name = "play_17_trigger")]
		public uint Play17Trigger { get; set; } = 0;

		[JsonProperty, Column(Name = "play_18")]
		public ushort Play18 { get; set; } = 0;

		[JsonProperty, Column(Name = "play_18_trigger")]
		public uint Play18Trigger { get; set; } = 0;

		[JsonProperty, Column(Name = "play_19")]
		public ushort Play19 { get; set; } = 0;

		[JsonProperty, Column(Name = "play_19_trigger")]
		public uint Play19Trigger { get; set; } = 0;

		[JsonProperty, Column(Name = "play_2")]
		public ushort Play2 { get; set; } = 0;

		[JsonProperty, Column(Name = "play_2_trigger")]
		public uint Play2Trigger { get; set; } = 0;

		[JsonProperty, Column(Name = "play_20")]
		public ushort Play20 { get; set; } = 0;

		[JsonProperty, Column(Name = "play_20_trigger")]
		public uint Play20Trigger { get; set; } = 0;

		[JsonProperty, Column(Name = "play_3")]
		public ushort Play3 { get; set; } = 0;

		[JsonProperty, Column(Name = "play_3_trigger")]
		public uint Play3Trigger { get; set; } = 0;

		[JsonProperty, Column(Name = "play_4")]
		public ushort Play4 { get; set; } = 0;

		[JsonProperty, Column(Name = "play_4_trigger")]
		public uint Play4Trigger { get; set; } = 0;

		[JsonProperty, Column(Name = "play_5")]
		public ushort Play5 { get; set; } = 0;

		[JsonProperty, Column(Name = "play_5_trigger")]
		public uint Play5Trigger { get; set; } = 0;

		[JsonProperty, Column(Name = "play_6")]
		public ushort Play6 { get; set; } = 0;

		[JsonProperty, Column(Name = "play_6_trigger")]
		public uint Play6Trigger { get; set; } = 0;

		[JsonProperty, Column(Name = "play_7")]
		public ushort Play7 { get; set; } = 0;

		[JsonProperty, Column(Name = "play_7_trigger")]
		public uint Play7Trigger { get; set; } = 0;

		[JsonProperty, Column(Name = "play_8")]
		public ushort Play8 { get; set; } = 0;

		[JsonProperty, Column(Name = "play_8_trigger")]
		public uint Play8Trigger { get; set; } = 0;

		[JsonProperty, Column(Name = "play_9")]
		public ushort Play9 { get; set; } = 0;

		[JsonProperty, Column(Name = "play_9_trigger")]
		public uint Play9Trigger { get; set; } = 0;

		[JsonProperty, Column(Name = "quest_notify", DbType = "blob")]
		public byte[] QuestNotify { get; set; }

		[JsonProperty, Column(Name = "urgentQuestIndex")]
		public short UrgentQuestIndex { get; set; } = -1;

	}

}
