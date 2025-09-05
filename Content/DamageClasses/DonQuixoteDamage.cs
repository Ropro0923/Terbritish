


namespace Terbritish.Content.DamageClasses
{
	public class DonQuixoteDamage : DamageClass
	{
		public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
		{
			if (damageClass == DamageClass.Generic)
				return StatInheritanceData.Full;

			if (damageClass == ModContent.GetInstance<BritishDamage>())
				return StatInheritanceData.Full;

			return StatInheritanceData.None;
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