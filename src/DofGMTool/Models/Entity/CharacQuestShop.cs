using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace DofGMTool.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "charac_quest_shop", DisableSyncStructure = true)]
	public partial class CharacQuestShop {

		[JsonProperty, Column(Name = "charac_no", IsPrimary = true)]
		public uint CharacNo { get; set; } = 0;

		[JsonProperty, Column(Name = "all_element_attack")]
		public ushort AllElementAttack { get; set; } = 0;

		[JsonProperty, Column(Name = "all_element_resist")]
		public ushort AllElementResist { get; set; } = 0;

		[JsonProperty, Column(Name = "attack_speed")]
		public ushort AttackSpeed { get; set; } = 0;

		[JsonProperty, Column(Name = "dark_element_attack")]
		public ushort DarkElementAttack { get; set; } = 0;

		[JsonProperty, Column(Name = "dark_element_resist")]
		public ushort DarkElementResist { get; set; } = 0;

		[JsonProperty, Column(Name = "evasion")]
		public ushort Evasion { get; set; } = 0;

		[JsonProperty, Column(Name = "fire_element_attack")]
		public ushort FireElementAttack { get; set; } = 0;

		[JsonProperty, Column(Name = "fire_element_resist")]
		public ushort FireElementResist { get; set; } = 0;

		[JsonProperty, Column(Name = "good_hit")]
		public ushort GoodHit { get; set; } = 0;

		[JsonProperty, Column(Name = "hit_recovery")]
		public ushort HitRecovery { get; set; } = 0;

		[JsonProperty, Column(Name = "hp_regen")]
		public ushort HpRegen { get; set; } = 0;

		[JsonProperty, Column(Name = "init_count")]
		public ushort InitCount { get; set; } = 0;

		[JsonProperty, Column(Name = "light_element_attack")]
		public ushort LightElementAttack { get; set; } = 0;

		[JsonProperty, Column(Name = "light_element_resist")]
		public ushort LightElementResist { get; set; } = 0;

		[JsonProperty, Column(Name = "mag_attack")]
		public ushort MagAttack { get; set; } = 0;

		[JsonProperty, Column(Name = "mag_critical")]
		public ushort MagCritical { get; set; } = 0;

		[JsonProperty, Column(Name = "mag_defence")]
		public ushort MagDefence { get; set; } = 0;

		[JsonProperty, Column(Name = "max_hp")]
		public ushort MaxHp { get; set; } = 0;

		[JsonProperty, Column(Name = "max_mp")]
		public ushort MaxMp { get; set; } = 0;

		[JsonProperty, Column(Name = "move_speed")]
		public ushort MoveSpeed { get; set; } = 0;

		[JsonProperty, Column(Name = "mp_regen")]
		public ushort MpRegen { get; set; } = 0;

		[JsonProperty, Column(Name = "psy_attack")]
		public ushort PsyAttack { get; set; } = 0;

		[JsonProperty, Column(Name = "psy_critical")]
		public ushort PsyCritical { get; set; } = 0;

		[JsonProperty, Column(Name = "psy_defense")]
		public ushort PsyDefense { get; set; } = 0;

		[JsonProperty, Column(Name = "qp")]
		public uint Qp { get; set; } = 0;

		[JsonProperty, Column(Name = "quest_piece")]
		public ushort QuestPiece { get; set; } = 0;

		[JsonProperty, Column(Name = "separate_psy_mag_attack")]
		public ushort SeparatePsyMagAttack { get; set; } = 0;

		[JsonProperty, Column(Name = "water_element_attack")]
		public ushort WaterElementAttack { get; set; } = 0;

		[JsonProperty, Column(Name = "water_element_resist")]
		public ushort WaterElementResist { get; set; } = 0;

	}

}
