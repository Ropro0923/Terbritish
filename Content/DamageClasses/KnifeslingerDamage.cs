


namespace Terbritish.Content.DamageClasses
{
	public class KnifeslingerDamage : DamageClass
	{
		public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
		{
			if (damageClass == DamageClass.Generic)
				return StatInheritanceData.Full;

			if (damageClass == DamageClass.Melee)
				return new StatInheritanceData(
					damageInheritance: 0.75f,
					critChanceInheritance: 0.75f,
					attackSpeedInheritance: 0.75f,
					armorPenInheritance: 1f,
					knockbackInheritance: 0.75f
				);

			return new StatInheritanceData(
				damageInheritance: 0f,
				critChanceInheritance: 0f,
				attackSpeedInheritance: 0f,
				armorPenInheritance: 0f,
				knockbackInheritance: 0f
			);
		}


		public override bool GetEffectInheritance(DamageClass damageClass) {
		//	if (damageClass == DamageClass.Magic)
		//		return true;
			return false;
		}

		public override void SetDefaultStats(Player player) {
		//	player.GetCritChance<BritishDamageClass>() += 4;
		}
		
		public override bool UseStandardCritCalcs => true;

		public override bool ShowStatTooltipLine(Player player, string lineName)
		{
			return true;
		}
	}
}